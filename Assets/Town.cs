
using System;
using UnityEngine;
using UnityEngine.UI;

public class Town : MonoBehaviour
{

    [SerializeField] private Locker locerTown;
    [SerializeField] private Button buttonTown;

    public void Awake()
    {
        buttonTown.onClick.AddListener(() => actionOnClick());
    }

    private void actionOnClick()
    {
        Debug.Log("+");
    }
}
