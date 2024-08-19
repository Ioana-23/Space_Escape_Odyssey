using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SleepInBed : MonoBehaviour
{
    [SerializeField] public GameObject sleepPrompt, fadeToBlackScreen, level4_information, enter_to_Exit;
    [SerializeField] public List<Animator> doors; 
    [SerializeField] public Animator table;
    [SerializeField] public TextMeshProUGUI levelNumber;
    [SerializeField] public FirstPersonController player;
    private int level;
    [SerializeField] private TextMeshProUGUI textClock;
    private float timeRemaining = 120;
    void Start()
    {
        level4_information.SetActive(false);
        Color objectColor = fadeToBlackScreen.GetComponent<Image>().color;
        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, 0);
        fadeToBlackScreen.GetComponent<Image>().color = objectColor;
        sleepPrompt.SetActive(false);
        textClock.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (textClock.gameObject.activeSelf)
        {
            if (timeRemaining > 0)
            {
                float minutes = Mathf.FloorToInt(timeRemaining / 60);
                float seconds = Mathf.FloorToInt(timeRemaining % 60);
                textClock.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                textClock.gameObject.SetActive(false);
            }

        }
        if (level == 4)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                player.cameraCanMove = true;
                player.playerCanMove = true;
                level4_information.SetActive(false);
                enter_to_Exit.SetActive(false);
                foreach (Animator door in doors)
                {
                    door.SetInteger("level", level);
                }
                textClock.gameObject.SetActive(true);
            }
        }
        if (table.GetBool("setDown"))
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sleepPrompt.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine(FadeToBlack());
                sleepPrompt.SetActive(false);
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
                table.SetBool("setDown", false);
            }
        }
    }

    public void startLevel()
    {
        level = doors[0].GetInteger("level") + 1;
        //level = 4;
        levelNumber.text = "Level " + level;
        if (level == 4)
        {
            player.cameraCanMove = false;
            player.playerCanMove = false;
            level4_information.SetActive(true);
            enter_to_Exit.SetActive(true);
            return;
        }
        foreach (Animator door in doors)
        {
            door.SetInteger("level", level);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        sleepPrompt.SetActive(false);
    }

    private IEnumerator FadeToBlack(bool fadeToBlack = true, float fadeSpeed = 5)
    {
        player.cameraCanMove = false;
        player.playerCanMove = false;
        Color objectColor = fadeToBlackScreen.GetComponent<Image>().color;

        float fadeAmount;

        
        while (fadeToBlackScreen.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            fadeToBlackScreen.GetComponent<Image>().color = objectColor;
            yield return null;
        }
        yield return new WaitForSeconds(3);
        while (fadeToBlackScreen.GetComponent<Image>().color.a > 0)
        {
            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            fadeToBlackScreen.GetComponent<Image>().color = objectColor;
            yield return null;
        }
        player.cameraCanMove = true;
        player.playerCanMove = true;
        startLevel();
    }
}
