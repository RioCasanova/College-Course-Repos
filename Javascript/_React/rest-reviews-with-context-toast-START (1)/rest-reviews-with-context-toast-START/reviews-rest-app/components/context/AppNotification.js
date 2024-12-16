import { useState, createContext } from "react";

import Snackbar from "@mui/material/Snackbar";
import MuiAlert from "@mui/material/Alert";

export const AppNotificationContext = createContext({});

export default function AppNotification(props) {
  const [open, setOpen] = useState(false);
  const [message, setMessage] = useState("");
  const [messageType, setMessageType] = useState("success");

  const showNotification = ({ message, messageType }) => {
    // set the message and severity
    setMessage(message);
    setMessageType(messageType);

    // open the notification
    setOpen(true);
  };
  const handleClose = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }

    setOpen(false);
  };

  return (
    <AppNotificationContext.Provider value={{ showNotification }}>
      {props.children}
      <Snackbar open={open} autoHideDuration={6000} onClose={handleClose}>
        <MuiAlert
          elevation={6}
          variant="filled"
          onClose={handleClose}
          severity={messageType}
          sx={{ width: "100%" }}
        >
          {message}
        </MuiAlert>
      </Snackbar>
    </AppNotificationContext.Provider>
  );
}
