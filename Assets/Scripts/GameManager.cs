using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int itemsFound;
    public GameObject spyGame;
    public GameObject spySucces;

    public GameObject plantGame;
    public GameObject plantSuccess;

    public GameObject potionGame;
    public GameObject potionSuccess;

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
    }

    public void closeTrigger(GameObject trigger)
    {
        trigger.SetActive(false);
    }
}
