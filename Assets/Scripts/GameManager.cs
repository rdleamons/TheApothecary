using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public SceneChange sc;

    private int itemsFound;
    private int plantsWater;
    public int ingredientsPlaced;

    public TextMeshProUGUI[] tasks;
    public GameObject taskList;

    public GameObject spyGame;
    public GameObject spySucces;
    public GameObject spyTrigger;

    public GameObject plantGame;
    public GameObject plantSuccess;
    public GameObject plantTrigger;

    public GameObject dPlant1;
    public GameObject dPlant2;
    public GameObject dPlant3;

    public GameObject lPlant1;
    public GameObject lPlant2;
    public GameObject lPlant3;

    public GameObject potionGame;
    public GameObject potionSuccess;

    public GameObject AuntUI;
    public TextMeshProUGUI auntText;

    public TextMeshProUGUI playerText;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        spyGame.SetActive(false);
        plantGame.SetActive(false);
        potionGame.SetActive(false);
        AuntUI.SetActive(false);

        if (MainManager.Instance != null)
        {
            if (itemsFound > 2)
            {
                closeTrigger(spyTrigger);
                spyGame.SetActive(false);
            }

            if(plantsWater > 2)
            {
                closeTrigger(plantTrigger);
                plantGame.SetActive(false);
            }

        }
    }


    public void Update()
    {
        if(itemsFound == 3)
        {
            spySucces.SetActive(true);
            tasks[2].text = "<s>- Find items in storage</s>";
        }

        if(plantsWater == 3)
        {
            plantSuccess.SetActive(true);
            tasks[0].text = "<s>- Water Plants</s>";
        }

        if(ingredientsPlaced == 3)
        {
            potionSuccess.SetActive(true);
            tasks[1].text = "<s>- Make Potion</s>";
        }
    }

    public void playSpy()
    {
        Debug.Log("Play I-Spy");
        spyGame.SetActive(true);
        spySucces.SetActive(false);
        taskList.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void playPlant()
    {
        Debug.Log("Play Plant");
        plantGame.SetActive(true);
        plantSuccess.SetActive(false);
        taskList.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void playPotion()
    {
        Debug.Log("Play Potion");
        potionGame.SetActive(true);
        potionSuccess.SetActive(false);
        taskList.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void itemFound(GameObject item)
    {
        item.SetActive(false);
        itemsFound++;
    }

    public void waterPlant(GameObject plant)
    {
        plantsWater++;
        plant.transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<Button>().enabled = false;
    }

    public void closeGame(GameObject game)
    {
        game.SetActive(false);
        taskList.SetActive(true);
        Time.timeScale = 1f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void closeTrigger(GameObject trigger)
    {
        trigger.SetActive(false);
    }

    public void TalkToAunt()
    {
        Debug.Log("I'm here!");
        Time.timeScale = 0f;
        AuntUI.SetActive(true);
        taskList.SetActive(false);

        sc.uiOpen = true;

        if (itemsFound == 3 & plantsWater == 3 & ingredientsPlaced == 3)
        {
            auntText.text = "Not bad. Keep it up, and you might actually start to like it here. Unlike Tony.";
        }
        else if(itemsFound == 3 & plantsWater == 3)
        {
            auntText.text = "Don't forget my potions. Miriam's coming to collect them this afternoon.";
        }
        else if (plantsWater == 3 & ingredientsPlaced == 3)
        {
            auntText.text = "The storage room is to your left. Don't dally.";
        }
        else if (itemsFound == 3 & ingredientsPlaced == 3)
        {
            auntText.text = "My flowers were looking awfully parched this morning. Do see to that.";
        }
        else
        {
            auntText.text = "Seems you still have some chores to attend to.";
        }
    }

    public void GoToBed()
    {
        if (itemsFound == 3 & plantsWater == 3 & ingredientsPlaced == 3)
        {

        }
        else
        {
            AuntUI.SetActive(true);
            sc.uiOpen = true;
            auntText.text = "You'd better not be sleeping up there! You still have chores to do!";
        }
    }

    private IEnumerator sleep()
    {
        playerText.text = "Time for bed...";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("EndCreditsScene");
    }
}
