using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour
{
    GameMap gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUpAsButton()
    {
        gm.gold += transform.parent.gameObject.GetComponent<Tower>().fullprice / 2;
        Destroy(transform.parent.gameObject);
    }
}
