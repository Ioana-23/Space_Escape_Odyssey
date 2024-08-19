using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class TriggerDoorEvent1 : MonoBehaviour
{
    [SerializeField] private Animator door = null;
    [SerializeField] private int level;

    private void Start()
    {
        door.SetInteger("level", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (door.GetInteger("level") >= level)
        {
            if (other.CompareTag("Player"))
            {
                if(!door.GetCurrentAnimatorStateInfo(0).IsName("door_open1"))
                {
                    door.Play("door_open1", 0, 0.0f);
                }
            }
        }
    }
}
