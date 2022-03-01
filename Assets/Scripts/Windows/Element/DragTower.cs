
using Stayhome.Config;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Stayhome.Windows.Element
{
    public class DragTower : MonoBehaviour
    {
        [SerializeField] private GameObject image;
        [SerializeField] private Image icon;

        private PointerEventData pointer = new PointerEventData(EventSystem.current);
        private Tower towerInfo;

        private void Awake()
        {
            image.SetActive(false);
        }

        public void Drag(Tower towerInfo, EventType eventType)
        {
            switch (eventType)
            {
                case EventType.BeginDrag:
                    this.towerInfo = towerInfo;
                    icon.sprite = towerInfo.levelTowerIcon[0];
                    SetDragState(true);
                    break;

                case EventType.Drag:
                    pointer.position = transform.position = Input.mousePosition;
                    break;

                case EventType.EndDrag:
                    SetTower();
                    SetDragState(false);
                    break;
            }
        }

        private void SetDragState(bool isDrag)
        {
            image.SetActive(isDrag);
        }

        private void SetTower()
        {
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);

            foreach (RaycastResult raycastResult in raycastResults)
            {
                if(raycastResult.gameObject.GetComponent<TowerCell>())
                {
                    raycastResult.gameObject.GetComponent<TowerCell>().TrySetTower(towerInfo);
                }
            }
        }
    }
}
