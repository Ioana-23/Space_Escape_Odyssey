using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerEnterSpaceShuttleEvent : MonoBehaviour
{
    [SerializeField] private GameObject spaceFirstPersonController = null;
    [SerializeField] private GameObject enterPrompt;
    [SerializeField] private GameObject firstPersonController = null;
    [SerializeField] private Animator flier;
    [SerializeField] private Animator glass_panel;
    [SerializeField] private GameObject finalMessage, end, too_late;
    void Start()
    {
        spaceFirstPersonController.SetActive(false);
        enterPrompt.SetActive(false);
        finalMessage.SetActive(false);
        too_late.SetActive(false);
    }

    private void Update()
    {
        if (flier.GetCurrentAnimatorStateInfo(0).IsName("fly"))
        {
            enterPrompt.SetActive(false);
        }
        else if (flier.GetCurrentAnimatorStateInfo(0).IsName("fin"))
        {
            finalMessage.SetActive(true);
            end.SetActive(true);
            enterPrompt.SetActive(false);
        }

        if (finalMessage.activeSelf)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                Application.Quit();
            }
        }

        if (too_late.activeSelf)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                Application.Quit();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (glass_panel.GetInteger("level") == 4)
        {
            if (!glass_panel.GetCurrentAnimatorStateInfo(0).IsName("fin1"))
            {
                if (other.CompareTag("Player"))
                {
                    enterPrompt.SetActive(true);
                    if (Input.GetKey(KeyCode.E))
                    {
                        flier.Play("fly", 0, 0.0f);
                        enterPrompt.SetActive(false);
                        firstPersonController.SetActive(false);
                        spaceFirstPersonController.SetActive(true);
                    }
                }
            }
            else
            {
                too_late.SetActive(true);
                end.SetActive(false);
                enterPrompt.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enterPrompt.SetActive(false);
    }
}
