import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemText from "@mui/material/ListItemText";

import ListItemIcon from "@mui/material/ListItemIcon";

import SportsEsportsIcon from "@mui/icons-material/SportsEsports";
import LeaderboardIcon from "@mui/icons-material/Leaderboard";

export function NavigationList(props) {
  return (
    <List component="div" disablePadding>
      <ListItem disablePadding>
        <ListItemButton onClick={() => props.switchPage("Leaderboard")}>
          <ListItemIcon><LeaderboardIcon /></ListItemIcon>
          <ListItemText>Leaderboards</ListItemText>
        </ListItemButton>
      </ListItem>
      <ListItem disablePadding>
        <ListItemButton onClick={() => props.switchPage("Game")}>
          <ListItemIcon><SportsEsportsIcon /></ListItemIcon>
          <ListItemText>Game</ListItemText>
        </ListItemButton>
      </ListItem>
    </List>
  )
}
