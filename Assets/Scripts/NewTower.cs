
using Stayhome.Config;
using UnityEngine;
using UnityEngine.UI;

namespace Stayhome
{
    public class NewTower : MonoBehaviour
    {
        [SerializeField] private Image icon;

        public void SetTower(Tower towerInfo)
        {
            icon.sprite = towerInfo.levelTowerIcon[0];
        }
    }
}
