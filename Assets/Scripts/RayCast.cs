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
            Tower t = target.GetComponent<Tower>();
            levelUp = t.levelUp;
            if (towerUp && gm.gold >= t.priceLVLUp)
            {
                Destroy(target.gameObject);
                Instantiate(levelUp, target.transform.position, target.transform.rotation);
                gm.gold -= t.priceLVLUp;
            }
            towerUp = false;
        }
        if (Input.GetMouseButtonDown(1))
        {
            infoTarget = null;
            target = null;
            delete = false;
        }
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitTower = Physics2D.Raycast(worldPoint, Vector2.zero, 100f, layerTower);
        RaycastHit2D hitPoint = Physics2D.Raycast(worldPoint, Vector2.zero, 100f, layerPoint);

        if (Input.GetMouseButtonDown(0) && hitTower.collider != null && delete)
        {
            int price = hitTower.collider.GetComponent<Tower>().price;
            Destroy(hitTower.collider.gameObject);
            gm.gold += price / 2;
        }
        if (Input.GetMouseButtonDown(0) && hitTower.collider != null)
        {
            target = hitTower.collider.gameObject;
        }

        if (Input.GetMouseButtonDown(0) && hitTower.collider == null && hitPoint.collider != null && tower != null && infoTarget != null)
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
        //if (Input.GetMouseButtonDown(0) && hitTower.collider != null && hitPoint.collider != null && delete)
        //{
        //    int price = hitTower.collider.GetComponent<Tower>().price;
        //    Destroy(hitTower.collider);
        //    gm.gold += price / 2;
        //}

            if (Input.GetMouseButtonDown(0))
        {
            infoTarget = null;
            delete = false;
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
        delete = true;
    }
}

