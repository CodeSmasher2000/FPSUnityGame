using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMonitor : MonoBehaviour {

    public GameObject health04;
    public GameObject health03;
    public GameObject health02;
    public GameObject health01;
    public GameObject health00;
    public int currentHealth;
    

    // Update is called once per frame
    void Update () {
        decreaseHealthBar();
    }

    void decreaseHealthBar() {
        currentHealth = GlobalHealth.playerHealth;

        if (currentHealth == 80) {
            if (health04.transform.localScale.y <= 0.0f) {
                health04.SetActive(false);
            } else {
                health04.transform.localScale -= new Vector3(0.0f, 0.05f, 0.0f);

            }
        }
        if (currentHealth == 60) {
            if (health03.transform.localScale.y <= 0.0f) {
                health03.SetActive(false);
            } else {
                health03.transform.localScale -= new Vector3(0.0f, 0.05f, 0.0f);

            }
        }

        if (currentHealth == 40) {
            if (health02.transform.localScale.y <= 0.0f) {
                health02.SetActive(false);
            } else {
                health02.transform.localScale -= new Vector3(0.0f, 0.05f, 0.0f);

            }
        }

        if (currentHealth == 20) {
            if (health01.transform.localScale.y <= 0.0f) {
                health01.SetActive(false);
            } else {
                health01.transform.localScale -= new Vector3(0.0f, 0.05f, 0.0f);

            }
        }

        if (currentHealth == 0) {
            if (health00.transform.localScale.y <= 0.0f) {
                health00.SetActive(false);
            } else {
                health00.transform.localScale -= new Vector3(0.0f, 0.05f, 0.0f);

            }
        }
    }
}
