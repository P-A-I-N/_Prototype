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
                if (towerUp)
                {
                    Destroy(target.gameObject);
                    Instantiate(levelUp, target.transform.position, target.transform.rotation);
                    towerUp = false;
                }
            }
            if (target.tag == "TowerBuff")
            {
                levelUp = target.GetComponent<TowerBuff>().levelUp;
                if (towerUp)
                {
                    Destroy(target.gameObject);
                    Instantiate(levelUp, target.transform.position, target.transform.rotation);
                    towerUp = false;
                }
            }
            if (target.tag == "TowerFreeze")
            {
                levelUp = target.GetComponent<TowerFreeze>().levelUp;
                if (towerUp)
                {
                    Destroy(target.gameObject);
                    Instantiate(levelUp, target.transform.position, target.transform.rotation);
                    towerUp = false;
                }
            }
            if (target.tag == "TowerPVO")
            {
                levelUp = target.GetComponent<TowerPVO>().levelUp;
                if (towerUp)
                {
                    Destroy(target.gameObject);
                    Instantiate(levelUp, target.transform.position, target.transform.rotation);
                    towerUp = false;
                }
            }
            if (target.tag == "TowerSplash")
            {
                levelUp = target.GetComponent<TowerSplash>().levelUp;
                if (towerUp)
                {
                    Destroy(target.gameObject);
                    Instantiate(levelUp, target.transform.position, target.transform.rotation);
                    towerUp = false;
                }
            }
            if (target.tag == "TowerTank")
            {
                levelUp = target.GetComponent<TowerTank>().levelUp;
                if (towerUp)
                {
                    Destroy(target.gameObject);
                    Instantiate(levelUp, target.transform.position, target.transform.rotation);
                    towerUp = false;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            infoTarget = null;
            target = null;
        }
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitTower = Physics2D.Raycast(worldPoint, Vector2.zero, 100f, layerTower);
        RaycastHit2D hitPoint = Physics2D.Raycast(worldPoint, Vector2.zero, 100f, layerPoint);

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
                int price = tower.GetComponent<Tower>().price;
                if (price <= gm.gold)
                {
                    pos = hitPoint.collider.gameObject.transform.position;
                    Instantiate(tower, pos, tower.transform.rotation);
                    gm.gold -= price;
                    tower = null;
                }
            }
            if (infoTarget.tag == "TowerBuff")
            {
                int price = tower.GetComponent<TowerBuff>().price;
                if (price <= gm.gold)
                {
                    pos = hitPoint.collider.gameObject.transform.position;
                    Instantiate(tower, pos, tower.transform.rotation);
                    gm.gold -= price;
                    tower = null;
                }
            }
            if (infoTarget.tag == "TowerFreeze")
            {
                int price = tower.GetComponent<TowerFreeze>().price;
                if (price <= gm.gold)
                {
                    pos = hitPoint.collider.gameObject.transform.position;
                    Instantiate(tower, pos, tower.transform.rotation);
                    gm.gold -= price;
                    tower = null;
                }
            }
            if (infoTarget.tag == "TowerPVO")
            {
                int price = tower.GetComponent<TowerPVO>().price;
                if (price <= gm.gold)
                {
                    pos = hitPoint.collider.gameObject.transform.position;
                    Instantiate(tower, pos, tower.transform.rotation);
                    gm.gold -= price;
                    tower = null;
                }
            }
            if (infoTarget.tag == "TowerSplash")
            {
                int price = tower.GetComponent<TowerSplash>().price;
                if (price <= gm.gold)
                {
                    pos = hitPoint.collider.gameObject.transform.position;
                    Instantiate(tower, pos, tower.transform.rotation);
                    gm.gold -= price;
                    tower = null;
                }
            }
            if (infoTarget.tag == "TowerTank")
            {
                int price = tower.GetComponent<TowerTank>().price;
                if (price <= gm.gold)
                {
                    pos = hitPoint.collider.gameObject.transform.position;
                    Instantiate(tower, pos, tower.transform.rotation);
                    gm.gold -= price;
                    tower = null;
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            infoTarget = null;
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
        Destroy(target);
    }
}

