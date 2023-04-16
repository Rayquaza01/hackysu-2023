# hackysu-2023
A submission for HackYSU 2023

Created by Joe Jarvis and Sam Macchione

This project is a single player game built in Unity Engine. It is somewhat similar to Vampire Survivors.

Enemys will spawn from off screen and will chase after the player. The player can evade the enemies with WASD and shoot with LMB to fire a projectile in the direction of the enemy.

Every 10 seconds without taking damage will increase your score multiplier. The longer you can avoid getting hit, the more points you can get.

As you get points, you gain pierce. Every bullet you fire can pierce 2 enemies at the start of the game, but this increases to 3 at 50 points. You gain a 1 pierce increase at 100, 200, 400, 800, 1600, etc. points

After the game is done, you can enter your name and submit your score! Try to get the high score!

## Running the Project

First, build the react app. Run npm run build in the react-app folder to build it.

Next, build the unity game for WebGL. Add the build to the react-app dist/.

Move the react-app dist/ to the fastapi-server, and run the server with ./run.sh

The server will be accessable at localhost:8000/static

### Prebuilt Version

A zip of the prebuilt version is available on the releases page.

### Video Demo

https://youtu.be/uZkttBVy_os
