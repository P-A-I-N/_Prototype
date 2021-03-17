using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayy : MonoBehaviour
{
    public Transform Pointer;

    private void LateUpdate()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray2D ray = new Ray2D(pos, Vector2.zero);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);

        //RaycastHit2D hit;
        //if(Physics2D.Raycast(ray, out hit))
        //{
        //    Pointer.position = hit.point;
        //}
    }
}
