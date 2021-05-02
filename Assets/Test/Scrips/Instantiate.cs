using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject inst;
    public void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(inst);
        }
    }
}
