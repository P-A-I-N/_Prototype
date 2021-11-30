
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
    public bool[] unlockStates;

    private void Awake()
    {
        artForGradeWindow.artWindow += SetWindowArt;
        cashbox.OnClickCashbox += TryBuyGrade;
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
