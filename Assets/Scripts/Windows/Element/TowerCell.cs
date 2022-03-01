
using Stayhome.Config;
using UnityEngine;
using UnityEngine.UI;

namespace Stayhome.Windows.Element
{
    public class TowerCell : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private NewTower tower;

        private bool isEmptySlot = true;

        public void TrySetTower(Tower towerInfo)
        {
            if(isEmptySlot)
            {
                tower.SetTower(towerInfo);
                isEmptySlot = false;
            }
        }
    }
}
