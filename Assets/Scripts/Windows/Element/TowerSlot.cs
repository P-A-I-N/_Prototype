
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Stayhome.Windows.Element
{
    public class TowerSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public event Action<TowerInfo, Enum.EventType> OnButtonEvent = (towerInfo, EventType) => { };

        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text text;

        private TowerInfo towerInfo;

        public void Init(TowerInfo towerInfo)//todo
        {
            this.towerInfo = towerInfo;
            icon.sprite = towerInfo.towerGrades[0].icon;
            text.text = towerInfo.towerGrades[0].price.ToString();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnButtonEvent(towerInfo, Enum.EventType.BeginDrag);
        }

        public void OnDrag(PointerEventData eventData)
        {
            OnButtonEvent(towerInfo, Enum.EventType.Drag);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnButtonEvent(towerInfo, Enum.EventType.EndDrag);
        }
    }
}
