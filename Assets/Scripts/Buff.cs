using UnityEngine;

public class Buff : MonoBehaviour
{
    public float multiplyRangeLvl2;
    public float multiplyRangeLvl3;
    public float multiplyRangeLvl4;
    public float multiplyRangeLvl5a;
    public float multiplyRangeLvl5b;

    public float multiplyDamageLvl3;
    public float multiplyDamageLvl4;
    public float multiplyDamageLvl5a;
    public float multiplyDamageLvl5b;

    public float multiplySpeedLvl5a;

    public bool invisible;
    public float multiplyRange;
    public float multiplyDamage;
    public bool strong;
    public float multiplySpeed;

    public int B1;
    public int B2;
    public int B3;
    public int B4;
    public int B5a;
    public int B5b;

    private void Update()
    {
        if (B1 + B2 + B3 + B4 + B5a + B5b == 0)
        {
            NoBuff();
        }
        if (B1 > 0 && B2 + B3 + B4 + B5a + B5b == 0)
        {
            Buff1();
        }
        if (B2 > 0 && B3 + B4 + B5a + B5b == 0)
        {
            Buff2();
        }
        if (B3 > 0 && B4 + B5a + B5b == 0)
        {
            Buff3();
        }
        if (B4 > 0 && B5a + B5b == 0)
        {
            Buff4();
        }
        if (B5a > 0 && B5b == 0)
        {
            Buff5A();
        }
        if (B5b > 0 && B5a == 0)
        {
            Buff5B();
        }
        if (B5a > 0 && B5b > 0)
        {
            Buff5AB();
        }
    }

    void NoBuff()
    {
        invisible = false;
        multiplyRange = 0;
        multiplyDamage = 0;
        strong = false;
        multiplySpeed = 0;
    }
    void Buff1()
    {
        invisible = true;
        multiplyRange = 0;
        multiplyDamage = 0;
        strong = false;
        multiplySpeed = 0;
    }
    void Buff2()
    {
        invisible = true;
        multiplyRange = multiplyRangeLvl2;
        multiplyDamage = 0;
        strong = false;
        multiplySpeed = 0;
    }
    void Buff3()
    {
        invisible = true;
        multiplyRange = multiplyRangeLvl3;
        multiplyDamage = multiplyDamageLvl3;
        strong = false;
        multiplySpeed = 0;
    }
    void Buff4()
    {
        invisible = true;
        multiplyRange = multiplyRangeLvl4;
        multiplyDamage = multiplyDamageLvl4;
        strong = true;
        multiplySpeed = 0;
    }
    void Buff5A()
    {
        invisible = true;
        multiplyRange = multiplyRangeLvl5a;
        multiplyDamage = multiplyDamageLvl5a;
        strong = true;
        multiplySpeed = multiplySpeedLvl5a;
    }
    void Buff5B()
    {
        invisible = true;
        multiplyRange = multiplyRangeLvl5b;
        multiplyDamage = multiplyDamageLvl5b;
        strong = true;
        multiplySpeed = 0;
    }
    void Buff5AB()
    {
        invisible = true;
        if (multiplyRangeLvl5a > multiplyRangeLvl5b) multiplyRange = multiplyRangeLvl5a;
        else multiplyRange = multiplyRangeLvl5b;
        if (multiplyDamageLvl5a > multiplyDamageLvl5b) multiplyDamage = multiplyDamageLvl4;
        else multiplyDamage = multiplyDamageLvl5b;
        strong = true;
        multiplySpeed = multiplySpeedLvl5a;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TowerBuff")
        {
            if (collision.GetComponentInParent<Tower>().tipe == "Buff")
            {
                if (collision.GetComponentInParent<Tower>().lvl == "1")
                {
                    B1++;
                    Debug.Log("+1");
                }
                if (collision.GetComponentInParent<Tower>().lvl == "2")
                {
                    B2++;
                    Debug.Log("+2");
                }
                if (collision.GetComponentInParent<Tower>().lvl == "3")
                {
                    B3++;
                    Debug.Log("+3");
                }
                if (collision.GetComponentInParent<Tower>().lvl == "4")
                {
                    B4++;
                    Debug.Log("+4");
                }
                if (collision.GetComponentInParent<Tower>().lvl == "5A")
                {
                    B5a++;
                    Debug.Log("+5");
                }
                if (collision.GetComponentInParent<Tower>().lvl == "5B")
                {
                    B5b++;
                    Debug.Log("+6");
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TowerBuff")
        {
            if (collision.GetComponentInParent<Tower>().tipe == "Buff")
            {
                if (collision.GetComponentInParent<Tower>().lvl == "1")
                {
                    B1--;
                }
                if (collision.GetComponentInParent<Tower>().lvl == "2")
                {
                    B2--;
                }
                if (collision.GetComponentInParent<Tower>().lvl == "3")
                {
                    B3--;
                }
                if (collision.GetComponentInParent<Tower>().lvl == "4")
                {
                    B4--;
                }
                if (collision.GetComponentInParent<Tower>().lvl == "5A")
                {
                    B5a--;
                }
                if (collision.GetComponentInParent<Tower>().lvl == "5B")
                {
                    B5b--;
                }
            }
        }
    }
}
