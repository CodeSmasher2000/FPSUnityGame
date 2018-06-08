using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReloading : MonoBehaviour {
    public AudioSource reloadSound;
    public GameObject crossObject;
    public GameObject mechanicssObject;

	void Start () {
        
	}
	
	void Update () {

        if(Input.GetButtonDown("Reload")) {
            //sets the ammo to max capacity when the player reloads.     
            actionReaload();
            StartCoroutine(enableScripts());
           
        }
        
    }

    IEnumerator enableScripts() {
        yield return new WaitForSeconds(1.1F);
        this.GetComponent<AudioSource>().enabled = true;
        crossObject.SetActive(true);
        mechanicssObject.SetActive(true);
        GunFire.reloading = false;
        GlobalAmmo.currentAmmo = GlobalAmmo.maxAmmo;
    }


    /**
     * Disables the sound, crossaim and mechanincs of the gun while reloading.
     * Plays a reload sound and a reload animation when the player reloads the gun.
     **/
    void actionReaload() {
        GunFire.reloading = true;
        this.GetComponent<AudioSource>().enabled = false;
        crossObject.SetActive(false);
        mechanicssObject.SetActive(false);
        reloadSound.Play();
        GetComponent<Animation>().Play("GunReload");
    }
}
