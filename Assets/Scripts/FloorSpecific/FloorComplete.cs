using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorComplete : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject completePanel;
    public GameObject thePlayer;
    public GameObject floorTimer;
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CompletedFloor());
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        floorTimer.SetActive(false);
    }

    IEnumerator CompletedFloor()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        completePanel.SetActive(true);
    }
}