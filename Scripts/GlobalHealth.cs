using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour {
    public static int playerHealth = 100;
    public int internalHealth;
    public GameObject healthDisplay;


    // Update is called once per frame
    void Update () {
        internalHealth = playerHealth;
        healthDisplay.GetComponent<Text>().text = "Health " + playerHealth;
        if(playerHealth == 0) {
            SceneManager.LoadScene(2);
        }
	}
}
