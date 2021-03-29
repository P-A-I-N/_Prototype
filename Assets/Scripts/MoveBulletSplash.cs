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
    private void Start()
    {
        parent = GetComponentInParent<Transform>().parent;
        range = parent.GetComponent<Tower>().range;
        x = parent.position.x + range;
    }
    private void Update()
    {
        pos = transform.position.x;
        if(pos > x)
        {
            Destroy(gameObject);
        }
    }
    void LateUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
