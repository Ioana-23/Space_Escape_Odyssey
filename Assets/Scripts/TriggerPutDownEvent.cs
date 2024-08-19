using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TriggerPutDownEvent : MonoBehaviour
{
    public GameObject artifactOnPlayer;
    public GameObject putDownPrompt;
    public String tag;
    public Animator table;
    void Start()
    {
        //gameObject.SetActive(false);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        putDownPrompt.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(tag))
        {
            putDownPrompt.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                putDownPrompt.SetActive(false);
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                artifactOnPlayer.SetActive(false);
                table.SetBool("setDown", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        putDownPrompt.SetActive(false);
    }
}