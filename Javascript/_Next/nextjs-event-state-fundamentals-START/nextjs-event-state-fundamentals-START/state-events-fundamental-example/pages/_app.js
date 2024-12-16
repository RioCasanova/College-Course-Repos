import "@fontsource/roboto"; // Defaults to weight 400
import "@fontsource/roboto/300.css";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css"; // Specify weight
import "@fontsource/roboto/400-italic.css"; // Specify weight and style

export default function App({ Component, pageProps }) {
  return <Component {...pageProps} />;
}
