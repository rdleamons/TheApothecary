using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public GameManager gm;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
        eventData.pointerDrag.gameObject.SetActive(false);
        gm.ingredientsPlaced++;
    }
}
