import { useRouter } from "next/router";
import { getAgency } from "@utils/api/agencies";
import { useEffect, useState } from "react";
import { Container, Typography, Grid } from "@mui/material";

import NavBar from "@components/NavBar";
import SimpleDetailsCard from "@components/SimpleDetailsCard";

export default function Agency() {
  const [agency, setAgency] = useState();
  // define the router
  const router = useRouter();

  const { agencyId } = router.query;

  const goToSpacecraft = (spacecraft) => {
    router.push(`/spacecraft/${spacecraft.id}`);
  };
  useEffect(() => {
    if (!agencyId) {
      return;
    } // if not defined just exit
    loadAgencyData();
  }, [agencyId]); // will only change when it mounts

  const loadAgencyData = async () => {
    // retrieve backend
    const data = await getAgency(agencyId);
    // set it to state
    setAgency(data);
  };
  if (!agency) {
    return <div>Loading...</div>;
  } // if not defined just exit
  return (
    <div>
      <NavBar />
      <Container sx={{ paddingTop: 2 }} component="main">
        <Grid container>
          <Grid item xs={10}>
            <img src={agency.logo_url} style={{ width: "120px" }} />
            <Typography variant="h3">Agency Page For {agency.name}</Typography>
          </Grid>
          <Grid item xs={4}>
            <Typography variant="h5">Launch Details</Typography>
            <SimpleDetailsCard
              title="Total Launches"
              description={agency.total_launch_count}
            />
            <SimpleDetailsCard
              title="Successful and Failed Launches"
              description={`Successful: ${agency.successful_launches}`}
              subDescription={`Failed: ${agency.failed_launches}`}
            />
          </Grid>
          <Grid item>
            <Typography variant="h5">Agency Information</Typography>
            <SimpleDetailsCard
              title="Administrator"
              description={agency.administrator}
            />
            <SimpleDetailsCard
              title="Description"
              description={`Founded: ${agency.founding_year}`}
              subdescription={agency.description}
            />
          </Grid>
          <Grid item xs={4}>
            <Typography variant="h5">Spacecrafts</Typography>
            {agency.spacecraft_list.map((spacecraft) => {
              return (
                <SimpleDetailsCard
                  description={spacecraft.name}
                  buttonCallback={() => {
                    console.log(spacecraft.id);
                    goToSpacecraft(spacecraft);
                  }}
                  buttonName={"Go to Spacecraft"}
                />
              );
            })}
          </Grid>
        </Grid>
      </Container>
    </div>
  );
}
