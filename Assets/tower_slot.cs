using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_slot : MonoBehaviour
{
    public bool active;
    SpriteRenderer sp;
    selected Tower;
    GameObject selected_tower;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        Tower = GetComponentInParent<selected>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            sp.color = Color.green;
        }
        else
        {
            sp.color = Color.red;
        }
    }
    private void OnMouseUpAsButton()
    {
        if (active)
        {
            GetComponent<SpriteRenderer>().sprite = Tower.tower_selected.GetComponent<SpriteRenderer>().sprite;
            transform.localScale = Tower.tower_selected.transform.localScale;
        }
    }
}
