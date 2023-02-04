using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
    }

    public void playPlant()
    {
        Debug.Log("Play Plant");
        plantGame.SetActive(true);
        plantSuccess.SetActive(false);
        taskList.SetActive(false);
    }

    public void playPotion()
    {
        Debug.Log("Play Potion");
        potionGame.SetActive(true);
        potionSuccess.SetActive(false);
        taskList.SetActive(false);
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
    }

    public void closeTrigger(GameObject trigger)
    {
        trigger.SetActive(false);
    }
}
