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

        if (Input.GetMouseButtonDown(0))
        {
            now.gameObject.SetActive(false);
            descriptionNow.gameObject.SetActive(false);
            up.gameObject.SetActive(false);
            descriptionUp.gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
            button.SetActive(false);
        }

        if (infoTarget != null)
        {
            now.gameObject.SetActive(true);
            descriptionNow.gameObject.SetActive(true);
            panel.gameObject.SetActive(true);

            now.text = infoTarget.GetComponent<Text>().text;
            nowAmount = infoTarget.GetComponent<Tower>().targetAmount;
            nowHealth = infoTarget.GetComponent<Tower>().health;
            nowRate = infoTarget.GetComponent<Tower>().rateOfFire;
            nowRange = infoTarget.GetComponent<Tower>().range;
            descriptionNow.text = now.text + " can attack " + nowAmount + " enemy, has " + nowHealth + " health, shoots at a speed of 1 bullet in " + nowRate + " seconds and an attack radius of " + nowRange + " cells.";
        }

        if (target != null)
        {
            now.gameObject.SetActive(true);
            descriptionNow.gameObject.SetActive(true);
            up.gameObject.SetActive(true);
            descriptionUp.gameObject.SetActive(true);
            panel.gameObject.SetActive(true);
            button.SetActive(true);

            now.text = target.GetComponent<Text>().text;
            nowAmount = target.GetComponent<Tower>().targetAmount;
            nowHealth = target.GetComponent<Tower>().health;
            nowRate = target.GetComponent<Tower>().rateOfFire;
            nowRange = target.GetComponent<Tower>().range;
            descriptionNow.text = now.text + " can attack " + nowAmount + " enemy, has " + nowHealth + " health, shoots at a speed of 1 bullet in " + nowRate + " seconds and an attack radius of " + nowRange + " cells.";

            levelUp = target.GetComponent<Tower>().levelUp;
            up.text = levelUp.GetComponent<Text>().text;
            upAmount = levelUp.GetComponent<Tower>().targetAmount;
            upHealth = levelUp.GetComponent<Tower>().health;
            upRate = levelUp.GetComponent<Tower>().rateOfFire;
            upRange = levelUp.GetComponent<Tower>().range;
            descriptionUp.text = up.text + " can attack " + upAmount + " enemy, has " + upHealth + " health, shoots at a speed of 1 bullet in " + upRate + " seconds and an attack radius of " + upRange + " cells.";
        }
        else if (infoTarget == null)
        {
            levelUp = null;
            now.gameObject.SetActive(false);
            descriptionNow.gameObject.SetActive(false);
            up.gameObject.SetActive(false);
            descriptionUp.gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
            button.SetActive(false);
        }
    }
}
