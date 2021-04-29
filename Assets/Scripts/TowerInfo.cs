using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfo : MonoBehaviour
{
    public Text now;
    public Text descriptionNow;
    public Text up;
    public Text descriptionUp;
    public GameObject panel;
    public GameObject button;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject infoTarget;
    public GameObject target;
    public GameObject levelUp;
    int nowHealth;
    int nowRate;
    int nowRange;
    int upHealth;
    int upRate;
    int upRange;
    int nowGoldGet;
    int nowGoldDelay;
    int upGoldGet;
    int upGoldDelay;
    int nowPrice;
    int upPrice;
    //[SerializeField][HideInInspector][NonSerialized]
    void Update()
    {

        target = GetComponentInChildren<RayCast>().target;
        infoTarget = GetComponentInChildren<RayCast>().infoTarget;

        if (infoTarget != null)
        {
            if (infoTarget.tag == "Tower")
            {
                infoTower();
            }
            else if (infoTarget.tag == "TowerFreeze")
            {
                infoTowerFreeze();
            }
            else if (infoTarget.tag == "TowerTank")
            {
                infoTowerTank();
            }
            else if (infoTarget.tag == "TowerPVO")
            {
                infoTowerPVO();
            }
            else if (infoTarget.tag == "TowerBuff")
            {
                infoTowerBuff();
            }
            else if (infoTarget.tag == "TowerSplash")
            {
                infoTowerSplash();
            }
            else if (infoTarget.tag == "TowerDebuff")
            {
                infoTowerDebuff();
            }
            else if (infoTarget.tag == "TowerGold")
            {
                infoTowerGold();
            }
        }
        if (target != null)
        {
            if (target.tag == "Tower")
            {
                Tower();
            }
            else if (target.tag == "TowerFreeze")
            {
                TowerFreeze();
            }
            else if (target.tag == "TowerTank")
            {
                TowerTank();
            }
            else if (target.tag == "TowerPVO")
            {
                TowerPVO();
            }
            else if (target.tag == "TowerBuff")
            {
                TowerBuff();
            }
            else if (target.tag == "TowerSplash")
            {
                TowerSplash();
            }
            else if (target.tag == "TowerDebuff")
            {
                TowerDebuff();
            }
            else if (target.tag == "TowerGold")
            {
                TowerGold();
            }


            if (target.GetComponent<Lvl4>())
            {
                button3.SetActive(true);
                button4.SetActive(true);
            }
            else
            {
                button3.SetActive(false);
                button4.SetActive(false);

            }
        }

        else if (infoTarget == null)
        {
            levelUp = null;
            now.gameObject.SetActive(false);
            descriptionNow.gameObject.SetActive(false);
            up.gameObject.SetActive(false);
            descriptionUp.gameObject.SetActive(false);
            button.SetActive(false);
            button2.SetActive(false);
            target = null;
        }

        if (target == null)
        {
            up.gameObject.SetActive(false);
            descriptionUp.gameObject.SetActive(false);
            button.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
        }
        
        if (levelUp == null)
        {
            up.gameObject.SetActive(false);
            descriptionUp.gameObject.SetActive(false);
            button.SetActive(false);
        }
    }

    public void active()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);
        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<Tower>().health;
        nowRate = target.GetComponent<Tower>().rateOfFire;
        nowRange = target.GetComponent<Tower>().range;
        nowPrice = target.GetComponent<Tower>().price;
        levelUp = target.GetComponent<Tower>().levelUp;
        button2.SetActive(true);

        if (levelUp != null)
        {
            up.gameObject.SetActive(true);
            descriptionUp.gameObject.SetActive(true);
            up.text = levelUp.GetComponent<Text>().text;
            upHealth = levelUp.GetComponent<Tower>().health;
            upPrice = levelUp.GetComponent<Tower>().price;
            button.SetActive(true);
        }
    }
    public void infoActive()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);
        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<Tower>().health;
        nowRate = infoTarget.GetComponent<Tower>().rateOfFire;
        nowRange = infoTarget.GetComponent<Tower>().range;
        nowPrice = infoTarget.GetComponent<Tower>().price;
    }

    public void Tower()
    {
        active();
        descriptionNow.text = now.text + " attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";

        if (target.GetComponent<Tower>().levelUp != null)
        {
            descriptionUp.text = up.text + " attacks 1 enemy, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells. Price: " + upPrice + " gold.";
        }
    }
    public void TowerFreeze()
    {
        active();
        descriptionNow.text = now.text + " slows down enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";

        if (target.GetComponent<Tower>().levelUp != null)
        {
            descriptionUp.text = up.text + " slows down enemies, attacks 1 enemy, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells. Price: " + upPrice + " gold.";
        }
    }
    public void TowerBuff()
    {
        active();
        descriptionNow.text = now.text + " does not attack, buffs towers around itself 3x3 cells, has " + nowHealth + " health. Price: " + nowPrice + " gold.";

        if (target.GetComponent<Tower>().levelUp != null)
        {
            descriptionUp.text = up.text + " does not attack, buffs towers around itself 3x3 cells, has " + upHealth + " health. Price: " + upPrice + " gold.";
        }
    }
    public void TowerPVO()
    {
        active();
        descriptionNow.text = now.text + " attacks only flying enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";

        if (target.GetComponent<Tower>().levelUp != null)
        {
            descriptionUp.text = up.text + " attacks only flying enemies, attacks 1 enemy, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells. Price: " + upPrice + " gold.";
        }
    }
    public void TowerTank()
    {
        active();
        descriptionNow.text = now.text + " does not attack, has " + nowHealth + " health. Price: " + nowPrice + " gold.";

        if (target.GetComponent<Tower>().levelUp != null)
        {
            descriptionUp.text = up.text + " does not attack, has " + upHealth + " health. Price: " + upPrice + " gold.";
        }
    }
    public void TowerSplash()
    {
        active();
        descriptionNow.text = now.text + " attacks 1 enemy and touches several enemies behind him, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";

        if (target.GetComponent<Tower>().levelUp != null)
        {
            descriptionUp.text = up.text + " attacks 1 enemy and touches several enemies behind him, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells. Price: " + upPrice + " gold.";
        }
    }
    public void TowerDebuff()
    {
        active();
        descriptionNow.text = now.text + " does not attack, debuffs enemies 3x3 cells in front of him, has " + nowHealth + " health. Price: " + nowPrice + " gold.";

        if (target.GetComponent<Tower>().levelUp != null)
        {
            descriptionUp.text = up.text + " does not attack, debuffs enemies 3x3 cells in front of him, has " + upHealth + " health. Price: " + upPrice + " gold.";
        }
    }
    public void TowerGold()
    {
        active();
        descriptionNow.text = now.text + " adds " + nowGoldGet + " gold in " + nowGoldDelay + " second, does not attack, has " + nowHealth + " health. Price: " + nowPrice + " gold.";

        if (target.GetComponent<Tower>().levelUp != null)
        {
            descriptionUp.text = up.text + " adds " + upGoldGet + " gold in " + upGoldDelay + " second, does not attack, has " + upHealth + " health. Price: " + upPrice + " gold.";
        }
    }
    public void infoTower()
    {
        infoActive();
        button2.SetActive(true);
        descriptionNow.text = now.text + " attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";
    }
    public void infoTowerFreeze()
    {
        infoActive();
        button2.SetActive(true);
        descriptionNow.text = now.text + " slows down enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold. Price: " + nowPrice + " gold.";
    }
    public void infoTowerBuff()
    {
        infoActive();
        button2.SetActive(true);
        descriptionNow.text = now.text + " does not attack, buffs towers around itself 3x3 cells, has " + nowHealth + " health. Price: " + nowPrice + " gold. Price: " + nowPrice + " gold.";
    }
    public void infoTowerPVO()
    {
        infoActive();
        button2.SetActive(true);
        descriptionNow.text = now.text + " attacks only flying enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold. Price: " + nowPrice + " gold.";
    }
    public void infoTowerTank()
    {
        infoActive();
        button2.SetActive(true);
        descriptionNow.text = now.text + " does not attack, has " + nowHealth + " health. Price: " + nowPrice + " gold.";
    }
    public void infoTowerSplash()
    {
        infoActive();
        button2.SetActive(true);
        descriptionNow.text = now.text + " attacks 1 enemy and touches several enemies behind him, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";
    }
    public void infoTowerDebuff()
    {
        infoActive();
        button2.SetActive(true);
        descriptionNow.text = now.text + " does not attack, debuffs enemies 3x3 cells in front of him, has " + nowHealth + " health. Price: " + nowPrice + " gold.";
    }
    public void infoTowerGold()
    {
        infoActive();
        button2.SetActive(true);
        descriptionNow.text = now.text + " adds " + nowGoldGet + " gold in " + nowGoldDelay + " second, does not attack, has " + nowHealth + " health. Price: " + nowPrice + " gold.";
    }
}


