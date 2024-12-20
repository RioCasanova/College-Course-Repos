import { useState, useEffect } from "react";

import Head from "next/head";
import Image from "next/image";
import styles from "../styles/Home.module.css";

import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";

import Container from "@mui/material/Container";

import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";

import { getRandomQuote } from "../utils/api/quotes.js";

export default function Home() {
  const DEFAULT_QUOTE_DATA = {
    quote: "Quote here.",
    author: "Author here",
  };
  const [quoteData, setQuoteData] = useState(DEFAULT_QUOTE_DATA);
  const [quoteCount, setQuoteCount] = useState(0);
  useEffect(() => {
    console.log("mounted");
    loadRandomQuote();
  }, []);

  useEffect(() => {
    console.log("quote data");
    console.log(quoteData);

    // if it is the default we want to skip this data
    if (quoteData.quote == DEFAULT_QUOTE_DATA.quote) {
      return;
    }

    // increment the quote count
    setQuoteCount(quoteCount + 1);
  }, [quoteData]);

  const loadRandomQuote = () => {
    getRandomQuote().then((data) => {
      setQuoteData({
        quote: data.content,
        author: data.author,
      });
    });
  };

  return (
    <div>
      <Head>
        <title>We Love Quotes</title>
        <meta name="description" content="Generated by create next app" />
        <link rel="icon" href="/favicon.ico" />
        <link
          rel="stylesheet"
          href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap"
        />
      </Head>
      <AppBar position="relative">
        <Toolbar>
          <Typography variant="h6" color="inherit" noWrap>
            We Love Quotes
          </Typography>
        </Toolbar>
      </AppBar>
      <main>
        <Container maxWidth="sm">
          <Box
            sx={{
              bgcolor: "background.paper",
              pt: 8,
              pb: 6,
            }}
          >
            <Typography
              variant="h5"
              align="center"
              color="text.primary"
              paragraph
            >
              {quoteData.quote}
            </Typography>
            <Typography
              component="h1"
              variant="h4"
              align="center"
              color="text.secondary"
              gutterBottom
            >
              {quoteData.author}
            </Typography>
            <Typography
              component="p"
              variant="p"
              align="center"
              color="text.secondary"
              gutterBottom
            >
              You have loaded {quoteCount} quote(s)
            </Typography>
            <Box display="flex" justifyContent="center">
              <Button variant="contained" onClick={loadRandomQuote}>
                Get New Quote
              </Button>
            </Box>
          </Box>
        </Container>
      </main>
    </div>
  );
}
