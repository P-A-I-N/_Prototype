
using System;
using UnityEngine;

namespace Stayhome.Windows.Element
{
    public class TowerPanel : MonoBehaviour
    {
        public event Action<TowerInfo, Enum.EventType> onTowerSelected = (tower, eventType) => { };

        [SerializeField] private GameObject rootTowerButton;

        public void Init(NewGameDate gameDate)
        {
            for (int i = 0; i < gameDate.towerInfos.Count; i++)
            {
                GameObject tower = Instantiate(rootTowerButton, gameObject.transform);
                TowerSlot towerSlot = tower.GetComponent<TowerSlot>();
                towerSlot.Init(gameDate.towerInfos[i]);
                towerSlot.OnButtonEvent += OnTowerSelected;
            }
        }

        public void OnTowerSelected(TowerInfo towerInfo, Enum.EventType eventType)
        {
            onTowerSelected(towerInfo, eventType);
        }
    }
}
