using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandgunPickUp : MonoBehaviour
{

    public GameObject realHandgun;
    public GameObject fakeHandgun;
    public AudioSource handgunPickupSound;
    public GameObject pickUpDisplay;

    void OnTriggerEnter(Collider other)
    {
        realHandgun.SetActive(true);
        fakeHandgun.SetActive(false);
        handgunPickupSound.Play();
        GetComponent <BoxCollider>().enabled = false;
        pickUpDisplay.GetComponent<Text>().text = "HANDGUN";
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(true);
    }

}
