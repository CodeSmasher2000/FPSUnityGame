using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int enemyHealth = 15;
    public GameObject theZombie;
    public AudioSource deathSound;

    void DeductPoints(int damageAmount) {
        enemyHealth -= damageAmount;
        if(enemyHealth == 0) {
            deathSound.pitch = Random.Range(0.7f, 1.2f);
            deathSound.Play();
            this.GetComponent<ZombieFollow>().enabled = false;
            theZombie.GetComponent<Animation>().Play("Dying");
            LevelScript.instance.ZombieKill();
            StartCoroutine(killZombie());
        }
    }
	

    IEnumerator killZombie() {

        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        
    }
}
