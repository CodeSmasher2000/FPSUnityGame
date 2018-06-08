using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDamage : MonoBehaviour {
    public int damageAmount = 5;
    public float targetDistance;
    public float allowedRange = 15;

    public RaycastHit hit;
    public GameObject bullet;
    public List<GameObject> bulletHoleList = new List<GameObject>();

    public GameObject blood;
	

	void Update () {
        dealDamage();
    }

    // If the player shoots an enemy object, and the object is within range, 
    // the enemy will take damage.
    void dealDamage() {
        if (GlobalAmmo.currentAmmo > 0) {
            RaycastHit shot;
            if (Input.GetButtonDown("Fire1")) {
                if (Physics.Raycast(transform.position,
                    transform.TransformDirection(Vector3.forward), out shot)) {
                    targetDistance = shot.distance;
                    if (targetDistance < allowedRange) {
                        shot.transform.SendMessage("DeductPoints", damageAmount);           

                        //If the bullets hit an object, instatiaties a bullethole. If it hits an
                        // enemy, bloodspray will instantiate instead.
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
                            if (hit.transform.gameObject.tag == "Zombie") {
                                StartCoroutine(bloodSpray());
                            } else {
                                addBulletHole();
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator bloodSpray() {
        var bloodHit = Instantiate(blood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
        yield return new WaitForSeconds(2);
        Destroy(bloodHit);

    }

    // Adds a bullethole-object to a List. 
    public void addBulletHole() {
        var bulletHole = Instantiate(bullet, hit.point,
                                 Quaternion.FromToRotation(Vector3.up, hit.normal));
        if(bulletHoleList.Count == 30) {
            var oldest = bulletHoleList[bulletHoleList.Count - 1];
             bulletHoleList.Remove(oldest);
            Destroy(oldest);        
        } 

        bulletHoleList.Add(bulletHole);
        
        
    }
}
