
using System;
using System.Collections.Generic;
using UnityEngine;

public class LotManager : MonoBehaviour
{
    [SerializeField] private GameObject lotInfo;

    private LotInfo currentLot;
    private List<LotInfo> lotsInfo = new List<LotInfo>();

    public int priceLot { get { return currentLot.priceLot; } }

    public void  CreateLots(Sprite[] sprites, int[] prises, bool[] unlockStates)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            lotsInfo.Add(Instantiate(lotInfo, gameObject.transform).GetComponent<LotInfo>());
            lotsInfo[i].SetParametrsLot(sprites[i], prises[i], unlockStates[i]);
        }

        SetCurrentLot();
    }

    private void SetCurrentLot()
    {
        currentLot = null;

        for (int i = 0; i < lotsInfo.Count; i++)
        {
            if (lotsInfo[i].unlockState == false)
            {
                currentLot = lotsInfo[i];
                break;
            }
            else
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetInt(BackGrounds.key).ToString()  + "Lvl", i);
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
