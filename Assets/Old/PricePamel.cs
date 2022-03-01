using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PricePamel : MonoBehaviour
{
    public UnityEngine.UI.Text price;
    public GameObject tower;
    // Start is called before the first frame update
    void Start()
    {
        int _price = tower.GetComponent<Tower_old>().price;
        price.text = _price + "";
    }
}
