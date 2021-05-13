using System.Collections;
using System.Collections.Generic;
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
                    foreach (XmlNode Tower in xmlDoc.SelectNodes("root/Tower/" + tipe[k] + "/Lvl" + lvl[e]))
                    {
                        if (tower[i].GetComponent<Tower>().tipe == tipe[k] && tower[i].GetComponent<Tower>().lvl == lvl[e])
                        {
                            tower[i].GetComponent<Tower>().price = int.Parse(Tower.Attributes.GetNamedItem("Price").Value);
                            tower[i].GetComponent<Tower>().health = int.Parse(Tower.Attributes.GetNamedItem("Health").Value);
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
                            if (Tower.Attributes.GetNamedItem("DebuffHp") != null)
                            {
                                tower[i].GetComponent<Tower>().debuffHp = int.Parse(Tower.Attributes.GetNamedItem("DebuffHp").Value);
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
                            bullet[i].GetComponent<MoveBullet>().damageTower = float.Parse(MoveBullet.Attributes.GetNamedItem("Damage").Value);
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
                        }
                    }
                }
            }
        }
        for (int i = 0; i < enemy.Length; i++)
        {
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
                    foreach (XmlNode Enemy in xmlDoc.SelectNodes("root/Enemy/" + tipeEnemy[k] + "/Lvl" + lvlEnemy[e]))
                    {
                        if (enemy[i].GetComponent<Enemy>().tipe == tipeEnemy[k] && enemy[i].GetComponent<Enemy>().lvl == lvlEnemy[e])
                        {
                            enemy[i].GetComponent<Enemy>().health = float.Parse(Enemy.Attributes.GetNamedItem("Health").Value);
                            enemy[i].GetComponent<Enemy>().speed = float.Parse(Enemy.Attributes.GetNamedItem("Speed").Value);
                            enemy[i].GetComponent<Enemy>().gold = int.Parse(Enemy.Attributes.GetNamedItem("Gold").Value);
                        }
                    }
                }
            }
        }

    }
}
