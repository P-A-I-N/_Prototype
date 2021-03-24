using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Ray : MonoBehaviour
{
    public GameObject target;
    private void Update()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, 100f);

        if(Input.GetMouseButtonDown(0) && hit.collider != null && hit.collider.tag == "Tower")
        {
            target = hit.collider.gameObject;
        }
    }
    
}
