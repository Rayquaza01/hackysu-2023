using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public GameObject scoreboardDisplay;
    Scoreboard scoreboard;
    public TMP_InputField username;
    public Button submit;

    // Start is called before the first frame update
    void Start() {
        scoreboard = scoreboardDisplay.GetComponent<Scoreboard>();
        submit.onClick.AddListener(SubmitScore);
    }

    // Update is called once per frame
    void Update() {

    }

    void SubmitScore() {
        if (username.text.Length > 0) {
            string uri = "http://localhost:8000/api/addScore?name=" + UnityWebRequest.EscapeURL(username.text) + "&score=" + UnityWebRequest.EscapeURL(scoreboard.getScore().ToString());
            UnityWebRequest webRequest = UnityWebRequest.Get(uri);
            webRequest.SendWebRequest();

        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
