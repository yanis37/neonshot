using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftCross : MonoBehaviour
{

    public EdgeCollider2D edgeCollider;

    void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))        
        {
            edgeCollider.enabled = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            edgeCollider.enabled = true;
        }
    }
}
