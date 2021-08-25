using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite auraBuff;
    [SerializeField] private Sprite auraDebuff;
    [SerializeField] private Sprite auraAttack;

    public void SetTypeAura(int numAura)
    {
        switch (numAura)
        {
            case 1:
                spriteRenderer.sprite = auraBuff;
                break;
            case 2:
                spriteRenderer.sprite = auraDebuff;
                break;
            case 3:
                spriteRenderer.sprite = auraAttack;
                break;
        }
    }
}
