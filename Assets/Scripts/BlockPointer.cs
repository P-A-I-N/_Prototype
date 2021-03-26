using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPointer : MonoBehaviour
{
    public GameObject target;
    Collider2D col;
    private void Update()
    {
        if (target == null)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            target = collision.gameObject;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
    

}
