using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGlassDoorEvent : MonoBehaviour
{
    [SerializeField] private Animator door = null;
    [SerializeField] private int level;
    private void OnTriggerEnter(Collider other)
    {
        if (door.GetInteger("level") >= level)
        {
            if (other.CompareTag("Player"))
            {
                if(!door.GetCurrentAnimatorStateInfo(0).IsName("glass_open"))
                {
                    door.Play("glass_open", 0, 0.0f);
                }
            }
        }
    }
}