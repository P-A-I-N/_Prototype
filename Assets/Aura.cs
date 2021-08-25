using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    private Dictionary<int, Sprite> aura;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite auraBuff;
    [SerializeField] private Sprite auraDebuff;
    [SerializeField] private Sprite auraAttack;

    public void Awake()
    {
       aura = new Dictionary<int, Sprite>
        {
            { 1 , auraBuff},
            { 2 , auraDebuff},
            { 3 , auraAttack}
        };
        return;
    }

    public void SetTypeAura(int numAura)
    {
        switch (numAura)
        {
            case 1:
                this.spriteRenderer.sprite = auraBuff;
                break;
            case 2:
                this.spriteRenderer.sprite = auraDebuff;
                break;
            case 3:
                this.spriteRenderer.sprite = auraAttack;
                break;
        }
        //spriteRenderer.sprite = aura[numAura];
    }
}
