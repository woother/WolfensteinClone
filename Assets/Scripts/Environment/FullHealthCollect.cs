using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullHealthCollect : MonoBehaviour
{
    public AudioSource collectSound;
    public GameObject pickUpDisplay;

    void OnTriggerEnter(Collider other)
    {
        GlobalHealth.healthValue = 100;
        collectSound.Play();
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(false);
        pickUpDisplay.GetComponent<Text>().text = "FULL HEALTH";
        pickUpDisplay.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
