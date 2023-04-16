using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using TMPro;

using UnityEngine;

public class Scoreboard : MonoBehaviour {
    public TMP_Text scoreDisplay;
    public TMP_Text multiplierDisplay;
    int score = 0;
    int multiplier = 1;

    public int scoreThreshold = 50;
    public int scoreThresholdRate = 2;

    public GameObject player;

    public void addScore(int add) {
        score += add * multiplier;
        scoreDisplay.text = "Score: " + score.ToString();

        if (score >= scoreThreshold) {
            player.GetComponent<MoveSquare>().projectile.GetComponent<Projectile>().pierce += 1;
            scoreThreshold *= 2;

            player.GetComponent<MoveSquare>().fireRate *= 0.9f;
        }
    }

    public void addMultiplier(int mul) {
        multiplier += mul;
        multiplierDisplay.text = "Multiplier: " + multiplier.ToString();
    }

    public void setMultiplier(int mul) {
        multiplier = mul;
        multiplierDisplay.text = "Multiplier: " + multiplier.ToString();
    }

    public int getScore() {
        return score;
    }

    // Start is called before the first frame update
    void Start() {
        scoreDisplay.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update() {

    }
}
