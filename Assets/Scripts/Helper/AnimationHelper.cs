
using System;
using UnityEditor.Animations;
using UnityEngine;

namespace Stayhome.Helper
{
    public class AnimationHelper : MonoBehaviour
    {
        [Serializable]
        public struct AnimationTower
        {
            public TowerType type;
            public AnimatorController animatorController;
        }

        [SerializeField] private Animator animator;

        public void SetAnimation(TowerType type)
        {
            //animator.
        }
    }
}
