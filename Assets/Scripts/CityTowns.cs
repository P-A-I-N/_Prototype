
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class CityTowns : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMoney;
    [SerializeField] private int money;

    private List<Town> towns = new List<Town>();

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
        }
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

    private void ClickOnTown(bool loced, int price, Town town, int numScene, int bgWindows)
    {
        if (loced == false)
        {
            if (price <= money)
            {
                money -= price;
                UpdateContent();
                town.Unloced();
                PlayerPrefs.SetString(BackGrounds.key + bgWindows.ToString(), "true");
            }
        }
        else
        {
            PlayerPrefs.SetInt(BackGrounds.key, bgWindows);
            PlayerPrefs.SetInt("Money", money);
            SceneManager.LoadScene(numScene);
        }
    }
}
