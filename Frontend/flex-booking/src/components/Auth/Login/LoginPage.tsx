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
import { setAuthDataToSessionStorage } from "../../../helpers/authHelper";
import RegisterPage from "../Register/RegisterPage";
import Copyright from "../Copyright";
import './style.css';
import { useTranslation } from 'react-i18next';

const theme = createTheme();

const Login = () => {
  const { t } = useTranslation();

  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [isRegisterRendered, setIsRegisterRendered] = useState<boolean>(false);

  const signInUser = (email: string, password: string) => {
    setIsLoading(true)
  
    sendRequest(`/profile/login`, 'POST', {
      username: email,
      password: password
    })
      .then((response: any) => {
        setAuthDataToSessionStorage(response);

        setIsLoading(false)

        window.location.reload();
      })
      .catch((error: any) => {
        alert(`Error has been occured during login, error: ${error}`);
        setIsLoading(false)
      });
  }

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);

    const email = data.get('email')?.toString() as string;
    const password = data.get('password')?.toString() as string;

    signInUser(email, password);
  };

  const loadRegisterPage = () => {
    setIsRegisterRendered(true);
  }

  const registerPage = (<RegisterPage />);

  return isRegisterRendered ? registerPage : (
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
            Sign in
          </Typography>

          <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
            <TextField
              margin="normal"
              required
              fullWidth
              id="email"
              label={t('emailAddress')}
              name="email"
              autoComplete="email"
              autoFocus
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="password"
              label={t('password')}
              type="password"
              id="password"
              autoComplete="current-password"
            />
            <FormControlLabel
              control={<Checkbox value="remember" color="primary" />}
              label={t('rememberMe')}
            />

            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 0, mb: 2 }}
            >
              {t('signIn')}
            </Button>
            <Grid container>
              <Grid item xs>
                <Link href="#" variant="body2">
                  {t('forgotPass')}
                </Link>
              </Grid>
              <Grid item>
                <Link onClick={loadRegisterPage} variant="body2" className={"signup-button"}>
                  {t('dontHaveAccSignUp')}
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
        <Copyright sx={{ mt: 8, mb: 4 }} />
      </Container>
    </ThemeProvider>
  );
}

export default Login;