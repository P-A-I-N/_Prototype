
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LotInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPrice;
    [SerializeField] private Image lotImage;
    [SerializeField] private Locker locker;
    [SerializeField] private int price;
    public int priceLot { get { return price; } }
    public bool unlockState { get { return locker.unlocked; } }
    private void Awake()
    {
        textPrice.text = price.ToString();
    }

    public void InstallAsPurchased()
    {
        locker.Unlocked();
    }
}
