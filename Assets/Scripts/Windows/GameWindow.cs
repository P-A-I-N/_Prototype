
using Stayhome.Config;
using Stayhome.Windows.Element;
using System.Collections.Generic;
using UnityEngine;

namespace Stayhome.Windows
{
    public class GameWindow : MonoBehaviour
    {
        [SerializeField] private List<Tower> towerInfos;
        [SerializeField] private TowerPanel towerPanel;
        [SerializeField] private DragTower dragTower;

        private NewGameDate newGameDate = new NewGameDate();

        private void Awake()
        {
            newGameDate.towerInfos = new List<Tower>();
            newGameDate.towerInfos.AddRange(towerInfos);
            towerPanel.OnTowerSelected += TowerSelected;
        }

        private void Start()
        {
            towerPanel.Init(newGameDate);

        }

        private void TowerSelected(Tower towerInfo, EventType eventType)
        {
            dragTower.Drag(towerInfo, eventType);
        }
    }
}
