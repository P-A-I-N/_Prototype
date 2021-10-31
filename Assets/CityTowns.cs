
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class CityTowns : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMoney;
    [SerializeField] private int money;

    private List<Town> towns = new List<Town>();

    private void Awake()
    {
        UpdateContent();
    }

    private void UpdateContent()
    {
        textMoney.text = money.ToString();
    }

    private void Start()
    {
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

    private void ClickOnTown(bool loced, int price, Town town, int numScene)
    {
        if (loced == false)
        {
            if (price <= money)
            {
                money -= price;
                UpdateContent();
                town.Unloced();
            }
        }
        else
        {
            SceneManager.LoadScene(numScene);//do it SceneManager
        }
    }
}
