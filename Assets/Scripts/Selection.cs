using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    selected Tower;
    GameObject selected_tower;
    // Start is called before the first frame update
    void Start()
    {
        Tower = GetComponentInParent<selected>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUpAsButton()
    {
        Tower.tower_selected = gameObject;
    }
}
