
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Town : MonoBehaviour
{
    public Action<bool, int, Town, int, int> OnClick;

    [SerializeField] private Locker locerTown;
    [SerializeField] private Button buttonTown;
    [SerializeField] private TextMeshProUGUI textPrice;
    [SerializeField] private int price;
    [SerializeField] private int numScene;
    [SerializeField] private BackGrounds.BgWindows bgWindows;

    private void Awake()
    {
        buttonTown.onClick.AddListener(actionOnClick);
        buttonTown.onClick.AddListener(Unloced);

        if (textPrice != null)
        {
            textPrice.text = price.ToString();
        }

        if (PlayerPrefs.HasKey(BackGrounds.key + ((int)bgWindows).ToString()))
        {
            Unloced();
        }
    }

    public void Unloced()
    {
        locerTown.SetUnlockState(true);
        textPrice.enabled = false;
        buttonTown.onClick.RemoveListener(Unloced);
    }

    public void actionOnClick()
    {
        OnClick(locerTown.unlocked, price, this, numScene, (int)bgWindows);
    }
}
