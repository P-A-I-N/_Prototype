using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBulletSplash : MonoBehaviour
{
    public float speed;
    public Transform parent;
    public float pos;
    public float x;
    public float range;
    private void Update()
    {
        if (parent != null)
        {
            x = parent.position.x + range;
            pos = transform.position.x;
            if (pos > x)
            {
                Destroy(gameObject);
            }
        }
    }
    void LateUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (parent == null)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            parent = collision.transform;
            speed *= 10;
        }
    }
}
