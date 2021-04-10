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
        else if (target == null)
        {
            up.gameObject.SetActive(false);
            descriptionUp.gameObject.SetActive(false);
            button.SetActive(false);
            button2.SetActive(false);
        }
    }

    public void active()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);
        up.gameObject.SetActive(true);
        descriptionUp.gameObject.SetActive(true);
        button.SetActive(true);
        button2.SetActive(true);
    }
    public void infoActive()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);
    }

    public void Tower()
    {
        active();

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<Tower>().health;
        nowRate = target.GetComponent<Tower>().rateOfFire;
        nowRange = target.GetComponent<Tower>().range;
        nowPrice = target.GetComponent<Tower>().price;
        descriptionNow.text = now.text + " attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";

        levelUp = target.GetComponent<Tower>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<Tower>().health;
        upRate = levelUp.GetComponent<Tower>().rateOfFire;
        upRange = levelUp.GetComponent<Tower>().range;
        upPrice = levelUp.GetComponent<Tower>().price;
        descriptionUp.text = up.text + " attacks 1 enemy, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells. Price: " + upPrice + " gold.";
    }
    public void TowerFreeze()
    {
        active();

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<TowerFreeze>().health;
        nowRate = target.GetComponent<TowerFreeze>().rateOfFire;
        nowRange = target.GetComponent<TowerFreeze>().range;
        nowPrice = target.GetComponent<TowerFreeze>().price;
        descriptionNow.text = now.text + " slows down enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";

        levelUp = target.GetComponent<TowerFreeze>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<TowerFreeze>().health;
        upRate = levelUp.GetComponent<TowerFreeze>().rateOfFire;
        upRange = levelUp.GetComponent<TowerFreeze>().range;
        upPrice = levelUp.GetComponent<TowerFreeze>().price;
        descriptionUp.text = up.text + " slows down enemies, attacks 1 enemy, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells. Price: " + upPrice + " gold.";
    }
    public void TowerBuff()
    {
        active();

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<TowerBuff>().health;
        nowPrice = target.GetComponent<TowerBuff>().price;
        descriptionNow.text = now.text + " does not attack, buffs towers around itself 3x3 cells, has " + nowHealth + " health. Price: " + nowPrice + " gold.";

        levelUp = target.GetComponent<TowerBuff>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<TowerBuff>().health;
        upPrice = levelUp.GetComponent<TowerBuff>().price;
        descriptionUp.text = up.text + " does not attack, buffs towers around itself 3x3 cells, has " + upHealth + " health. Price: " + upPrice + " gold.";
    }
    public void TowerPVO()
    {
        active();

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<TowerPVO>().health;
        nowRate = target.GetComponent<TowerPVO>().rateOfFire;
        nowRange = target.GetComponent<TowerPVO>().range;
        nowPrice = target.GetComponent<TowerPVO>().price;
        descriptionNow.text = now.text + " attacks only flying enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";

        levelUp = target.GetComponent<TowerPVO>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<TowerPVO>().health;
        upRate = levelUp.GetComponent<TowerPVO>().rateOfFire;
        upRange = levelUp.GetComponent<TowerPVO>().range;
        upPrice = levelUp.GetComponent<TowerPVO>().price;
        descriptionUp.text = up.text + " attacks only flying enemies, attacks 1 enemy, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells. Price: " + upPrice + " gold.";
    }
    public void TowerTank()
    {
        active();

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<TowerTank>().health;
        nowPrice = target.GetComponent<TowerTank>().price;
        descriptionNow.text = now.text + " does not attack, has " + nowHealth + " health. Price: " + nowPrice + " gold.";

        levelUp = target.GetComponent<TowerTank>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<TowerTank>().health;
        upPrice = levelUp.GetComponent<TowerTank>().price;
        descriptionUp.text = up.text + " does not attack, has " + upHealth + " health. Price: " + upPrice + " gold.";
    }
    public void TowerSplash()
    {
        active();

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<TowerSplash>().health;
        nowRate = target.GetComponent<TowerSplash>().rateOfFire;
        nowRange = target.GetComponent<TowerSplash>().range;
        nowPrice = target.GetComponent<TowerSplash>().price;
        descriptionNow.text = now.text + " attacks 1 enemy and touches several enemies behind him, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";

        levelUp = target.GetComponent<TowerSplash>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<TowerSplash>().health;
        upRate = levelUp.GetComponent<TowerSplash>().rateOfFire;
        upRange = levelUp.GetComponent<TowerSplash>().range;
        upPrice = levelUp.GetComponent<TowerSplash>().price;
        descriptionUp.text = up.text + " attacks 1 enemy and touches several enemies behind him, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells. Price: " + upPrice + " gold.";
    }
    public void TowerDebuff()
    {
        active();

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<TowerDebuff>().health;
        nowPrice = target.GetComponent<TowerDebuff>().price;
        descriptionNow.text = now.text + " does not attack, debuffs enemies 3x3 cells in front of him, has " + nowHealth + " health. Price: " + nowPrice + " gold.";

        levelUp = target.GetComponent<TowerDebuff>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<TowerDebuff>().health;
        upPrice = levelUp.GetComponent<TowerDebuff>().price;
        descriptionUp.text = up.text + " does not attack, debuffs enemies 3x3 cells in front of him, has " + upHealth + " health. Price: " + upPrice + " gold.";
    }
    public void TowerGold()
    {
        active();

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<TowerGold>().health;
        nowGoldGet = target.GetComponent<TowerGold>().goldGet;
        nowGoldDelay = target.GetComponent<TowerGold>().goldDelay;
        nowPrice = target.GetComponent<TowerGold>().price;
        descriptionNow.text = now.text + " adds " + nowGoldGet + " gold in " + nowGoldDelay + " second, does not attack, has " + nowHealth + " health. Price: " + nowPrice + " gold.";

        levelUp = target.GetComponent<TowerGold>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<TowerGold>().health;
        upGoldGet = levelUp.GetComponent<TowerGold>().goldGet;
        upGoldDelay = levelUp.GetComponent<TowerGold>().goldDelay;
        upPrice = levelUp.GetComponent<TowerGold>().price;
        descriptionUp.text = up.text + " adds " + upGoldGet + " gold in " + upGoldDelay + " second, does not attack, has " + upHealth + " health. Price: " + upPrice + " gold.";
    }
    public void infoTower()
    {
        infoActive();

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<Tower>().health;
        nowRate = infoTarget.GetComponent<Tower>().rateOfFire;
        nowRange = infoTarget.GetComponent<Tower>().range;
        nowPrice = infoTarget.GetComponent<Tower>().price;
        descriptionNow.text = now.text + " attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";
    }
    public void infoTowerFreeze()
    {
        infoActive();

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<TowerFreeze>().health;
        nowRate = infoTarget.GetComponent<TowerFreeze>().rateOfFire;
        nowRange = infoTarget.GetComponent<TowerFreeze>().range;
        nowPrice = infoTarget.GetComponent<TowerFreeze>().price;
        descriptionNow.text = now.text + " slows down enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold. Price: " + nowPrice + " gold.";
    }
    public void infoTowerBuff()
    {
        infoActive();

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<TowerBuff>().health;
        nowPrice = infoTarget.GetComponent<TowerBuff>().price;
        descriptionNow.text = now.text + " does not attack, buffs towers around itself 3x3 cells, has " + nowHealth + " health. Price: " + nowPrice + " gold. Price: " + nowPrice + " gold.";
    }
    public void infoTowerPVO()
    {
        infoActive();

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<TowerPVO>().health;
        nowRate = infoTarget.GetComponent<TowerPVO>().rateOfFire;
        nowRange = infoTarget.GetComponent<TowerPVO>().range;
        nowPrice = infoTarget.GetComponent<TowerPVO>().price;
        descriptionNow.text = now.text + " attacks only flying enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold. Price: " + nowPrice + " gold.";
    }
    public void infoTowerTank()
    {
        infoActive();

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<TowerTank>().health;
        nowPrice = infoTarget.GetComponent<TowerTank>().price;
        descriptionNow.text = now.text + " does not attack, has " + nowHealth + " health. Price: " + nowPrice + " gold.";
    }
    public void infoTowerSplash()
    {
        infoActive();

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<TowerSplash>().health;
        nowRate = infoTarget.GetComponent<TowerSplash>().rateOfFire;
        nowRange = infoTarget.GetComponent<TowerSplash>().range;
        nowPrice = infoTarget.GetComponent<TowerSplash>().price;
        descriptionNow.text = now.text + " attacks 1 enemy and touches several enemies behind him, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells. Price: " + nowPrice + " gold.";
    }
    public void infoTowerDebuff()
    {
        infoActive();

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<TowerDebuff>().health;
        nowPrice = infoTarget.GetComponent<TowerDebuff>().price;
        descriptionNow.text = now.text + " does not attack, debuffs enemies 3x3 cells in front of him, has " + nowHealth + " health. Price: " + nowPrice + " gold.";
    }
    public void infoTowerGold()
    {
        infoActive();

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<TowerGold>().health;
        nowGoldGet = infoTarget.GetComponent<TowerGold>().goldGet;
        nowGoldDelay = infoTarget.GetComponent<TowerGold>().goldDelay;
        nowPrice = infoTarget.GetComponent<TowerGold>().price;
        descriptionNow.text = now.text + " adds " + nowGoldGet + " gold in " + nowGoldDelay + " second, does not attack, has " + nowHealth + " health. Price: " + nowPrice + " gold.";
    }
}


