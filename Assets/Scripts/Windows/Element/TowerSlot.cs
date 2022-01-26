
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Stayhome.Windows.Element
{
    public class TowerSlot : MonoBehaviour
    {
        public event Action<TowerInfo> onButtonClick = towerInfo => { };

        [SerializeField] private Button button;
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text text;

        private TowerInfo towerInfo;

        private void Awake()
        {
            button.onClick.AddListener(OnButtonEvent);
        }

        public void Init(TowerInfo towerInfo)//todo
        {
            this.towerInfo = towerInfo;
            icon.sprite = towerInfo.towerGrades[0].icon;
            text.text = towerInfo.towerGrades[0].price.ToString();
        }

        private void OnButtonEvent()
        {
            onButtonClick(towerInfo);
        }
    }
}
