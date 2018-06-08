using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Handles basic AI for the zombies. 
public class ZombieFollow : MonoBehaviour {
    public GameObject thePlayer;
    public GameObject theEnemy;
    public float enemySpeed;
    public int attackTrigger;
    public RaycastHit shot;
    public int isAttacking;




    // Use this for initialization
    void Start () {
        thePlayer = LevelScript.player.gameObject;
        enemySpeed = ZombieSpawn.zombieSpeed;
	}

    // Update is called once per frame
    void Update() {
        transform.LookAt(thePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot)) {               
                if (attackTrigger == 0) {
                enemySpeed = ZombieSpawn.zombieSpeed;
                    theEnemy.GetComponent<Animation>().Play("Walking");
                    transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, enemySpeed);
                }          
        }
        if (attackTrigger == 1) {
            if( isAttacking == 0) {
                StartCoroutine( enemyDamage());
            }
            enemySpeed = 0;
         
        }
    }
    // Attacking animation starts when the enemy enters collider.
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PlayerTrigger")) {
            StartCoroutine(disableCollider());
            attackTrigger = 1;
            theEnemy.GetComponent<Animation>().Play("Attacking");
        }

    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("PlayerTrigger")) {
            attackTrigger = 0;
        }
    }

    // Calls the TakeDamge() method to activate the players pain sound and the pain-screen.
    IEnumerator enemyDamage() {        
        isAttacking = 1;       
        yield return new WaitForSeconds(0.9f);
        thePlayer.GetComponent<PlayerScript>().TakeDamage();
        yield return new WaitForSeconds(1);
        isAttacking = 0;
    }

    // Disables the collider when an enemy is close, making the enemy enter inside the collider.
    IEnumerator disableCollider() {
        var enemyTrigger = GameObject.FindGameObjectWithTag("PlayerTrigger");
        enemyTrigger.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        enemyTrigger.SetActive(true);
        yield return new WaitForSeconds(0.1f);

    }


}
