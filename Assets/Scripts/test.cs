using System.Xml;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject[] tower;
    public GameObject[] bullet;
    public GameObject[] enemy;
    public string[] tipe;
    public string[] tipeEnemy;
    public string[] lvl;
    public string[] lvlEnemy;
    private XmlDocument xmlDoc;

    private void Start()
    {
        TextAsset xmlAsset = (TextAsset)Resources.Load("config");
        xmlDoc = new XmlDocument();
        if (xmlAsset) xmlDoc.LoadXml(xmlAsset.text);
        for (int i = 0; i < tower.Length; i++)
        {
            foreach (XmlNode TankBuff in xmlDoc.SelectNodes("root/Tower/Tank/Lvl5B"))
            {
                tower[i].GetComponent<Tower>().hpTankBuff = int.Parse(TankBuff.Attributes.GetNamedItem("HpTankBuff").Value);
            }
            for (int k = 0; k < tipe.Length; k++)
            {
                for (int e = 0; e < lvl.Length; e++)
                {
                    foreach (XmlNode Buff in xmlDoc.SelectNodes("root/Tower/Buff/Lvl" + lvl[e]))
                    {
                        if (tower[i].GetComponent<Buff>() != null)
                        {
                            if (lvl[e] == "2")
                            {
                                tower[i].GetComponent<Buff>().multiplyRangeLvl2 = float.Parse(Buff.Attributes.GetNamedItem("MultiplyRange").Value);
                            }
                            if (lvl[e] == "3")
                            {
                                tower[i].GetComponent<Buff>().multiplyDamageLvl3 = float.Parse(Buff.Attributes.GetNamedItem("MultiplyDamage").Value);
                                tower[i].GetComponent<Buff>().multiplyRangeLvl3 = float.Parse(Buff.Attributes.GetNamedItem("MultiplyRange").Value);
                            }
                            if (lvl[e] == "4")
                            {
                                tower[i].GetComponent<Buff>().multiplyDamageLvl4 = float.Parse(Buff.Attributes.GetNamedItem("MultiplyDamage").Value);
                                tower[i].GetComponent<Buff>().multiplyRangeLvl4 = float.Parse(Buff.Attributes.GetNamedItem("MultiplyRange").Value);
                            }
                            if (lvl[e] == "5A")
                            {
                                tower[i].GetComponent<Buff>().multiplySpeedLvl5a = float.Parse(Buff.Attributes.GetNamedItem("MultiplySpeed").Value);
                                tower[i].GetComponent<Buff>().multiplyDamageLvl5a = float.Parse(Buff.Attributes.GetNamedItem("MultiplyDamage").Value);
                                tower[i].GetComponent<Buff>().multiplyRangeLvl5a = float.Parse(Buff.Attributes.GetNamedItem("MultiplyRange").Value);
                            }
                            if (lvl[e] == "5B")
                            {
                                tower[i].GetComponent<Buff>().multiplyRangeLvl5b = float.Parse(Buff.Attributes.GetNamedItem("MultiplyRange").Value);
                                tower[i].GetComponent<Buff>().multiplyDamageLvl5b = float.Parse(Buff.Attributes.GetNamedItem("MultiplyDamage").Value);
                            }
                        }
                    }
                    foreach (XmlNode Tower in xmlDoc.SelectNodes("root/Tower/" + tipe[k] + "/Lvl" + lvl[e]))
                    {
                        if (tower[i].GetComponent<Tower>().tipe == tipe[k] && tower[i].GetComponent<Tower>().lvl == lvl[e])
                        {
                            tower[i].GetComponent<Tower>().price = int.Parse(Tower.Attributes.GetNamedItem("Price").Value);
                            tower[i].GetComponent<Tower>().health = int.Parse(Tower.Attributes.GetNamedItem("Health").Value);
                            if (Tower.Attributes.GetNamedItem("Damage") != null)
                            {
                                tower[i].GetComponent<Tower>().damageTower = float.Parse(Tower.Attributes.GetNamedItem("Damage").Value);
                            }
                            if (Tower.Attributes.GetNamedItem("Range") != null)
                            {
                                tower[i].GetComponent<Tower>().range = int.Parse(Tower.Attributes.GetNamedItem("Range").Value);
                            }
                            if (Tower.Attributes.GetNamedItem("RateOfFire") != null)
                            {
                                tower[i].GetComponent<Tower>().rateOfFire = int.Parse(Tower.Attributes.GetNamedItem("RateOfFire").Value);
                            }
                            if (Tower.Attributes.GetNamedItem("GoldGet") != null)
                            {
                                tower[i].GetComponent<Tower>().goldGet = float.Parse(Tower.Attributes.GetNamedItem("GoldGet").Value);
                            }
                            if (Tower.Attributes.GetNamedItem("GoldDelay") != null)
                            {
                                tower[i].GetComponent<Tower>().goldDelay = float.Parse(Tower.Attributes.GetNamedItem("GoldDelay").Value);
                            }
                            if (Tower.Attributes.GetNamedItem("PercentOfGold") != null)
                            {
                                tower[i].GetComponent<Tower>().percentOfGold = int.Parse(Tower.Attributes.GetNamedItem("PercentOfGold").Value);
                            }
                            if (Tower.Attributes.GetNamedItem("PVO") != null)
                            {
                                tower[i].GetComponent<Tower>().PVO = bool.Parse(Tower.Attributes.GetNamedItem("PVO").Value);
                            }
                            if (Tower.Attributes.GetNamedItem("PNO") != null)
                            {
                                tower[i].GetComponent<Tower>().PNO = bool.Parse(Tower.Attributes.GetNamedItem("PNO").Value);
                            }
                        }
                    }
                }
            }
        }
        for (int i = 0; i < bullet.Length; i++)
        {
            for (int k = 0; k < tipe.Length; k++)
            {
                for (int e = 0; e < lvl.Length; e++)
                {
                    foreach (XmlNode MoveBullet in xmlDoc.SelectNodes("root/Tower/" + tipe[k] + "/Lvl" + lvl[e]))
                    {
                        if (bullet[i].GetComponent<MoveBullet>().tipe == tipe[k] && bullet[i].GetComponent<MoveBullet>().lvl == lvl[e])
                        {
                            bullet[i].GetComponent<MoveBullet>().speed = float.Parse(MoveBullet.Attributes.GetNamedItem("SpeedBullet").Value);
                            if (MoveBullet.Attributes.GetNamedItem("RangeSplash") != null)
                            {
                                bullet[i].GetComponent<MoveBullet>().rangeSplash = int.Parse(MoveBullet.Attributes.GetNamedItem("RangeSplash").Value);
                            }
                            if (MoveBullet.Attributes.GetNamedItem("FreezeTime") != null)
                            {
                                bullet[i].GetComponent<MoveBullet>().freezeTime = float.Parse(MoveBullet.Attributes.GetNamedItem("FreezeTime").Value);
                            }
                            if (MoveBullet.Attributes.GetNamedItem("DecelerationIn") != null)
                            {
                                bullet[i].GetComponent<MoveBullet>().decelerationIn = float.Parse(MoveBullet.Attributes.GetNamedItem("DecelerationIn").Value);
                            }
                            if (MoveBullet.Attributes.GetNamedItem("Freeze") != null)
                            {
                                bullet[i].GetComponent<MoveBullet>().Freeze = bool.Parse(MoveBullet.Attributes.GetNamedItem("Freeze").Value);
                            }
                            if (MoveBullet.Attributes.GetNamedItem("Strong") != null)
                            {
                                bullet[i].GetComponent<MoveBullet>().Strong = bool.Parse(MoveBullet.Attributes.GetNamedItem("Strong").Value);
                            }
                            if (MoveBullet.Attributes.GetNamedItem("PVOEnemy") != null)
                            {
                                bullet[i].GetComponent<MoveBullet>().PVO = bool.Parse(MoveBullet.Attributes.GetNamedItem("PVOEnemy").Value);
                            }
                            if (MoveBullet.Attributes.GetNamedItem("Splash") != null)
                            {
                                bullet[i].GetComponent<MoveBullet>().Splash = bool.Parse(MoveBullet.Attributes.GetNamedItem("Splash").Value);
                            }
                            if (MoveBullet.Attributes.GetNamedItem("Fire") != null)
                            {
                                bullet[i].GetComponent<MoveBullet>().Fire = bool.Parse(MoveBullet.Attributes.GetNamedItem("Fire").Value);
                            }
                        }
                    }
                }
            }
        }
        for (int i = 0; i < enemy.Length; i++)
        {

            foreach (XmlNode speedAttack in xmlDoc.SelectNodes("root/Enemy"))
            {
                enemy[i].GetComponent<Enemy>().speedAttack = float.Parse(speedAttack.Attributes.GetNamedItem("SpeedAttack").Value);
            }
            foreach (XmlNode SpashFire in xmlDoc.SelectNodes("root/Tower/Splash/Lvl5B"))
            {
                enemy[i].GetComponent<Enemy>().fireDamage = float.Parse(SpashFire.Attributes.GetNamedItem("FireDamage").Value);
                enemy[i].GetComponent<Enemy>().timeFire = float.Parse(SpashFire.Attributes.GetNamedItem("TimeFire").Value);
                enemy[i].GetComponent<Enemy>().damageRetryTime = float.Parse(SpashFire.Attributes.GetNamedItem("DamageRetryTime").Value);
            }
            foreach (XmlNode Golg in xmlDoc.SelectNodes("root/Tower/Gold/Lvl5B"))
            {
                enemy[i].GetComponent<Enemy>().percentOfEnemy = int.Parse(Golg.Attributes.GetNamedItem("PercentOfEnemy").Value);
            }
            for (int k = 0; k < tipeEnemy.Length; k++)
            {
                for (int e = 0; e < lvlEnemy.Length; e++)
                {
                    for (int f = 0; f < lvl.Length; f++)
                    {
                        foreach (XmlNode Debuff in xmlDoc.SelectNodes("root/Tower/Debuff/Lvl" + lvl[f]))
                        {
                            if (lvl[f] == "1")
                            {
                                enemy[i].GetComponent<Debuff>().dbHp1Lvl = float.Parse(Debuff.Attributes.GetNamedItem("DebuffHp").Value);
                            }
                            if (lvl[f] == "2")
                            {
                                enemy[i].GetComponent<Debuff>().dbHp2Lvl = float.Parse(Debuff.Attributes.GetNamedItem("DebuffHp").Value);
                                enemy[i].GetComponent<Debuff>().poisonDamage2Lvl = float.Parse(Debuff.Attributes.GetNamedItem("PoisonDamage").Value);
                                enemy[i].GetComponent<Enemy>().timeBetweenDamage = float.Parse(Debuff.Attributes.GetNamedItem("TimeBetweenDamage").Value);
                            }
                            if (lvl[f] == "3")
                            {
                                enemy[i].GetComponent<Debuff>().dbHp3Lvl = float.Parse(Debuff.Attributes.GetNamedItem("DebuffHp").Value);
                                enemy[i].GetComponent<Debuff>().poisonDamage3Lvl = float.Parse(Debuff.Attributes.GetNamedItem("PoisonDamage").Value);
                                enemy[i].GetComponent<Debuff>().timeBetweenDamage3Lvl = float.Parse(Debuff.Attributes.GetNamedItem("TimeBetweenDamage").Value);
                                enemy[i].GetComponent<Debuff>().dbSpeed3Lvl = float.Parse(Debuff.Attributes.GetNamedItem("DbSpeed").Value);
                            }
                            if (lvl[f] == "4")
                            {
                                enemy[i].GetComponent<Debuff>().dbHp4Lvl = float.Parse(Debuff.Attributes.GetNamedItem("DebuffHp").Value);
                                enemy[i].GetComponent<Debuff>().poisonDamage4Lvl = float.Parse(Debuff.Attributes.GetNamedItem("PoisonDamage").Value);
                                enemy[i].GetComponent<Debuff>().timeBetweenDamage4Lvl = float.Parse(Debuff.Attributes.GetNamedItem("TimeBetweenDamage").Value);
                                enemy[i].GetComponent<Debuff>().dbSpeed4Lvl = float.Parse(Debuff.Attributes.GetNamedItem("DbSpeed").Value);
                            }
                            if (lvl[f] == "5A")
                            {
                                enemy[i].GetComponent<Debuff>().dbHp5aLvl = float.Parse(Debuff.Attributes.GetNamedItem("DebuffHp").Value);
                                enemy[i].GetComponent<Debuff>().poisonDamage5aLvl = float.Parse(Debuff.Attributes.GetNamedItem("PoisonDamage").Value);
                                enemy[i].GetComponent<Debuff>().timeBetweenDamage5aLvl = float.Parse(Debuff.Attributes.GetNamedItem("TimeBetweenDamage").Value);
                                enemy[i].GetComponent<Debuff>().dbSpeed5aLvl = float.Parse(Debuff.Attributes.GetNamedItem("DbSpeed").Value);
                            }
                            if (lvl[f] == "5B")
                            {
                                enemy[i].GetComponent<Debuff>().dbHp5bLvl = float.Parse(Debuff.Attributes.GetNamedItem("DebuffHp").Value);
                                enemy[i].GetComponent<Debuff>().poisonDamage5bLvl = float.Parse(Debuff.Attributes.GetNamedItem("PoisonDamage").Value);
                                enemy[i].GetComponent<Debuff>().timeBetweenDamage5bLvl = float.Parse(Debuff.Attributes.GetNamedItem("TimeBetweenDamage").Value);
                                enemy[i].GetComponent<Debuff>().dbSpeed5bLvl = float.Parse(Debuff.Attributes.GetNamedItem("DbSpeed").Value);
                            }
                        }
                    }
                    foreach (XmlNode Enemy in xmlDoc.SelectNodes("root/Enemy/" + tipeEnemy[k] + "/Lvl" + lvlEnemy[e]))
                    {
                        if (enemy[i].GetComponent<Enemy>().tipe == tipeEnemy[k] && enemy[i].GetComponent<Enemy>().lvl == lvlEnemy[e])
                        {
                            enemy[i].GetComponent<Enemy>().health = float.Parse(Enemy.Attributes.GetNamedItem("Health").Value);
                            enemy[i].GetComponent<Enemy>().speed = float.Parse(Enemy.Attributes.GetNamedItem("Speed").Value);
                            enemy[i].GetComponent<Enemy>().gold = int.Parse(Enemy.Attributes.GetNamedItem("Gold").Value);
                            enemy[i].GetComponent<Enemy>().damageEnemy = int.Parse(Enemy.Attributes.GetNamedItem("Damage").Value);
                        }
                    }
                }
            }
        }

    }
}
