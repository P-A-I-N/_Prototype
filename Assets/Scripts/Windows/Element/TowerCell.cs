using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Stayhome.Windows.Element
{
    public class TowerCell : MonoBehaviour
    {
        [SerializeField] private Image icon;

        public void SetTower(TowerInfo towerInfo)
        {
            icon.sprite = towerInfo.towerGrades[0].icon;
        }
    }
}
