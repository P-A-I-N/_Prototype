using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed;
    void LateUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Enemy" || collision.tag =="Boss")
        {
            Destroy(gameObject);
        }
    }
}
