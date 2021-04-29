using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPointer : MonoBehaviour
{
    public GameObject target;
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
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }


}
