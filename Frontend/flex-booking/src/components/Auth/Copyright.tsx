import { Link, Typography } from "@mui/material";
import { useTranslation } from "react-i18next";

const Copyright = (props: any) =>  {
  const { t } = useTranslation();
  
    return (
      <Typography variant="body2" color="text.secondary" align="center" {...props}>
        {'Copyright © '}
        <Link color="inherit" href="flex-booking.com">
        {t('flexBooking')}
        </Link>{' '}
        {new Date().getFullYear()}
        {'.'}
      </Typography>
    );
  }

  export default Copyright;