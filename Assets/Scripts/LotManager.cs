
using UnityEngine;

public class LotManager : MonoBehaviour
{
    private LotInfo currentLot;

    public int priceLot { get { return currentLot.priceLot; } }

    private void Start()
    {
        SetCurrentLot();
    }

    public void SetCurrentLot()
    {
        currentLot = null;

        foreach (LotInfo lot in gameObject.GetComponentsInChildren<LotInfo>())
        {
            if (lot.unlockState == false)
            {
                currentLot = lot.gameObject.GetComponent<LotInfo>();
                break;
            }
        }
    }

    public void UpdateLot()
    {
        currentLot.InstallAsPurchased();
        SetCurrentLot();
    }

    public bool IsAvailablePurchase() => currentLot != null;
}
