
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityTowns : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMoney;
    private List<Town> towns = new List<Town>();

    [SerializeField] private int money;

    private void Start()
    {
        money = int.Parse(textMoney.text.ToString());

        foreach (Town town in gameObject.GetComponentsInChildren<Town>())
        {
            towns.Add(town);
        }
        Debug.Log(towns.Count.ToString());
    }
}
