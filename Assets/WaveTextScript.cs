using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTextScript : MonoBehaviour
{
    bool startEnabled = true;
    float timeHide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled && startEnabled)
        {
            timeHide = Time.time + 3;
            startEnabled = false;
        }
        if (!startEnabled && Time.time > timeHide)
        {
            startEnabled = true;
            enabled = false;
        }
    }
}
