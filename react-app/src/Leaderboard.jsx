import React, { useState, useEffect } from "react";

import Grid from "@mui/material/Grid";

import Card from "@mui/material/Card";

import Container from "@mui/material/Container";

import Typography from "@mui/material/Typography";

import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemText from "@mui/material/ListItemText";
import ListItemIcon from "@mui/material/ListItemIcon";

function LastDayCutoff() {
  const now = new Date();
  now.setHours(0);
  now.setMinutes(0);
  now.setSeconds(0)
  now.setMilliseconds(0);

  return now.getTime();
}

function LastWeekCutoff() {
  const now = new Date(LastDayCutoff());

  now.setDate(now.getDate() - now.getDay());

  return now.getTime()
}

export function ScoreList(props) {
  const [scores, setScores] = useState([]);
  
  useEffect(() => {
    fetch("http://localhost:8000/api/getScores?cutoff=" + encodeURIComponent(props.cutoff))
      .then(res => res.json())
      .then(res => setScores(res));
  }, []);
  
  return (
    <List component="div" disablePadding>
      {scores.map(item => {
        const [id, name, score, timestamp] = item;
        return (
          <ListItem key={id}>
            <ListItemButton>
              <ListItemText>{name} - {score}</ListItemText>
            </ListItemButton>
          </ListItem>
        )
      })}

      { (scores.length === 0 && "none" )}
    </List>
  );
}

export function DemoList(props) {
  return (
    <List component="div" disablePadding>
      <ListItem disablePadding>
        <ListItemButton>
          <ListItemText>Person 1 - 5000pts</ListItemText>
        </ListItemButton>
      </ListItem>
      <ListItem disablePadding>
        <ListItemButton>
          <ListItemText>Person 2 - 3000pts</ListItemText>
        </ListItemButton>
      </ListItem>
      <ListItem disablePadding>
        <ListItemButton>
          <ListItemText>Person 3 - 2000pts</ListItemText>
        </ListItemButton>
      </ListItem>
    </List>
  );
}

export function LeaderboardList(props) {
  return (
    <Card sx={{padding: 2}}>
      <Typography variant="h6">Top Scores - {props.name}</Typography>
      <ScoreList cutoff={props.cutoff} />
    </Card>
  );
}

export function LeaderboardPage(props) {
  const today = new Date();
  
  return (
    /*<div>Leaderboard</div>*/
    <Container>
      <Grid container sx={{justifyContent: "center"}}>
        <Grid item sx={{margin: 2}}><LeaderboardList cutoff={0} name="All Time" /></Grid>
        <Grid item sx={{margin: 2}}><LeaderboardList cutoff={LastDayCutoff()} name="Last Day" /></Grid>
        <Grid item sx={{margin: 2}}><LeaderboardList cutoff={LastWeekCutoff()} name="Last Week" /></Grid>
      </Grid>
    </Container>
  )
}