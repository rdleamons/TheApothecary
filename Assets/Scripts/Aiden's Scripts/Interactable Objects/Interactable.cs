using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Interactable : MonoBehaviour
{
    
    public bool isInRange;

    public TMP_Text text;

    public KeyCode interactKey;

    public UnityEvent interactAction;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                Debug.Log("Pressed");
                interactAction.Invoke();
            }
        }
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            text.text = "Press E";
            isInRange = true;
            Debug.Log("Player in Range");
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            text.text = "";
            isInRange = false;
            Debug.Log("Player not in Range");
        }
    }
}
