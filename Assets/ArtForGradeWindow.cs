
using System;
using UnityEngine;

public class ArtForGradeWindow : MonoBehaviour
{
    public event Action<ArtWindow> artWindow;
    [Serializable]
    public struct ArtWindow
    {
        public Sprite bg;
        public Sprite[] lvlTower;
    }

    [SerializeField] private ArtWindow[] artWindows;

    private void Start()
    {
        for (int i = 0; i < artWindows.Length; i++)
        {
            if(i == PlayerPrefs.GetInt(BackGrounds.key))
            {
                artWindow(artWindows[i]);
            }
        }
    }
}
