import Typography from "@mui/material/Typography";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";

export default function SimpleListItem({ text }) {
  return (
    <ListItem divider>
      <ListItemText>
        <Typography variant="p" component="div">
          {text}
        </Typography>
      </ListItemText>
    </ListItem>
  );
}
