using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorEvent2 : MonoBehaviour
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
                if(!door.GetCurrentAnimatorStateInfo(0).IsName("door_open2"))
                {
                    door.Play("door_open2", 0, 0.0f);
                }
            }
        }
    }
}