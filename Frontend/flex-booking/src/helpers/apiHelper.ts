const baseApiUrl = "http://localhost:43709";


async function sendRequest(
    url: string,
    httpMethod: 'GET' | 'POST' | 'DELETE' | 'PUT' = 'GET',
    body?: any
) {
   // const authData = getAuthDataFromSessionStorage();

    return fetch(`${baseApiUrl}${url}`,
        {
            method: httpMethod,
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: {
                Accept: "application/json",
                'Content-Type': "application/json",
                // Authorization: `Bearer ${authData?.access_token}`
            },
            body: body ? JSON.stringify(body) : null
        },
    ).then(async response => {
        if (response.ok) {
            if(response.status == 204){
                return () => response.statusText;
            }
            return response.json();
        }

        const errorData = await response.json();
        
        // ValidationException, TBD
        if (errorData?.errors?.entity && errorData?.errors?.entity[0]) {
            return Promise.reject(errorData?.errors?.entity[0]);
        }
        else{
            return Promise.reject(errorData);
        }
    })
}

export default sendRequest;