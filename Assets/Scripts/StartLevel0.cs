using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] public GameObject enterPrompt;
    [SerializeField] public FirstPersonController player;
    [SerializeField] public Animator glass_panel1, glass_panel2;
    void Start()
    {
        player.cameraCanMove = false;
        player.playerCanMove = false;
        gameObject.SetActive(true);
        enterPrompt.SetActive(true);
        glass_panel1.SetInteger("level", 0);
        glass_panel2.SetInteger("level", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            player.cameraCanMove = true;
            player.playerCanMove = true;
            enterPrompt.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
