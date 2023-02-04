using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int itemsFound;
    private int plantsWater;

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
        spyGame = GameObject.Find("I-Spy");
        spySucces = GameObject.Find("SpySuccess");
        spyTrigger = GameObject.Find("I-Spy Trigger");

        plantGame = GameObject.Find("Plants");
        plantSuccess = GameObject.Find("PlantSuccess");

        potionGame = GameObject.Find("Potions");
        potionSuccess = GameObject.Find("PotionSuccess");

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
        }

        if(plantsWater == 3)
        {
            plantSuccess.SetActive(true);
        }
    }

    public void playSpy()
    {
        Debug.Log("Play I-Spy");
        spyGame.SetActive(true);
        spySucces.SetActive(false);
    }

    public void playPlant()
    {
        Debug.Log("Play Plant");
        plantGame.SetActive(true);
        plantSuccess.SetActive(false);
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
        itemsFound = 5; // This is a really dumb workaround, bear with me
    }

    public void closeTrigger(GameObject trigger)
    {
        trigger.SetActive(false);
    }
}
