using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public bool panelOpen = false;
    public GameObject firstFloor;
    public GameObject secondFloor;

    public void Start()
    {
        secondFloor.SetActive(false);
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void TogglePanel(GameObject panel)
    {
        if(panelOpen)
        {
            panel.SetActive(false);
            firstFloor.SetActive(true);
            panelOpen = false;
        }
        else if(!panelOpen)
        {
            panel.SetActive(true);
            firstFloor.SetActive(false);
            panelOpen = true;
        }
            
    }
}
