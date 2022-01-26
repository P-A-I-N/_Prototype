
using Stayhome.Windows.Element;
using System.Collections.Generic;
using UnityEngine;

namespace Stayhome.Windows
{
    public class GameWindow : MonoBehaviour
    {
        [SerializeField] private List<TowerInfo> towerInfos;
        [SerializeField] private TowerPanel towerPanel;
        [SerializeField] private DragTower dragTower;

        private NewGameDate newGameDate = new NewGameDate();

        private void Awake()
        {
            newGameDate.towerInfos = new List<TowerInfo>();
            newGameDate.towerInfos.AddRange(towerInfos);
            towerPanel.onTowerSelected += TowerSelected;
        }

        private void Start()
        {
            towerPanel.Init(newGameDate);

        }

        private void TowerSelected(TowerInfo towerInfo)
        {
            dragTower.Drag(towerInfo);
        }
    }
}
