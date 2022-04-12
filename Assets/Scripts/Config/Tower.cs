
using System;
using UnityEngine;

namespace Stayhome.Config
{
    [CreateAssetMenu(fileName = nameof(Tower), menuName = nameof(Tower))]
    public class Tower : ScriptableObject, ISerializationCallbackReceiver
    {
        [Serializable]
        public struct Data
        {
            [Serializable]
            public struct Normal
            {
                public long price;
                public long helth;
                public long damage;
                [Range(0, 8)]
                public long attackRange;
                public long attackSpeed;
            }

            [Serializable]
            public struct Freeze
            {
                public long price;
                public long helth;
                public long damage;
                [Range(0, 8)]
                public long attackRange;
                public long attackSpeed;
            }

            [Serializable]
            public struct Pvo
            {
                public long price;
                public long helth;
                public long damage;
                [Range(0, 8)]
                public long attackRange;
                public long attackSpeed;
            }

            [Serializable]
            public struct Splash
            {
                public long price;
                public long helth;
                public long damage;
                [Range(0, 8)]
                public long attackRange;
                public long attackSpeed;
            }

            [Serializable]
            public struct Super
            {
                public long price;
                public long helth;
                public long damage;
                [Range(0, 8)]
                public long attackRange;
                public long attackSpeed;
            }

            [Serializable]
            public struct Tank
            {
                public long price;
                public long helth;
            }

            [Serializable]
            public struct Buff
            {
                public long price;
                public long helth;
            }

            [Serializable]
            public struct Debuff
            {
                public long price;
                public long helth;
            }

            [Serializable]
            public struct Money
            {
                public long price;
                public long helth;
            }

            public TowerType type;
            public Normal[] normal;
            public Freeze[] freeze;
            public Pvo[] pvo;
            public Splash[] splash;
            public Tank[] tank;
            public Buff[] buff;
            public Debuff[] debuff;
            public Super[] super;
            public Money[] money;
        }

        public Sprite[] levelTowerIcon;
        public Data data;

        public void OnBeforeSerialize()
        {
            Data data = this.data;
            if (data.type != TowerType.Normal) data.normal = default;
            if (data.type != TowerType.Freeze) data.freeze = default;
            if (data.type != TowerType.Pvo) data.pvo = default;
            if (data.type != TowerType.Splash) data.splash = default;
            if (data.type != TowerType.Tank) data.tank = default;
            if (data.type != TowerType.Buff) data.buff = default;
            if (data.type != TowerType.Debuff) data.debuff = default;
            if (data.type != TowerType.Super) data.super = default;
            if (data.type != TowerType.Money) data.money = default;
            this.data = data;
        }

        public void OnAfterDeserialize()
        {
        }
    }
}
