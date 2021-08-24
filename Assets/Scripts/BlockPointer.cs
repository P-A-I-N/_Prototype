using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPointer : MonoBehaviour
{
    public GameObject target, icon_levelup, icon_delete, Splash_menu;
    public bool mouse_over;
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
            target.transform.SetParent(transform);
            icon_levelup = target.GetComponent<Tower>().icon_levelup;
            icon_delete = target.GetComponent<Tower>().icon_delete;
            Splash_menu = target.GetComponent<Tower>().Splash_menu;
            //gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
    private void OnMouseOver()
    {
        if (icon_levelup != null)
        {
            mouse_over = true;
            //Splash_menu.SetActive(true);
            //icon_levelup.SetActive(true);
            //icon_delete.SetActive(true);
        } 
    }
    private void OnMouseExit()
    {
        if (icon_levelup != null)
        {
            mouse_over = false;
            if (!target.GetComponent<Tower>().mouse_over && !Splash_menu.GetComponent<Splash_menu>().mouse_over && !icon_levelup.GetComponent<levelup>().mouse_over && !icon_delete.GetComponent<delete>().mouse_over)
            {
                Splash_menu.SetActive(false);
                icon_levelup.SetActive(false);
                icon_delete.SetActive(false);
            }
        }

    }
}
