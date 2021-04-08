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
    int nowAmount;
    int nowHealth;
    int nowRate;
    int nowRange;
    public GameObject levelUp;
    int upAmount;
    int upHealth;
    int upRate;
    int upRange;
    bool towerUp;


    void Update()
    {

        target = GetComponentInChildren<RayCast>().target;
        infoTarget = GetComponentInChildren<RayCast>().infoTarget;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    now.gameObject.SetActive(false);
        //    descriptionNow.gameObject.SetActive(false);
        //    up.gameObject.SetActive(false);
        //    descriptionUp.gameObject.SetActive(false);
        //    button.SetActive(false);
        //    button2.SetActive(false);
        //}
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

    public void Tower()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);
        up.gameObject.SetActive(true);
        descriptionUp.gameObject.SetActive(true);
        button.SetActive(true);
        button2.SetActive(true);

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<Tower>().health;
        nowRate = target.GetComponent<Tower>().rateOfFire;
        nowRange = target.GetComponent<Tower>().range;
        descriptionNow.text = now.text + " attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells.";

        levelUp = target.GetComponent<Tower>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<Tower>().health;
        upRate = levelUp.GetComponent<Tower>().rateOfFire;
        upRange = levelUp.GetComponent<Tower>().range;
        descriptionUp.text = up.text + " attacks 1 enemy, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells.";
    }
    public void TowerFreeze()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);
        up.gameObject.SetActive(true);
        descriptionUp.gameObject.SetActive(true);
        button.SetActive(true);
        button2.SetActive(true);

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<TowerFreeze>().health;
        nowRate = target.GetComponent<TowerFreeze>().rateOfFire;
        nowRange = target.GetComponent<TowerFreeze>().range;
        descriptionNow.text = now.text + " slows down enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells.";

        levelUp = target.GetComponent<TowerFreeze>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<TowerFreeze>().health;
        upRate = levelUp.GetComponent<TowerFreeze>().rateOfFire;
        upRange = levelUp.GetComponent<TowerFreeze>().range;
        descriptionUp.text = up.text + " slows down enemies, attacks 1 enemy, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells.";
    }
    public void TowerBuff()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);
        up.gameObject.SetActive(true);
        descriptionUp.gameObject.SetActive(true);
        button.SetActive(true);
        button2.SetActive(true);

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<TowerBuff>().health;
        descriptionNow.text = now.text + " does not attack, buffa towers in 3x3 cells, has " + nowHealth + " health.";

        levelUp = target.GetComponent<TowerBuff>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<TowerBuff>().health;
        descriptionUp.text = up.text + " does not attack, buffa towers in 3x3 cells, has " + upHealth + " health.";
    }
    public void TowerPVO()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);
        up.gameObject.SetActive(true);
        descriptionUp.gameObject.SetActive(true);
        button.SetActive(true);
        button2.SetActive(true);

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<TowerPVO>().health;
        nowRate = target.GetComponent<TowerPVO>().rateOfFire;
        nowRange = target.GetComponent<TowerPVO>().range;
        descriptionNow.text = now.text + " attacks only flying enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells.";

        levelUp = target.GetComponent<TowerPVO>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<TowerPVO>().health;
        upRate = levelUp.GetComponent<TowerPVO>().rateOfFire;
        upRange = levelUp.GetComponent<TowerPVO>().range;
        descriptionUp.text = up.text + " attacks only flying enemies, attacks 1 enemy, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells.";
    }
    public void TowerTank()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);
        up.gameObject.SetActive(true);
        descriptionUp.gameObject.SetActive(true);
        button.SetActive(true);
        button2.SetActive(true);

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<TowerTank>().health;
        descriptionNow.text = now.text + " does not attack, has " + nowHealth + " health.";

        levelUp = target.GetComponent<TowerTank>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<TowerTank>().health;
        descriptionUp.text = up.text + " does not attack, has " + upHealth + " health.";
    }
    public void TowerSplash()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);
        up.gameObject.SetActive(true);
        descriptionUp.gameObject.SetActive(true);
        button.SetActive(true);
        button2.SetActive(true);

        now.text = target.GetComponent<Text>().text;
        nowHealth = target.GetComponent<TowerSplash>().health;
        nowRate = target.GetComponent<TowerSplash>().rateOfFire;
        nowRange = target.GetComponent<TowerSplash>().range;
        descriptionNow.text = now.text + " attacks 1 enemy and touches several enemies behind him, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells.";

        levelUp = target.GetComponent<TowerSplash>().levelUp;
        up.text = levelUp.GetComponent<Text>().text;
        upHealth = levelUp.GetComponent<TowerSplash>().health;
        upRate = levelUp.GetComponent<TowerSplash>().rateOfFire;
        upRange = levelUp.GetComponent<TowerSplash>().range;
        descriptionUp.text = up.text + " attacks 1 enemy and touches several enemies behind him, has " + upHealth + " health, shoots 1 bullet in " + upRate + " seconds, attack range " + upRange + " cells.";
    }
    public void infoTower()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<Tower>().health;
        nowRate = infoTarget.GetComponent<Tower>().rateOfFire;
        nowRange = infoTarget.GetComponent<Tower>().range;
        descriptionNow.text = now.text + " attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells.";
    }
    public void infoTowerFreeze()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<TowerFreeze>().health;
        nowRate = infoTarget.GetComponent<TowerFreeze>().rateOfFire;
        nowRange = infoTarget.GetComponent<TowerFreeze>().range;
        descriptionNow.text = now.text + " slows down enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells.";
    }
    public void infoTowerBuff()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<TowerBuff>().health;
        descriptionNow.text = now.text + " does not attack, buffa towers in 3x3 cells, has " + nowHealth + " health.";
    }
    public void infoTowerPVO()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<TowerPVO>().health;
        nowRate = infoTarget.GetComponent<TowerPVO>().rateOfFire;
        nowRange = infoTarget.GetComponent<TowerPVO>().range;
        descriptionNow.text = now.text + " attacks only flying enemies, attacks 1 enemy, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells.";
    }
    public void infoTowerTank()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<TowerTank>().health;
        descriptionNow.text = now.text + " does not attack, has " + nowHealth + " health.";
    }
    public void infoTowerSplash()
    {
        now.gameObject.SetActive(true);
        descriptionNow.gameObject.SetActive(true);

        now.text = infoTarget.GetComponent<Text>().text;
        nowHealth = infoTarget.GetComponent<TowerSplash>().health;
        nowRate = infoTarget.GetComponent<TowerSplash>().rateOfFire;
        nowRange = infoTarget.GetComponent<TowerSplash>().range;
        descriptionNow.text = now.text + " attacks 1 enemy and touches several enemies behind him, has " + nowHealth + " health, shoots 1 bullet in " + nowRate + " seconds, attack range " + nowRange + " cells.";
    }
}

