using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        transform.parent.gameObject.GetComponent<Tower>().Level_up();
    }
}
