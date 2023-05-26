import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Link from '@mui/material/Link';
import Grid from '@mui/material/Grid';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { useEffect, useState } from 'react';
import sendRequest from "../../../helpers/apiHelper";
import {setAuthDataToSessionStorage} from "../../../helpers/authHelper";
import Copyright from "../Copyright";

const theme = createTheme();

const Register = () => {

    const [isLoading, setIsLoading] = useState<boolean>(false);

    const [formErrors, setFormErrors] = useState<any>({});
    const [isSubmitting, setIsSubmitting] = useState<boolean>(false);
    
    const registerUser = (email: string, password: string) => {
        setIsLoading(true)
        //mock response from server
        // setAuthDataToSessionStorage({
        //     userId : 1,
        //     roleId: 2,
        //     } as AuthData);

        sendRequest(`/profile/register`, 'POST', {
            username: email,
            password: password
        })
            .then((response: any) => {
                setAuthDataToSessionStorage(response);

                setIsLoading(false)

                window.location.reload();
            })
            .catch((error: any) => {
                alert(`Error has been occured during register, error: ${error}`);
                setIsLoading(false)
            });
    }

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);

        const email = data.get('email')?.toString() as string;
        const password = data.get('password')?.toString() as string;

        const errors: any = {};

        // Check for empty email field
        if (!email) {
            errors.email = 'Email is required';
        }

        // Check for empty password field
        if (!password) {
            errors.password = 'Password is required';
        }

        // Set the formErrors state
        setFormErrors(errors);

        // If there are no errors, proceed with form submission
        if (Object.keys(errors).length === 0) {
            setIsSubmitting(true);
            registerUser(email, password);
        }
    };

    const [errorMessage, setErrorMessage] = useState<any>();
    const [isError, setIsError] = useState<boolean>(false);
    const [authData, setAuthData] = useState<any>();

    return (
        <ThemeProvider theme={theme}>
            <Container component="main" maxWidth="xs">

                <CssBaseline />
                <Box
                    sx={{
                        marginTop: 8,
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                    }}
                >
                    <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                        <LockOutlinedIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        Sign up
                    </Typography>

                    <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="email"
                            label="Email Address"
                            name="email"
                            autoComplete="email"
                            autoFocus
                            error={!!formErrors.email} // Add error prop
                            helperText={formErrors.email} // Display error message
                        />
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            name="password"
                            label="Password"
                            type="password"
                            id="password"
                            autoComplete="current-password"
                            error={!!formErrors.password} // Add error prop
                            helperText={formErrors.password} // Display error message
                        />

                        <Button
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{ mt: 0, mb: 2 }}
                            disabled={isSubmitting}
                        >
                            Sign Up
                        </Button>
                    </Box>
                </Box>
                <Copyright sx={{ mt: 8, mb: 4 }} />
            </Container>
        </ThemeProvider>
    );
}

export default Register;