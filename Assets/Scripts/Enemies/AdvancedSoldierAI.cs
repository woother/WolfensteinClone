using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AdvancedSoldierAI : MonoBehaviour
{

    public string hitTag;
    public bool lookingAtPlayer = false;
    public GameObject theSoldier;
    public AudioSource fireSound;
    public bool isFiring = false;
    public float fireRate = 0.5f;
    public int genHurt;
    public AudioSource[] hurtSound;
    public GameObject hurtFlash;

    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            hitTag = Hit.transform.tag;

        }
        if (hitTag == "Player" && isFiring == false)
        {
            StartCoroutine(EnemyFire());
        }
        if (hitTag != "Player")
        {
            theSoldier.GetComponent<Animator>().Play("EnemyIdle");
            lookingAtPlayer = false;
        }
    }

    IEnumerator EnemyFire()
    {
        isFiring = true;
        theSoldier.GetComponent<Animator>().Play("FireRifle", -1, 0);
        theSoldier.GetComponent<Animator>().Play("FireRifle");
        fireSound.Play();
        lookingAtPlayer = true;
        GlobalHealth.healthValue -= 5;
        StartCoroutine(HurtEffect());
        yield return new WaitForSeconds(0.2f);
        genHurt = Random.Range(0, 3);
        hurtSound[genHurt].Play();
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }

    IEnumerator HurtEffect()
    {
        yield return new WaitForSeconds(0.1f);
        hurtFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hurtFlash.SetActive(false);
    }

}
