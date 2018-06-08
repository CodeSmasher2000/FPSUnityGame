using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour {
    public GameObject[] spawnArray;
    public int nbrOfSpawns;
    public GameObject zombie;
    public static float zombieSpeed;
    

    // Use this for initialization
    void Start () {
        LevelScript.instance.spawnArraytest.Add(this);
                
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnZombie(int currentLevel) {
       var z = Instantiate(zombie);
        float speedMod = (float)currentLevel / 100;
        zombieSpeed = 0.01f + speedMod;
        z.GetComponent<ZombieFollow>().enemySpeed = zombieSpeed;

        z.transform.position = this.transform.position;
       
        
    }
}
