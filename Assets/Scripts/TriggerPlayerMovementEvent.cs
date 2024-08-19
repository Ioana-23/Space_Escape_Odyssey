using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSlowerPlayerMovementEvent : MonoBehaviour
{
    [SerializeField] private FirstPersonController player = null;
    [SerializeField] private float speed;
    [SerializeField] private float bobAmount;
    [SerializeField] private float crouchReduction;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (speed != 0)
            {
                if (player.walkSpeed == 5)
                {
                    player.walkSpeed = speed;
                    player.bobAmount = new Vector3(0, bobAmount, 0);
                }
                else
                {
                    player.walkSpeed = 5;
                    player.bobAmount = new Vector3(0, 0.1f, 0);
                }
            }
    
            if (crouchReduction != 0)
            {
                if (player.isCrouched)
                {
                    if (player.walkSpeed == 2.5f)
                    {
                        player.walkSpeed = 5 * crouchReduction;
                        player.speedReduction = 0.3f;
                    }
                    else
                    {
                        player.walkSpeed = 2.5f;
                        player.speedReduction = 0.5f;
                    }
                }
                else
                {
                    if (player.speedReduction == 0.5f)
                    {
                        player.walkSpeed = 5;
                        player.speedReduction = 0.3f;
                    }
                    else
                    {
                        player.walkSpeed = 5;
                        player.speedReduction = 0.5f;
                    }
                }
            }
        }
    }
}
