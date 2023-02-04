using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public bool panelOpen = false;

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
            panelOpen = false;
        }
        else if(!panelOpen)
        {
            panel.SetActive(true);
            panelOpen = true;
        }
            
    }
}
