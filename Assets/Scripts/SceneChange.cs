using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public bool panelOpen = false;
    public bool uiOpen = false;
    public GameObject firstFloor;
    public GameObject secondFloor;
    public GameObject AuntUI;
    public GameObject taskList;

    public void Start()
    {
        secondFloor.SetActive(false);
        AuntUI.SetActive(false);
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

    public void ToggleUI(GameObject panel)
    {
        if (uiOpen)
        {
            panel.SetActive(false);
            uiOpen = false;
            taskList.SetActive(true);
            Time.timeScale = 1.0f;
        }
        else if (!uiOpen)
        {
            panel.SetActive(true);
            uiOpen = true;
        }
    }
}
