
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Town : MonoBehaviour
{
    public Action<bool, int, Town> OnClick;

    [SerializeField] private Locker locerTown;
    [SerializeField] private Button buttonTown;
    [SerializeField] private TextMeshProUGUI textPrice;

    private int price;

    private void Start()
    {
        if (textPrice != null)
        {
            buttonTown.onClick.AddListener(() => actionOnClick());
            price = int.Parse(textPrice.text.ToString());
        }
    }

    public void Unloced()
    {
        locerTown.Unlocked(buttonTown);
        textPrice.enabled = false;
        buttonTown.onClick.RemoveListener(() => actionOnClick());
    }

    private void actionOnClick()
    {
        OnClick(locerTown.locke, price, this);
    }
}
