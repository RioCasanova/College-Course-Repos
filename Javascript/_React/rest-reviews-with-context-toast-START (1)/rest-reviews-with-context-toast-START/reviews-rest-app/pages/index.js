import { useState, useContext, useEffect } from "react";

import Container from "@mui/material/Container";

import { AppNotificationContext } from "../components/context/AppNotification";
import AdaptationReviewList from "../components/AdapatationReviewList";
import AdaptationReviewForm from "../components/AdaptationReviewForm";
import NavBar from "../components/NavBar";
import SEO from "../components/SEO";

import { getReviews } from "../utils/api/reviews";

export default function Home() {
  // use context here so that I can use this function
  const { showNotification } = useContext(AppNotificationContext);

  const [reviews, setReviews] = useState([]);

  useEffect(() => {
    loadAllReviews();
  }, []);

  const removeReview = (id) => {
    let currentReviews = reviews.filter((review) => {
      return review.id !== id;
    });
    setReviews(currentReviews);
  };

  const loadAllReviews = () => {
    getReviews().then((data) => {
      setReviews(data);
      showNotification({ message: "reviews loaded", messageType: "info" });
    });
  };

  return (
    <>
      <SEO />
      <NavBar title={"Adaptation Reviews"} />
      <Container
        sx={{
          pt: 2,
          pb: 2,
        }}
        maxWidth="md"
        component="main"
      >
        <AdaptationReviewForm reviews={reviews} setReviews={setReviews} />
        <AdaptationReviewList reviews={reviews} removeReview={removeReview} />
      </Container>
    </>
  );
}
