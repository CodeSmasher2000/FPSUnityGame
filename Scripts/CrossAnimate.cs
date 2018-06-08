using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Handles the aim-UI for the player. 
public class CrossAnimate : MonoBehaviour {
    public GameObject upCurs;
    public GameObject downCurs;
    public GameObject leftCurs;
    public GameObject rightCurs;
	
    // Every time the player shoots the crossaim will animate.
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            upCurs.GetComponent<Animator>().enabled = true;
            downCurs.GetComponent<Animator>().enabled = true;
            leftCurs.GetComponent<Animator>().enabled = true;
            rightCurs.GetComponent<Animator>().enabled = true;
            StartCoroutine(waitingAnim());
         
        }
	}

    // disables the animation after 0.1 seconds.
    IEnumerator waitingAnim() {
        yield return new WaitForSeconds(0.11F);
        upCurs.GetComponent<Animator>().enabled = false;
        downCurs.GetComponent<Animator>().enabled = false;
        leftCurs.GetComponent<Animator>().enabled = false;
        rightCurs.GetComponent<Animator>().enabled = false;
    }
    
}
