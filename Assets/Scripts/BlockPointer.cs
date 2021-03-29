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
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tower" || collision.gameObject.tag == "TowerPVO")
        {
            Debug.Log(collision.tag);
            target = collision.gameObject;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }


}
