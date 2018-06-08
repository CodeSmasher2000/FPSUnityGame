using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour {
    public static int currentAmmo;
    public static int maxAmmo = 15;
    public Text ammoDisplay;

    private void Start() {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update () {
        ammoDisplay.text = "Ammo: " + currentAmmo + " /" + maxAmmo;
	}
}
