import "../styles/globals.css";
import { theme } from "../utils/theme/config";
import { ThemeProvider } from "@mui/materials/styles";

function MyApp({ Component, pageProps }) {
  return (
    <ThemeProvider theme={theme}>
      <Component {...pageProps} />;
    </ThemeProvider>
  );
}

export default MyApp;
