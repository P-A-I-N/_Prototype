using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPointer : MonoBehaviour
{
    public GameObject target, icon_levelup, icon_delete;
    private void Awake()
    {
        Physics.queriesHitTriggers = true;
    }
    private void Update()
    {
        if (target == null)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Tower>())
        {
            target = collision.gameObject;
            icon_levelup = collision.gameObject.GetComponent<Tower>().icon_levelup;
            icon_delete = collision.gameObject.GetComponent<Tower>().icon_delete;
            //gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
    private void OnMouseOver()
    {
        if (icon_levelup != null)
        {
            icon_levelup.SetActive(true);
            icon_delete.SetActive(true);
        } 
    }
    private void OnMouseExit()
    {
        if (icon_levelup != null)
        {
            icon_levelup.SetActive(false);
            icon_delete.SetActive(false);
        }

    }
}
