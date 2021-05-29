using UnityEngine;
using UnityEditor;


public class Debuff : MonoBehaviour
{
    public float dbHp1Lvl;
    public float dbHp2Lvl;
    public float dbHp3Lvl;
    public float dbHp4Lvl;
    public float dbHp5aLvl;
    public float dbHp5bLvl;

    public float poisonDamage2Lvl;
    public float timeBetweenDamage2Lvl;
    public float poisonDamage3Lvl;
    public float timeBetweenDamage3Lvl;
    public float poisonDamage4Lvl;
    public float timeBetweenDamage4Lvl;
    public float poisonDamage5aLvl;
    public float timeBetweenDamage5aLvl;
    public float poisonDamage5bLvl;
    public float timeBetweenDamage5bLvl;

    public float dbSpeed3Lvl;
    public float dbSpeed4Lvl;
    public float dbSpeed5aLvl;
    public float dbSpeed5bLvl;

    public float dbHp;
    public float poisonDamage;
    public float timeBetweenDamage;
    public float dbSpeed;
    public bool x3Damage;
    public bool besiege;
    public bool change;

    public int Db1;
    public int Db2;
    public int Db3;
    public int Db4;
    public int Db5a;
    public int Db5b;

    GameMap gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
    }
    private void Update()
    {
        if (Db1 + Db2 + Db3 + Db4 + Db5a + Db5b == 0)
        {
            NoDebuff();
        }
        if (Db1 > 0 && Db2 + Db3 + Db4 + Db5a + Db5b == 0)
        {
            Debuff1();
        }
        if (Db2 > 0 && Db3 + Db4 + Db5a + Db5b == 0)
        {
            Debuff2();
        }
        if (Db3 > 0 && Db4 + Db5a + Db5b == 0)
        {
            Debuff3();
        }
        if (Db4 > 0 && Db5a + Db5b == 0)
        {
            Debuff4();
        }
        if (Db5a > 0 && Db5b == 0)
        {
            Debuff5A();
        }
        if (Db5b > 0 && Db5a == 0)
        {
            Debuff5B();
        }
        if (Db5a > 0 && Db5b > 0)
        {
            Debuff5AB();
        }
    }

    void NoDebuff()
    {
        dbHp = 0;
        poisonDamage = 0;
        timeBetweenDamage = 0;
        dbSpeed = 0;
        x3Damage = false;
        besiege = false;
        change = false;
    }
    void Debuff1()
    {
        dbHp = dbHp1Lvl;
        poisonDamage = 0;
        timeBetweenDamage = 0;
        dbSpeed = 0;
        x3Damage = false;
        besiege = false;
        change = false;
    }
    void Debuff2()
    {
        dbHp = dbHp2Lvl;
        poisonDamage = poisonDamage2Lvl;
        timeBetweenDamage = timeBetweenDamage2Lvl;
        dbSpeed = 0;
        x3Damage = false;
        besiege = false;
        change = false;
    }
    void Debuff3()
    {
        dbHp = dbHp3Lvl;
        poisonDamage = poisonDamage3Lvl;
        timeBetweenDamage = timeBetweenDamage3Lvl;
        dbSpeed = dbSpeed3Lvl;
        x3Damage = false;
        besiege = false;
        change = false;
    }
    void Debuff4()
    {
        dbHp = dbHp4Lvl;
        poisonDamage = poisonDamage4Lvl;
        timeBetweenDamage = timeBetweenDamage4Lvl;
        dbSpeed = dbSpeed4Lvl;
        x3Damage = true;
        besiege = false;
        change = false;
    }
    void Debuff5A()
    {
        dbHp = dbHp5aLvl;
        poisonDamage = poisonDamage5aLvl;
        timeBetweenDamage = timeBetweenDamage5aLvl;
        dbSpeed = dbSpeed5aLvl;
        x3Damage = true;
        besiege = true;
        change = false;
    }
    void Debuff5B()
    {
        dbHp = dbHp5bLvl;
        poisonDamage = poisonDamage5bLvl;
        timeBetweenDamage = timeBetweenDamage5bLvl;
        dbSpeed = dbSpeed5bLvl;
        x3Damage = true;
        besiege = false;
        change = true;
    }
    void Debuff5AB()
    {
        if (dbHp5bLvl >= dbSpeed5aLvl) dbHp = dbHp5bLvl;
        else dbHp = dbHp5aLvl;
        if (poisonDamage5bLvl >= poisonDamage5aLvl) poisonDamage = poisonDamage5bLvl;
        else poisonDamage = poisonDamage5aLvl;
        if (timeBetweenDamage5bLvl >= timeBetweenDamage5aLvl) timeBetweenDamage = timeBetweenDamage5bLvl;
        else timeBetweenDamage = timeBetweenDamage5aLvl;
        if (dbSpeed5bLvl >= dbSpeed5aLvl) dbSpeed = dbSpeed5bLvl;
        else dbSpeed = dbSpeed5aLvl;
        x3Damage = true;
        besiege = true;
        change = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border" && gameObject.layer ==  LayerMask.NameToLayer("EnemyTower"))
        {
            gm.killedEnemies++;
            Destroy(gameObject);
        }
        if (collision.GetComponentInParent<Tower>() && collision.GetComponentInParent<Tower>().tipe == "Debuff")
        {
            if (collision.GetComponentInParent<Tower>().lvl == "1")
            {
                Db1++;
            }
            if (collision.GetComponentInParent<Tower>().lvl == "2")
            {
                Db2++;
            }
            if (collision.GetComponentInParent<Tower>().lvl == "3")
            {
                Db3++;
            }
            if (collision.GetComponentInParent<Tower>().lvl == "4")
            {
                Db4++;
            }
            if (collision.GetComponentInParent<Tower>().lvl == "5A")
            {
                Db5a++;
            }
            if (collision.GetComponentInParent<Tower>().lvl == "5B")
            {
                Db5b++;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<Tower>() && collision.GetComponentInParent<Tower>().tipe == "Debuff")
        {
            if (collision.GetComponentInParent<Tower>().lvl == "1")
            {
                Db1--;
            }
            if (collision.GetComponentInParent<Tower>().lvl == "2")
            {
                Db2--;
            }
            if (collision.GetComponentInParent<Tower>().lvl == "3")
            {
                Db3--;
            }
            if (collision.GetComponentInParent<Tower>().lvl == "4")
            {
                Db4--;
            }
            if (collision.GetComponentInParent<Tower>().lvl == "5A")
            {
                Db5a--;
            }
            if (collision.GetComponentInParent<Tower>().lvl == "5B")
            {
                Db5b--;
            }
        }
    }
}
