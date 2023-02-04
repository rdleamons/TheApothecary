using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int itemsFound;

    private void Start()
    {
        if (MainManager.Instance != null)
        {
            itemsFound = 3;
        }
    }

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

    public void itemFound(GameObject item)
    {
        item.SetActive(false);
        itemsFound++;
    }
}
