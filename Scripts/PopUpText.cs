using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour {
    public Text popUpText;

	// Use this for initialization
	void Start () {
        hideText();
       }
	
	public void levelCompleteText() {
        popUpText.text = "Level Demolished!";
        gameObject.SetActive(true);
        Invoke("hideText", 2f);
    }

    public void newLevelStartedText(int currentLevel) {
        popUpText.text = "Level " + currentLevel +  " Starting!";
        gameObject.SetActive(true);
        Invoke("hideText", 2f);
    }

    public void hideText() {
        gameObject.SetActive(false);
    }
}
