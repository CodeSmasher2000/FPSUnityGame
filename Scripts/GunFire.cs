using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunFire : MonoBehaviour {

    private AudioSource gunfire;
    public GameObject muzzleFlash;
    public Text realoadText;
    public static bool reloading = false;
    // Use this for initialization
    void Start() {
        gunfire = GetComponent<AudioSource>();
        realoadText.enabled = false;

    }

    // Plays gun audio and animation when the player shoots with left-mouse-button.
    void Update () {
        if (Input.GetButtonDown("Fire1")) {
           gunShot();
        }
	}

    // If the player isnt reloading or doesnt have any bullets, the gun sound and animations will play.
    void gunShot() {
        if (reloading) {
            return;
        } else { 
            if (GlobalAmmo.currentAmmo > 0) {
                gunfire.Play();
                muzzleFlash.SetActive(true);
                StartCoroutine( muzzleOff());
                GetComponent<Animation>().Play("GunShot");
                GlobalAmmo.currentAmmo -= 1;
              
            } else {
                StartCoroutine(showReloadText());
            }
        }
    }

    // Disables the muzzleflash after 0.1 seconds.
    IEnumerator muzzleOff() {
        yield return new WaitForSeconds(0.1F);
        muzzleFlash.SetActive(false);
    }

    // Shows a text-panel if the player needs to reload.
    IEnumerator showReloadText() {
        realoadText.enabled = true;
        yield return new WaitForSeconds(2);
        realoadText.enabled = false;
    }
}
