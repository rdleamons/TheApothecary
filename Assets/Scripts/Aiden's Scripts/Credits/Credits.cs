using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    
    public string sceneName;

    public int secondsPast = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        secondsPast++;
        Debug.Log(secondsPast);

        if(secondsPast >= 1000)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
