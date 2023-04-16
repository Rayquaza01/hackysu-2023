import sqlite3

import time

from fastapi import FastAPI
from fastapi.staticfiles import StaticFiles

app = FastAPI()

app.mount("/static", StaticFiles(directory="dist", html=True), name="static")

@app.get("/api/addScore")
def addScore(name: str, score: int):
    print("Adding score " + name + " " + str(score))
    date = int(time.time() * 1000)

    with sqlite3.connect("highscores.db") as db:
        cursor = db.cursor()
        res = cursor.execute("INSERT INTO scores (name, score, date) VALUES (?, ?, ?);", (name, score, date))
        db.commit()
    return {"ok": True}

@app.get("/api/getScores")
def getScores(cutoff: int | None = None):
    if cutoff == None:
        cutoff = 0

    with sqlite3.connect("highscores.db") as db:
        cursor = db.cursor()
        res = cursor.execute("SELECT * FROM scores WHERE date >= ? ORDER BY score DESC;", (cutoff,)).fetchall();
    return res
