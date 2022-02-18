using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stayhome
{
    public class PrefabSet : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour element;
        [SerializeField] private int columns;
        [SerializeField] private int lines;

        private void Start()
        {
            for (int i = 0; i < columns * lines; i++)
            {
                Instantiate(element.gameObject, transform);
            }
        }
    }
}
