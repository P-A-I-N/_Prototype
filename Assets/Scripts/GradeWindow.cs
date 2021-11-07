
using TMPro;
using UnityEngine;

public class GradeWindow : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private LotManager Lot;
    [SerializeField] private TextMeshProUGUI textMoney;
    [SerializeField] private Cashbox cashbox;

    private void Start()
    {
        UpdateContent();
        cashbox.OnClickCashbox += TryBuyGrade;
    }

    private void UpdateContent()
    {
        textMoney.text = money.ToString();

        if (Lot.IsAvailablePurchase())
        {
            cashbox.SetPrice(Lot.priceLot);
        }
        else
        {
            cashbox.OnClickCashbox -= TryBuyGrade;
        }
    }

    private void TryBuyGrade()//
    {
        if (money > Lot.priceLot)
        {
            money -= Lot.priceLot;
            Lot.UpdateLot();
            UpdateContent();
        }
    }
}
