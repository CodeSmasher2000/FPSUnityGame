using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour {
    public Text startGameText;
    private bool startScreen;
	// Use this for initialization
	void Start () {
        startScreen = true;
        StartCoroutine(blinkingText());

    }
	
	// Update is called once per frame
	void Update () {

         

        if(Input.GetButtonDown("Jump")) {
            startScreen = false;
            SceneManager.LoadScene(1);
        }
	}

    IEnumerator blinkingText() {
        while (startScreen) { 
            startGameText.enabled = true;
            yield return new WaitForSeconds(1);
            startGameText.enabled = false;
            yield return new WaitForSeconds(1);
        }
    }
}
