using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Handles the sounds when the player takes damage.
public class PlayerScript : MonoBehaviour {

    public GameObject damageTakenScreen;
    public AudioSource hurt01;
    public AudioSource hurt02;
    public AudioSource hurt03;
    public int painSound;



    public void TakeDamage() {
        StartCoroutine(ApplyDamage());
    }

    public IEnumerator ApplyDamage() {
        painSound = Random.Range(1, 4);
        

        damageTakenScreen.SetActive(true);
        GlobalHealth.playerHealth -= 20;
        if (painSound == 1) {
            hurt01.Play();
        }
        if (painSound == 2) {
            hurt02.Play();
        }
        if (painSound == 3) {
            hurt03.Play();
        }

        yield return new WaitForSeconds(0.05f);
        damageTakenScreen.SetActive(false);        
    }
}
