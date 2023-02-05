using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRender : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 50;

    [SerializeField]
    private float offset = 0.0f;

    [SerializeField]
    private bool runOnce = false;

    private SpriteRenderer render;

    // Start is called before the first frame update
    void Awake()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        render.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
        if (runOnce)
            Destroy(this);
    }
}
