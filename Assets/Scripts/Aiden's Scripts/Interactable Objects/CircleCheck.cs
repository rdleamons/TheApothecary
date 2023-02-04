using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCheck : MonoBehaviour
{
    public bool isClose;

    public void Circle()
    {
        if(!isClose)
        {
            isClose = true;
            Debug.Log("Item was interacted with");
        }
    }
}
