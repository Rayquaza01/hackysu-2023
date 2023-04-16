import './App.css'
import React, {useState} from "react";
import Box from "@mui/material/Box";

import { NavigationList } from "./NavigationList";

import { GamePage } from "./Game";
import { LeaderboardPage } from "./Leaderboard";

import BasicAppBar from "./BasicAppBar";
import Drawer from "@mui/material/Drawer";
import Button from "@mui/material/Button";

const isMobile = /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)
const drawerWidth = isMobile ? "60vw" : "500px";

export default function App() {
  const [open, setOpen] = useState(false);
  const [page, setPage] = useState("Leaderboard");

  function toggleDrawer() {
    setOpen(!open);
  }

  function switchPage(page) {
    toggleDrawer();
    setPage(page);
  }
  
  return (
    <Box>
      <BasicAppBar name={page} toggleDrawer={toggleDrawer} />
      <Drawer sx={{ width: drawerWidth, flexShrink: 0, "& .MuiDrawer-paper": { width: drawerWidth, boxSizing: "border-box" } }} ModalProps={{ onBackdropClick: toggleDrawer }} open={open}>
        <Button onClick={toggleDrawer}>Close</Button>
        <NavigationList switchPage={switchPage} />
      </Drawer>
      { (page === "Game") && <GamePage /> }
      { (page === "Leaderboard") && <LeaderboardPage /> }
    </Box>
  )
}
