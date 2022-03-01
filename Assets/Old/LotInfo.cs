
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LotInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPrice;
    [SerializeField] private Image image;
    [SerializeField] private Locker locker;
    [SerializeField] private int price;

    public int priceLot { get { return price; } }

    public bool unlockState { get { return locker.unlocked; } }

    public void SetParametrsLot(Sprite lotImage, int lotPrice, bool unlokState)
    {
        image.sprite = lotImage;
        price = lotPrice;
        locker.SetUnlockState(unlokState);
        SetTextPrice();
    }

    private void SetTextPrice()
    {
        if (unlockState)
        {
            textPrice.text = "X";
        }
        else
        {
            textPrice.text = "..." + price.ToString();
        }
    }

    public void InstallAsPurchased()
    {
        locker.SetUnlockState(true);
        SetTextPrice();
    }
}
