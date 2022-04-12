using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    LineRenderer line;
    private DamageCastle gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponentInParent<DamageCastle>();
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(1, new Vector3(-8 + 15 * gm.health / 50, 4, 1));
    }
}
