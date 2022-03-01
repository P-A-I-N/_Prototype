
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cashbox : MonoBehaviour
{
    public event Action OnClickCashbox = () => { }; 
    [SerializeField] private TextMeshProUGUI textPrice;
    [SerializeField] private Button buttonCashbox;

    private void Start()
    {
        buttonCashbox.onClick.AddListener(() => OnClickCashbox());
    }

    public void SetPrice(int price)
    {
        textPrice.text = price.ToString();
    }
}
