using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int itemsFound;
    public GameObject spyGame;
    public GameObject spySucces;
    public GameObject spyTrigger;

    public GameObject plantGame;
    public GameObject plantSuccess;

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

        }
    }


    public void Update()
    {
        if(itemsFound == 3)
        {
            spySucces.SetActive(true);
        }
    }

    public void playSpy()
    {
        Debug.Log("Play I-Spy");
        spyGame.SetActive(true);
        spySucces.SetActive(false);
    }

    public void itemFound(GameObject item)
    {
        item.SetActive(false);
        itemsFound++;
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
