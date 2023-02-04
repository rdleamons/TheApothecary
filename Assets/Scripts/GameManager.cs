using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int itemsFound;
    public GameObject spySucces;

    public void Update()
    {
        if(itemsFound == 3)
        {
            spySucces.SetActive(true);
        }
    }

    public void itemFound(GameObject item)
    {
        item.SetActive(false);
        itemsFound++;
        spySucces.SetActive(true);
    }

    public void closeGame(GameObject game, GameObject prompt)
    {
        game.SetActive(false);
        prompt.SetActive(false);
    }
}
