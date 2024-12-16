import { useRouter } from "next/router";
import { getSpaceCraft } from "@utils/api/spaceCraft";
import { useEffect, useState } from "react";
import { Container, Typography, Grid } from "@mui/material";

import NavBar from "@components/NavBar";
import SimpleDetailsCard from "@components/SimpleDetailsCard";

export default function SpaceCraft() {
  const [spacecraft, setSpacecraft] = useState();
  // define the router
  const router = useRouter();
  const { spacecraftId } = router.query;

  useEffect(() => {
    if (!spacecraftId) {
      return;
    } // if not defined just exit
    loadSpaceCraftData();
  }, [spacecraftId]);

  //
  //

  // retrieving the data from the fetch
  const loadSpaceCraftData = async () => {
    // retrieve backend
    const data = await getSpaceCraft(spacecraftId);
    // set it to state
    setSpacecraft(data);
  };

  //

  // if not defined just exit
  if (!spacecraft) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <NavBar />
      <Container sx={{ paddingTop: 2 }} component="main">
        <Grid container>
          <Grid item xs={10}>
            <Typography variant="h3">{spacecraft.name}</Typography>
          </Grid>
          <Grid item xs={4}>
            <Typography variant="h5">SpaceCraft Information</Typography>
            <SimpleDetailsCard title="Administrator" />
          </Grid>
        </Grid>
      </Container>
    </div>
  );
}
