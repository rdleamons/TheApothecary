using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderRender : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 50;

    [SerializeField]
    private float offset = 0.0f;

    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Awake()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rend.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
    }
}
