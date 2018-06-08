using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Handles the basic game-mechanics such as spawning zombies, keeping track of scores and current waves.
public class LevelScript : MonoBehaviour {

    public static LevelScript instance;
    public static PlayerScript player;
    public GameObject playerTrigger;
    public List<ZombieSpawn> spawnArraytest = new List<ZombieSpawn>();
    public int currentLevel = 0;
    public int aliveZombieCount = 0;
    public PopUpText popUpTextScript;
    public AudioSource newLevelSound;

    public Text scoreText;
    public Text waveText;
    public int score = 10;
    public int currentScore = 0;


    void Awake() {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
       // DontDestroyOnLoad(gameObject);
    }



    // Use this for initialization
    void Start () {
 
        initNewLevel();

    }
    // Initializes a new wave of zombies.
    public void initNewLevel() {
        Debug.Log("StartGame");
        currentLevel++;
        addWaveText();        
        player = GameObject.FindGameObjectWithTag("ThePlayer").GetComponent<PlayerScript>();       
        popUpTextScript.newLevelStartedText(currentLevel);
        newLevelSound.Play();
        // Zombies spawn after 2 seconds
        Invoke("SpawnZombies", 2f);
    }

    // Spawns zombies at random spawn points-objects. Zombies cant spawn at same spawn-point as another.
    private void SpawnZombies() {
       
        List<ZombieSpawn> availbleSpawns = new List<ZombieSpawn>();
        availbleSpawns.AddRange(spawnArraytest);
        for(int i = 0; i<currentLevel +5; i++) {
            var currentSpawn = availbleSpawns[UnityEngine.Random.Range(0, availbleSpawns.Count)];
            currentSpawn.SpawnZombie(currentLevel);
            aliveZombieCount++;
            availbleSpawns.Remove(currentSpawn);
        }
        Debug.Log("spawning " + aliveZombieCount + " zombies");
    }

    // Keeps track of alive zombies and if the wave is complete.
    internal void ZombieKill() {
        aliveZombieCount--;
        addScore();
        Debug.Log("Killed a zombie, " + aliveZombieCount + " left");
        if (aliveZombieCount == 0) {
            popUpTextScript.levelCompleteText();
            Invoke("initNewLevel", 4f);
        }
    }


    public void addWaveText() {
        waveText.text = " " + currentLevel;
    }

    public void addScore() {
        currentScore = currentScore + score;
        scoreText.text = " " + currentScore;
    }

    public void gameOver() {
        currentScore = 0;
        currentLevel = 0;
        GlobalHealth.playerHealth = 100;
    }
}
