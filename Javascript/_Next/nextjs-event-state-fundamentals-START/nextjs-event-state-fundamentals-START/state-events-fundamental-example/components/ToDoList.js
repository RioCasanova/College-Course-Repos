import { useState } from "react";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import IconButton from "@mui/material/IconButton";
import DeleteIcon from "@mui/icons-material/Delete";

export default function ToDoList() {
  const [toDoText, setToDoText] = useState("");
  const [allToDos, setAllToDos] = useState([]);

  const onAddToDoClick = () => {
    // creating a new copy of the array using spread
    let newArray = [toDoText, ...allToDos];
    setAllToDos(newArray);
    // resetting the to do text
    setToDoText("");
  };

  const onToDoTextChange = (event) => {
    setToDoText(event.target.value);
  };
  const onRemoveTodoClick = (index) => {
    const ITEMS_TO_REMOVE = 1;
    console.log(`the todo item at index${index} is ${allTodos[index]}`);
    // create a copy of the array
    let newAllTodos = [...allToDos];

    // use splice to remove an instance
    newAllTodos.splice(index, ITEMS_TO_REMOVE);

    // set state of allToDos
    setAllToDos(newAllTodos);
    console.log("onRemoveTodoClick");
    console.log(index);
  };
  return (
    <Box sx={{ flexGrow: 1 }}>
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <Typography variant="h2" gutterBottom>
            Our Todo List
          </Typography>
        </Grid>
        <Grid item xs={10}>
          <TextField
            fullWidth
            id="new-todo-item"
            label="New Todo"
            variant="outlined"
            value={toDoText}
            onChange={onToDoTextChange}
          />
        </Grid>
        <Grid item sx={2}>
          <Button variant="outlined" onClick={onAddToDoClick}>
            Submit
          </Button>
        </Grid>
        <Grid item xs={12} md={6}>
          <List>
            {allToDos.map((toDo, index) => {
              return (
                <ListItem key={index} divider>
                  secondaryAction=
                  {
                    <IconButton
                      edge="end"
                      aria-label="delete"
                      onClick={() => {
                        onRemoveTodoClick(index);
                      }}
                    >
                      <DeleteIcon />
                    </IconButton>
                  }
                  <ListItemText primary={toDo} />
                </ListItem>
              );
            })}
          </List>
        </Grid>
      </Grid>
    </Box>
  );
}
