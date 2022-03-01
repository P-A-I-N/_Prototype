
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GradeWindow : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private LotManager lotManager;
    [SerializeField] private TextMeshProUGUI textMoney;
    [SerializeField] private Cashbox cashbox;

    [SerializeField] private ArtForGradeWindow artForGradeWindow;

    [SerializeField] private Image bgWindow;

    public int[] prises;
    private bool[] unlockStates = new bool[6];

    private void Awake()
    {
        money = PlayerPrefs.GetInt("Money");

        if (PlayerPrefs.HasKey(PlayerPrefs.GetInt(BackGrounds.key).ToString() + "Lvl"))
        {
            for (int i = 0; i < unlockStates.Length; i++)
            {
                if (i <= PlayerPrefs.GetInt(PlayerPrefs.GetInt(BackGrounds.key).ToString() + "Lvl"))
                {
                    unlockStates[i] = true;
                }
            }
        }

        artForGradeWindow.artWindow += SetWindowArt;
        cashbox.OnClickCashbox += TryBuyGrade;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Money", money);
    }

    private void SetWindowArt(ArtForGradeWindow.ArtWindow artWindow)
    {
        bgWindow.sprite = artWindow.bg;
        lotManager.CreateLots(artWindow.lvlTower, prises, unlockStates);
        UpdateContent();
    }

    private void UpdateContent()
    {
        textMoney.text = money.ToString();

        if (lotManager.IsAvailablePurchase())
        {
            cashbox.SetPrice(lotManager.priceLot);
        }
        else
        {
            cashbox.SetPrice(0);
            cashbox.OnClickCashbox -= TryBuyGrade;
        }
    }

    private void TryBuyGrade()//
    {
        if (money > lotManager.priceLot)
        {
            money -= lotManager.priceLot;
            lotManager.UpdateLot();
            UpdateContent();
        }
    }
}
