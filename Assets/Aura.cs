using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite auraBuff;
    [SerializeField] private Sprite auraDebuff;
    [SerializeField] private Sprite auraAttack;

    public void SetTypeAura(int numAura, float range)
    {
        range += range / 10;
        switch (numAura)
        {
            case 1:
                spriteRenderer.sprite = auraBuff;
                transform.localScale = new Vector3(13, 14, 0);
                break;
            case 2:
                spriteRenderer.sprite = auraDebuff;
                transform.localPosition = new Vector3(14, 15, 0);
                transform.localScale = new Vector3(7, 7, 0);
                break;
            case 3:
                spriteRenderer.sprite = auraAttack;
                transform.localScale = new Vector3(range, 7, 0);
                transform.localPosition = new Vector3(range * 3, 0, 0);
                break;
        }
    }
}
