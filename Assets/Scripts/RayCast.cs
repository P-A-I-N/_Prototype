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

    private void Awake()
    {
        gm = GameObject.FindGameObjectsWithTag("Map")[0].GetComponent<GameMap>();
    }

    void Update()
    {
        if (target != null)
        {
            if (target.tag == "Tower")
            { 
                levelUp = target.GetComponent<Tower>().levelUp;
                lvlUp();
            }
            if (target.tag == "TowerBuff")
            {
                levelUp = target.GetComponent<TowerBuff>().levelUp;
                lvlUp();
            }
            if (target.tag == "TowerFreeze")
            {
                levelUp = target.GetComponent<TowerFreeze>().levelUp;
                lvlUp();
            }
            if (target.tag == "TowerPVO")
            {
                levelUp = target.GetComponent<TowerPVO>().levelUp;
                lvlUp();
            }
            if (target.tag == "TowerSplash")
            {
                levelUp = target.GetComponent<TowerSplash>().levelUp;
                lvlUp();
            }
            if (target.tag == "TowerTank")
            {
                levelUp = target.GetComponent<TowerTank>().levelUp;
                lvlUp();
            }
            if (target.tag == "TowerDebuff")
            {
                levelUp = target.GetComponent<TowerDebuff>().levelUp;
                lvlUp();
            }
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
                price = tower.GetComponent<GoldTower>().price;
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
        if (towerUp)
        {
            Destroy(target.gameObject);
            Instantiate(levelUp, target.transform.position, target.transform.rotation);
            towerUp = false;
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
            int price = target.GetComponent<Tower>().price;
            gm.gold += price / 2;
        }
        if (target.tag == "TowerBuff")
        {
            int price = target.GetComponent<TowerBuff>().price;
            gm.gold += price / 2;
        }
        if (target.tag == "TowerFreeze")
        {
            int price = target.GetComponent<TowerFreeze>().price;
            gm.gold += price / 2;
        }
        if (target.tag == "TowerPVO")
        {
            int price = target.GetComponent<TowerPVO>().price;
            gm.gold += price / 2;
        }
        if (target.tag == "TowerSplash")
        {
            int price = target.GetComponent<TowerSplash>().price;
            gm.gold += price / 2;
        }
        if (target.tag == "TowerTank")
        {
            int price = target.GetComponent<TowerTank>().price;
            gm.gold += price / 2;
        }
        if(target.tag == "TowerDebuff")
        {
            int price = target.GetComponent<TowerDebuff>().price;
            gm.gold += price / 2;
        }
        Destroy(target);
    }
}

