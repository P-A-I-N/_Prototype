
using Stayhome.Config;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Stayhome.Windows.Element
{
    public class TowerSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public event Action<Tower, EventType> OnButtonEvent = (towerInfo, EventType) => { };

        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text text;

        private Tower towerInfo;

        public void Init(Tower towerInfo)
        {
            this.towerInfo = towerInfo;
            icon.sprite = towerInfo.levelTowerIcon[0];
            switch (towerInfo.data.type)
            {
                case TowerType.Normal:
                    text.text = towerInfo.data.normal[0].price.ToString();
                    break;

                case TowerType.Freeze:
                    text.text = towerInfo.data.freeze[0].price.ToString();
                    break;

                case TowerType.Pvo:
                    text.text = towerInfo.data.pvo[0].price.ToString();
                    break;

                case TowerType.Splash:
                    text.text = towerInfo.data.splash[0].price.ToString();
                    break;

                case TowerType.Tank:
                    text.text = towerInfo.data.tank[0].price.ToString();
                    break;

                case TowerType.Buff:
                    text.text = towerInfo.data.buff[0].price.ToString();
                    break;
                case TowerType.Debuff:
                    text.text = towerInfo.data.debuff[0].price.ToString();
                    break;

                case TowerType.Super:
                    text.text = towerInfo.data.super[0].price.ToString();
                    break;

                case TowerType.Money:
                    text.text = towerInfo.data.money[0].price.ToString();
                    break;
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnButtonEvent(towerInfo, EventType.BeginDrag);
        }

        public void OnDrag(PointerEventData eventData)
        {
            OnButtonEvent(towerInfo, EventType.Drag);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnButtonEvent(towerInfo, EventType.EndDrag);
        }
    }
}
