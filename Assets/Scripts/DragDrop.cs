using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectt;
    [SerializeField] private Canvas canvas;
    private CanvasGroup cg;

    private void Awake()
    {
        rectt = GetComponent<RectTransform>();
        cg = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        cg.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectt.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cg.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
