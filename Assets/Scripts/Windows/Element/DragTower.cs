
using UnityEngine;
//using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Stayhome.Windows.Element
{
    public class DragTower : MonoBehaviour
    {
        [SerializeField] private GameObject image;
        [SerializeField] private Image icon;

        //private PointerEventData pointer = new PointerEventData(EventSystem.current);
        private bool canDrag = false;

        private void Awake()
        {
            image.SetActive(false);
        }

        void Update()
        {

            if (canDrag)
            {
                /*pointer.position = */transform.position = Input.mousePosition;

                if (Input.GetMouseButtonDown(0))
                {

                }
                else if (Input.anyKey)
                {
                    SetDragState(false);
                }
            }
        }

        public void Drag(TowerInfo towerInfo)
        {
            SetDragState(true);
            icon.sprite = towerInfo.towerGrades[0].icon;
        }

        private void SetDragState(bool isDrag)
        {
            canDrag = isDrag;
            image.SetActive(isDrag);
        }
    }
}
