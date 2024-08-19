using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPickUpEvent : MonoBehaviour
{
    public GameObject artifactOnPlayer;
    public GameObject pickUpPrompt;
    void Start()
    {
        artifactOnPlayer.SetActive(false);
        pickUpPrompt.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickUpPrompt.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                pickUpPrompt.SetActive(false);
                gameObject.SetActive(false);
                artifactOnPlayer.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pickUpPrompt.SetActive(false);
    }
}
