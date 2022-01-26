
using System;
using UnityEngine;

namespace Stayhome
{
    [CreateAssetMenu(fileName = nameof(TowerInfo), menuName = nameof(TowerInfo))]
    public class TowerInfo : ScriptableObject
    {
        [Serializable]
        public struct TowerGrade
        {
            public GameObject tower;
            public Sprite icon;
            public long price;
        }

        public TowerGrade[] towerGrades;
    }
}
