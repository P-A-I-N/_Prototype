
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
        private TowerInfo towerInfo;

        private void Awake()
        {
            image.SetActive(false);
        }

        public void Drag(TowerInfo towerInfo, Enum.EventType eventType)
        {
            switch (eventType)
            {
                case Enum.EventType.BeginDrag:
                    this.towerInfo = towerInfo;
                    icon.sprite = towerInfo.towerGrades[0].icon;
                    SetDragState(true);
                    break;

                case Enum.EventType.Drag:
                    pointer.position = transform.position = Input.mousePosition;
                    break;

                case Enum.EventType.EndDrag:
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
                    raycastResult.gameObject.GetComponent<TowerCell>().SetTower(towerInfo);
                }
            }
        }
    }
}
