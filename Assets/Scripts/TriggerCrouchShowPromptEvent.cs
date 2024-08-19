using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShowPromptEvent : MonoBehaviour
{
    public GameObject prompt;
    public FirstPersonController player;
    void Start()
    {
        prompt.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!player.isCrouched)
            {
                prompt.SetActive(true);
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    prompt.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        prompt.SetActive(false);
    }
}
