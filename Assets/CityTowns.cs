
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityTowns : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMoney;

    private List<Town> towns = new List<Town>();
    private int money;

    private void Start()
    {
        money = int.Parse(textMoney.text.ToString());

        foreach (Town town in gameObject.GetComponentsInChildren<Town>())
        {
            towns.Add(town);
        }

        foreach (Town town in towns)
        {
            if (town.GetComponent<Locker>() != null)
            {
                town.OnClick += ClickOnTown;
            }
        }
    }

    private void ClickOnTown(bool loced, int price, Town town)
    {
        if (loced == true && price <= money)
        {
            town.OnClick -= ClickOnTown;
            money -= price;
            town.Unloced();
        }
    }
}
