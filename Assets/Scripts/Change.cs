using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour
{
    public float timeChange;
    public float timeX;
    public bool changeok = true;

    public void Update()
    {
        if (changeok == false && Time.time > timeX)
        {
            changeok = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() && changeok)
        {
            collision.gameObject.GetComponent<Enemy>().changeTower = changeok;
            changeok = false;
            timeX = Time.time + timeChange;
        }
    }
}
