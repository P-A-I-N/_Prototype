
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Town : MonoBehaviour
{
    public Action<bool, int, Town, int> OnClick;

    [SerializeField] private Locker locerTown;
    [SerializeField] private Button buttonTown;
    [SerializeField] private TextMeshProUGUI textPrice;
    [SerializeField] private int price;
    [SerializeField] private int numScene;

    private void Awake()
    {
        if (textPrice != null)
        {
            textPrice.text = price.ToString();
        }
    }

    public void Unloced()
    {
        locerTown.Unlocked(buttonTown);
        textPrice.enabled = false;
        buttonTown.onClick.RemoveListener(() => actionOnClick());
    }

    public void actionOnClick()
    {
        OnClick(locerTown.unlocked, price, this, numScene);
    }
}
