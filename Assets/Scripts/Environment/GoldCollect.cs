using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCollect : MonoBehaviour
{
    public GameObject goldIngots;
    public AudioSource collectSound;
    public GameObject pickUpDisplay;

    void OnTriggerEnter(Collider other)
    {
        GlobalScore.scoreValue += 100;
        GlobalComplete.treasureCount += 1;
        goldIngots.SetActive(false);
        collectSound.Play();
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(false);
        pickUpDisplay.GetComponent<Text>().text = "GOLD INGOTS";
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(true);
    }
}
