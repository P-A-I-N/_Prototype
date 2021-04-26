using UnityEngine;

public class RayCast : MonoBehaviour
{
    private Vector3 pos;
    public GameObject[] towers;
    public GameObject target;
    public GameObject infoTarget;
    private GameObject tower;
    private bool delete;
    private LayerMask layerTower = 1 << 8;
    private LayerMask layerPoint = 1 << 7;
    GameMap gm;
    GameObject levelUp;
    bool towerUp;
    Vector2 worldPoint;
    RaycastHit2D hitTower;
    RaycastHit2D hitPoint;
    int price;
    bool damage;

    private void Awake()
    {
        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
    }

    void Update()
    {
        if (target != null && towerUp)
        {
            if (target.tag == "Tower")
            {
                price = target.GetComponent<Tower>().levelUp.GetComponent<Tower>().price;
                levelUp = target.GetComponent<Tower>().levelUp;
                lvlUp();
            }
            if (target.tag == "TowerBuff")
            {
                price = target.GetComponent<Tower>().levelUp.GetComponent<Tower>().price;
                levelUp = target.GetComponent<TowerBuff>().levelUp;
                lvlUp();
            }
            if (target.tag == "TowerFreeze")
            {
                price = target.GetComponent<Tower>().levelUp.GetComponent<Tower>().price;
                levelUp = target.GetComponent<TowerFreeze>().levelUp;
                lvlUp();
            }
            if (target.tag == "TowerPVO")
            {
                price = target.GetComponent<Tower>().levelUp.GetComponent<Tower>().price;
                levelUp = target.GetComponent<TowerPVO>().levelUp;
                lvlUp();
            }
            if (target.tag == "TowerSplash")
            {
                price = target.GetComponent<Tower>().levelUp.GetComponent<Tower>().price;
                levelUp = target.GetComponent<TowerSplash>().levelUp;
                lvlUp();
            }
            if (target.tag == "TowerTank")
            {
                price = target.GetComponent<Tower>().levelUp.GetComponent<Tower>().price;
                levelUp = target.GetComponent<TowerTank>().levelUp;
                lvlUp();
            }
            if (target.tag == "TowerDebuff")
            {
                price = target.GetComponent<Tower>().levelUp.GetComponent<Tower>().price;
                levelUp = target.GetComponent<TowerDebuff>().levelUp;
                lvlUp();
            }
            if (target.tag == "TowerGold")
            {
                price = target.GetComponent<Tower>().levelUp.GetComponent<Tower>().price;
                levelUp = target.GetComponent<TowerGold>().levelUp;
                lvlUp();
            }
            towerUp = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            infoTarget = null;
            target = null;
        }

        worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hitTower = Physics2D.Raycast(worldPoint, Vector2.zero, 100f, layerTower);
        hitPoint = Physics2D.Raycast(worldPoint, Vector2.zero, 100f, layerPoint);

        if (Input.GetMouseButtonDown(0) && hitTower.collider != null && delete)
        {
            Destroy(hitTower.collider.gameObject);
        }
        if (Input.GetMouseButtonDown(0) && hitTower.collider != null)
        {
            target = hitTower.collider.gameObject;
        }

        if (Input.GetMouseButtonDown(0) && hitTower.collider == null && hitPoint.collider != null && tower != null && infoTarget != null)
        {
            if (infoTarget.tag == "Tower")
            {
                price = tower.GetComponent<Tower>().price;
                craeteTower();
            }
            if (infoTarget.tag == "TowerBuff")
            {
                price = tower.GetComponent<TowerBuff>().price;
                craeteTower();
            }
            if (infoTarget.tag == "TowerFreeze")
            {
                price = tower.GetComponent<TowerFreeze>().price;
                craeteTower();
            }
            if (infoTarget.tag == "TowerPVO")
            {
                price = tower.GetComponent<TowerPVO>().price;
                craeteTower();
            }
            if (infoTarget.tag == "TowerSplash")
            {
                price = tower.GetComponent<TowerSplash>().price;
                if (price <= gm.gold)
                craeteTower();
            }
            if (infoTarget.tag == "TowerTank")
            {
                price = tower.GetComponent<TowerTank>().price;
                craeteTower();
            }
            if (infoTarget.tag == "TowerDebuff")
            {
                price = tower.GetComponent<TowerDebuff>().price;
                craeteTower();
            }
            if (infoTarget.tag == "TowerGold")
            {
                price = tower.GetComponent<TowerGold>().price;
                craeteTower();
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            infoTarget = null;
        }

    }

    public void lvlUp()
    {
        if (towerUp && price <= gm.gold)
        {
            Destroy(target.gameObject);
            Instantiate(levelUp, target.transform.position, target.transform.rotation);
            gm.gold -= price;
        }
    }
    public void craeteTower()
    {
        if (price <= gm.gold)
        {
            pos = hitPoint.collider.gameObject.transform.position;
            Instantiate(tower, pos, tower.transform.rotation);
            gm.gold -= price;
            tower = null;
        }
    }


    public void Tower_Up()
    {
        towerUp = true;
    }
    public void tower1()
    {
        tower = towers[0];
        infoTarget = towers[0];
        target = null;
    }
    public void tower2()
    {
        tower = towers[1];
        infoTarget = towers[1];
        target = null;
    }
    public void tower3()
    {
        tower = towers[2];
        infoTarget = towers[2];
        target = null;
    }
    public void tower4()
    {
        tower = towers[3];
        infoTarget = towers[3];
        target = null;
    }
    public void tower5()
    {
        tower = towers[4];
        infoTarget = towers[4];
        target = null;
    }
    public void tower6()
    {
        tower = towers[5];
        infoTarget = towers[5];
        target = null;
    }
    public void tower7()
    {
        tower = towers[6];
        infoTarget = towers[6];
        target = null;
    }
    public void tower8()
    {
        tower = towers[7];
        infoTarget = towers[7];
        target = null;
    }
    public void tower9()
    {
        tower = towers[8];
        infoTarget = towers[8];
        target = null;
    }
    public void tower10()
    {
        tower = towers[9];
        infoTarget = towers[9];
        target = null;
    }
    public void deleteTower()
    {

        if (target.tag == "Tower")
        {
            price = target.GetComponent<Tower>().price;
            damage = target.GetComponent<Tower>().damage;
            gm.gold += target.GetComponent<Tower>().fullprice / 2;
            Destroy(target);
        }
        if (target.tag == "TowerBuff")
        {
            price = target.GetComponent<TowerBuff>().price;
            damage = target.GetComponent<TowerBuff>().damage;
            gm.gold += target.GetComponent<TowerBuff>().fullprice / 2;
            Destroy(target);
        }
        if (target.tag == "TowerFreeze")
        {
            price = target.GetComponent<TowerFreeze>().price;
            damage = target.GetComponent<TowerFreeze>().damage;
            gm.gold += target.GetComponent<TowerFreeze>().fullprice / 2;
            Destroy(target);
        }
        if (target.tag == "TowerPVO")
        {
            price = target.GetComponent<TowerPVO>().price;
            damage = target.GetComponent<TowerPVO>().damage;
            gm.gold += target.GetComponent<TowerPVO>().fullprice / 2;
            Destroy(target);
        }
        if (target.tag == "TowerSplash")
        {
            price = target.GetComponent<TowerSplash>().price;
            damage = target.GetComponent<TowerSplash>().damage;
            gm.gold += target.GetComponent<TowerSplash>().fullprice / 2;
            Destroy(target);
        }
        if (target.tag == "TowerTank")
        {
            price = target.GetComponent<TowerTank>().price;
            damage = target.GetComponent<TowerTank>().damage;
            gm.gold += target.GetComponent<TowerTank>().fullprice / 2;
            Destroy(target);
        }
        if(target.tag == "TowerDebuff")
        {
            price = target.GetComponent<TowerDebuff>().price;
            damage = target.GetComponent<TowerDebuff>().damage;
            gm.gold += target.GetComponent<TowerDebuff>().fullprice / 2;
            Destroy(target);
        }
        if (target.tag == "TowerGold")
        {
            price = target.GetComponent<TowerGold>().price;
            damage = target.GetComponent<TowerGold>().damage;
            gm.gold += target.GetComponent<TowerGold>().fullprice / 2;
            Destroy(target);
        }
    }

    public void lvl5a()
    {
        if(target.GetComponent<Tower>().lvl4)
        {
            target.GetComponent<Tower>().levelUp = target.GetComponent<Tower>().lvl5a;
        }
        else if (target.GetComponent<TowerBuff>().lvl4)
        {
            target.GetComponent<TowerBuff>().levelUp = target.GetComponent<TowerBuff>().lvl5a;
        }
        else if (target.GetComponent<TowerFreeze>().lvl4)
        {
            target.GetComponent<TowerFreeze>().levelUp = target.GetComponent<TowerFreeze>().lvl5a;
        }
        else if (target.GetComponent<TowerPVO>().lvl4)
        {
            target.GetComponent<TowerPVO>().levelUp = target.GetComponent<TowerPVO>().lvl5a;
        }
        else if (target.GetComponent<TowerSplash>().lvl4)
        {
            target.GetComponent<TowerSplash>().levelUp = target.GetComponent<TowerSplash>().lvl5a;
        }
        else if (target.GetComponent<TowerTank>().lvl4)
        {
            target.GetComponent<TowerTank>().levelUp = target.GetComponent<TowerTank>().lvl5a;
        }
        else if (target.GetComponent<TowerDebuff>().lvl4)
        {
            target.GetComponent<TowerDebuff>().levelUp = target.GetComponent<TowerDebuff>().lvl5a;
        }
        else if (target.GetComponent<TowerGold>().lvl4)
        {
            target.GetComponent<TowerGold>().levelUp = target.GetComponent<TowerGold>().lvl5a;
        }
    }
    public void lvl5b()
    {
        if (target.GetComponent<Tower>().lvl4)
        {
            target.GetComponent<Tower>().levelUp = target.GetComponent<Tower>().lvl5b;
        }
        else if (target.GetComponent<TowerBuff>().lvl4)
        {
            target.GetComponent<TowerBuff>().levelUp = target.GetComponent<TowerBuff>().lvl5b;
        }
        else if (target.GetComponent<TowerFreeze>().lvl4)
        {
            target.GetComponent<TowerFreeze>().levelUp = target.GetComponent<TowerFreeze>().lvl5b;
        }
        else if (target.GetComponent<TowerPVO>().lvl4)
        {
            target.GetComponent<TowerPVO>().levelUp = target.GetComponent<TowerPVO>().lvl5b;
        }
        else if (target.GetComponent<TowerSplash>().lvl4)
        {
            target.GetComponent<TowerSplash>().levelUp = target.GetComponent<TowerSplash>().lvl5b;
        }
        else if (target.GetComponent<TowerTank>().lvl4)
        {
            target.GetComponent<TowerTank>().levelUp = target.GetComponent<TowerTank>().lvl5b;
        }
        else if (target.GetComponent<TowerDebuff>().lvl4)
        {
            target.GetComponent<TowerDebuff>().levelUp = target.GetComponent<TowerDebuff>().lvl5b;
        }
        else if (target.GetComponent<TowerGold>().lvl4)
        {
            target.GetComponent<TowerGold>().levelUp = target.GetComponent<TowerGold>().lvl5b;
        }
    }
}

