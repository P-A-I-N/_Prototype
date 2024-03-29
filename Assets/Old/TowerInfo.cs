﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfo : MonoBehaviour
{
    public Text damage;
    public Text range;
    public Text health;
    public Text price;
    public Text speed;
    public Text effect;
    public GameObject panel;
    public GameObject up;
    public GameObject panel3;
    public GameObject targetI;
    public GameObject target;
    public GameObject levelUp;
    public GameObject del;
    public GameObject _camera;
    private void Update()
    {
        target = _camera.GetComponent<RayCast>().target;
        targetI = _camera.GetComponent<RayCast>().infoTarget;
        if (targetI != null)
        {
            panel.SetActive(true);
            up.SetActive(false);
            del.SetActive(false);
            panel3.SetActive(false);

            damage.text = "" + targetI.GetComponent<Tower_old>().damageTower;
            range.text = "" + targetI.GetComponent<Tower_old>().range;
            health.text = "" + targetI.GetComponent<Tower_old>().health;
            price.text = "" + targetI.GetComponent<Tower_old>().price;
            speed.text = "1 in " + targetI.GetComponent<Tower_old>().rateOfFire + " sec";
            effect.text = "" + targetI.GetComponent<Tower_old>().nameTower.text;
        }
        else if (target != null)
        {
            panel.SetActive(true);

            if (target.GetComponent<Tower_old>().lvl4)
            {
                if (target.GetComponent<Tower_old>().levelUp == null)
                {
                    up.SetActive(false);
                    damage.text = "";
                    range.text = "";
                    health.text = "";
                    speed.text = "";
                    price.text = "";
                    effect.text = "";
                }

                panel3.SetActive(true);

                if (target.GetComponent<Tower_old>().levelUp != null)
                {
                    up.SetActive(true);
                    damage.text = "" + target.GetComponent<Tower_old>().damageTower + "➜" + target.GetComponent<Tower_old>().levelUp.GetComponent<Tower_old>().damageTower;
                    range.text = "" + target.GetComponent<Tower_old>().range + "➜" + target.GetComponent<Tower_old>().levelUp.GetComponent<Tower_old>().range;
                    health.text = "" + target.GetComponent<Tower_old>().health + "➜" + target.GetComponent<Tower_old>().levelUp.GetComponent<Tower_old>().health;
                    price.text = "" + target.GetComponent<Tower_old>().price + "➜" + target.GetComponent<Tower_old>().levelUp.GetComponent<Tower_old>().price;
                    speed.text = "1 in " + target.GetComponent<Tower_old>()._rateOfFire + "➜" + target.GetComponent<Tower_old>().levelUp.GetComponent<Tower_old>().rateOfFire + " sec";
                    effect.text = "➜" + target.GetComponent<Tower_old>().levelUp.GetComponent<Tower_old>().nameTower.text;
                }

            }
            else
            {
                if (target.GetComponent<Tower_old>().levelUp != null)
                {

                    up.SetActive(true);
                    del.SetActive(true);
                    panel3.SetActive(false);

                    damage.text = "" + target.GetComponent<Tower_old>().damageTower + "➜" + target.GetComponent<Tower_old>().levelUp.GetComponent<Tower_old>().damageTower;
                    range.text = "" + target.GetComponent<Tower_old>().range + "➜" + target.GetComponent<Tower_old>().levelUp.GetComponent<Tower_old>().range;
                    health.text = "" + target.GetComponent<Tower_old>().health + "➜" + target.GetComponent<Tower_old>().levelUp.GetComponent<Tower_old>().health;
                    price.text = "" + target.GetComponent<Tower_old>().price + "➜" + target.GetComponent<Tower_old>().levelUp.GetComponent<Tower_old>().price;
                    speed.text = "1 in " + target.GetComponent<Tower_old>()._rateOfFire + "➜" + target.GetComponent<Tower_old>().levelUp.GetComponent<Tower_old>().rateOfFire + " sec";
                    effect.text = "➜" + target.GetComponent<Tower_old>().levelUp.GetComponent<Tower_old>().nameTower.text;
                }
                else
                {
                    up.SetActive(false);
                    del.SetActive(true);
                    panel3.SetActive(false);
                    damage.text = "" + target.GetComponent<Tower_old>().damageTower;
                    range.text = "" + target.GetComponent<Tower_old>().range;
                    health.text = "" + target.GetComponent<Tower_old>().health;
                    price.text = "" + target.GetComponent<Tower_old>().price;
                    speed.text = "1 in " + target.GetComponent<Tower_old>()._rateOfFire + " sec";
                    effect.text = "" + target.GetComponent<Tower_old>().nameTower.text;
                }
            }
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
//    void Update()
//    {

//        target = GetComponentInChildren<RayCast>().target;
//        infoTarget = GetComponentInChildren<RayCast>().infoTarget;

//        if (infoTarget != null)
//        {
//        //    if (infoTarget.tag == "Tower")
//        //    {
//        //        infoTower();
//        //    }
//        //    else if (infoTarget.tag == "TowerFreeze")
//        //    {
//        //        infoTowerFreeze();
//        //    }
//        //    else if (infoTarget.tag == "TowerTank")
//        //    {
//        //        infoTowerTank();
//        //    }
//        //    else if (infoTarget.tag == "TowerPVO")
//        //    {
//        //        infoTowerPVO();
//        //    }
//        //    else if (infoTarget.tag == "TowerBuff")
//        //    {
//        //        infoTowerBuff();
//        //    }
//        //    else if (infoTarget.tag == "TowerSplash")
//        //    {
//        //        infoTowerSplash();
//        //    }
//        //    else if (infoTarget.tag == "TowerDebuff")
//        //    {
//        //        infoTowerDebuff();
//        //    }
//        //    else if (infoTarget.tag == "TowerGold")
//        //    {
//        //        infoTowerGold();
//        //    }
//        //}
//        //if (target != null)
//        //{
//        //    if (target.tag == "Tower")
//        //    {
//        //        Tower();
//        //    }
//        //    else if (target.tag == "TowerFreeze")
//        //    {
//        //        TowerFreeze();
//        //    }
//        //    else if (target.tag == "TowerTank")
//        //    {
//        //        TowerTank();
//        //    }
//        //    else if (target.tag == "TowerPVO")
//        //    {
//        //        TowerPVO();
//        //    }
//        //    else if (target.tag == "TowerBuff")
//        //    {
//        //        TowerBuff();
//        //    }
//        //    else if (target.tag == "TowerSplash")
//        //    {
//        //        TowerSplash();
//        //    }
//        //    else if (target.tag == "TowerDebuff")
//        //    {
//        //        TowerDebuff();
//        //    }
//        //    else if (target.tag == "TowerGold")
//        //    {
//        //        TowerGold();
//        //    }


//            if (target.GetComponent<Lvl4>())
//            {
//                button3.SetActive(true);
//                button4.SetActive(true);
//            }
//            else
//            {
//                button3.SetActive(false);
//                button4.SetActive(false);

//            }
//        }

//        else if (infoTarget == null)
//        {
//            levelUp = null;
//            button.SetActive(false);
//            button2.SetActive(false);
//            target = null;
//        }

//        if (target == null)
//        {

//            button.SetActive(false);
//            button2.SetActive(false);
//            button3.SetActive(false);
//            button4.SetActive(false);
//        }

//        if (levelUp == null)
//        {
//            button.SetActive(false);
//        }
//    }

//    public void active()
//    {
//        nowHealth = target.GetComponent<Tower>().health;
//        nowRate = target.GetComponent<Tower>().rateOfFire;
//        nowRange = target.GetComponent<Tower>().range;
//        nowPrice = target.GetComponent<Tower>().price;
//        levelUp = target.GetComponent<Tower>().levelUp;
//        button2.SetActive(true);

//        if (levelUp != null)
//        {
//            upHealth = levelUp.GetComponent<Tower>().health;
//            upPrice = levelUp.GetComponent<Tower>().price;
//            button.SetActive(true);
//        }
//    }
//    public void infoActive()
//    {
//        nowHealth = infoTarget.GetComponent<Tower>().health;
//        nowRate = infoTarget.GetComponent<Tower>().rateOfFire;
//        nowRange = infoTarget.GetComponent<Tower>().range;
//        nowPrice = infoTarget.GetComponent<Tower>().price;
//    }
//}

//    public void Tower()
//    {
//        active();
//        descriptionNow.text = now.text + " attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";

//        if (target.GetComponent<Tower>().levelUp != null)
//        {
//            descriptionUp.text = up.text + " attacks 1 enemy, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells. Price: " + upPrice + " gold.";
//        }
//    }
//    public void TowerFreeze()
//    {
//        active();
//        descriptionNow.text = now.text + " slows down enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";

//        if (target.GetComponent<Tower>().levelUp != null)
//        {
//            descriptionUp.text = up.text + " slows down enemies, attacks 1 enemy, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells. Price: " + upPrice + " gold.";
//        }
//    }
//    public void TowerBuff()
//    {
//        active();
//        descriptionNow.text = now.text + " does not attack, buffs towers around itself 3x3 cells, has " + nowHealth + " health. Price: " + nowPrice + " gold.";

//        if (target.GetComponent<Tower>().levelUp != null)
//        {
//            descriptionUp.text = up.text + " does not attack, buffs towers around itself 3x3 cells, has " + upHealth + " health. Price: " + upPrice + " gold.";
//        }
//    }
//    public void TowerPVO()
//    {
//        active();
//        descriptionNow.text = now.text + " attacks only flying enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";

//        if (target.GetComponent<Tower>().levelUp != null)
//        {
//            descriptionUp.text = up.text + " attacks only flying enemies, attacks 1 enemy, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells. Price: " + upPrice + " gold.";
//        }
//    }
//    public void TowerTank()
//    {
//        active();
//        descriptionNow.text = now.text + " does not attack, has " + nowHealth + " health. Price: " + nowPrice + " gold.";

//        if (target.GetComponent<Tower>().levelUp != null)
//        {
//            descriptionUp.text = up.text + " does not attack, has " + upHealth + " health. Price: " + upPrice + " gold.";
//        }
//    }
//    public void TowerSplash()
//    {
//        active();
//        descriptionNow.text = now.text + " attacks 1 enemy and touches several enemies behind him, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";

//        if (target.GetComponent<Tower>().levelUp != null)
//        {
//            descriptionUp.text = up.text + " attacks 1 enemy and touches several enemies behind him, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells. Price: " + upPrice + " gold.";
//        }
//    }
//    public void TowerDebuff()
//    {
//        active();
//        descriptionNow.text = now.text + " does not attack, debuffs enemies 3x3 cells in front of him, has " + nowHealth + " health. Price: " + nowPrice + " gold.";

//        if (target.GetComponent<Tower>().levelUp != null)
//        {
//            descriptionUp.text = up.text + " does not attack, debuffs enemies 3x3 cells in front of him, has " + upHealth + " health. Price: " + upPrice + " gold.";
//        }
//    }
//    public void TowerGold()
//    {
//        active();
//        descriptionNow.text = now.text + " adds " + nowGoldGet + " gold in " + nowGoldDelay + " second, does not attack, has " + nowHealth + " health. Price: " + nowPrice + " gold.";

//        if (target.GetComponent<Tower>().levelUp != null)
//        {
//            descriptionUp.text = up.text + " adds " + upGoldGet + " gold in " + upGoldDelay + " second, does not attack, has " + upHealth + " health. Price: " + upPrice + " gold.";
//        }
//    }
//    public void infoTower()
//    {
//        infoActive();
//        button2.SetActive(true);
//        descriptionNow.text = now.text + " attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";
//    }
//    public void infoTowerFreeze()
//    {
//        infoActive();
//        button2.SetActive(true);
//        descriptionNow.text = now.text + " slows down enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold. Price: " + nowPrice + " gold.";
//    }
//    public void infoTowerBuff()
//    {
//        infoActive();
//        button2.SetActive(true);
//        descriptionNow.text = now.text + " does not attack, buffs towers around itself 3x3 cells, has " + nowHealth + " health. Price: " + nowPrice + " gold. Price: " + nowPrice + " gold.";
//    }
//    public void infoTowerPVO()
//    {
//        infoActive();
//        button2.SetActive(true);
//        descriptionNow.text = now.text + " attacks only flying enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold. Price: " + nowPrice + " gold.";
//    }
//    public void infoTowerTank()
//    {
//        infoActive();
//        button2.SetActive(true);
//        descriptionNow.text = now.text + " does not attack, has " + nowHealth + " health. Price: " + nowPrice + " gold.";
//    }
//    public void infoTowerSplash()
//    {
//        infoActive();
//        button2.SetActive(true);
//        descriptionNow.text = now.text + " attacks 1 enemy and touches several enemies behind him, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";
//    }
//    public void infoTowerDebuff()
//    {
//        infoActive();
//        button2.SetActive(true);
//        descriptionNow.text = now.text + " does not attack, debuffs enemies 3x3 cells in front of him, has " + nowHealth + " health. Price: " + nowPrice + " gold.";
//    }
//    public void infoTowerGold()
//    {
//        infoActive();
//        button2.SetActive(true);
//        descriptionNow.text = now.text + " adds " + nowGoldGet + " gold in " + nowGoldDelay + " second, does not attack, has " + nowHealth + " health. Price: " + nowPrice + " gold.";
//    }
//}


