using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    public Text endScoreText;
    public Text endWaveText;


	// Use this for initialization
	void Start () {
        endScoreText.text ="Score: " + LevelScript.instance.currentScore;
        endWaveText.text = "Wave: " + LevelScript.instance.currentLevel;
	}

    private void Update() {
        if (Input.GetButtonDown("Jump")) {
            LevelScript.instance.gameOver();
            SceneManager.LoadScene(1);

        }
    }

    // Resets the stats and objects in the game
    public void resetGame() {

    }


}
