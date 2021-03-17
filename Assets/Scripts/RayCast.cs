using UnityEngine;

public class RayCast : MonoBehaviour
{
    private Vector3 pos;
    public GameObject[] Towers;
    private GameObject Tower;
    private LayerMask LayerTower = 1 << 8;
    private LayerMask LayerPoint = 1 << 7;



    void Update()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitTower = Physics2D.Raycast(worldPoint, Vector2.zero, 100f, LayerTower);
        RaycastHit2D hitPoint = Physics2D.Raycast(worldPoint, Vector2.zero, 100f, LayerPoint);

        if (Input.GetMouseButtonDown(0) && hitTower.collider != null && Tower == null)
        {
            Destroy(hitTower.collider.gameObject);
        }

        if (Input.GetMouseButtonDown(0) && hitTower.collider == null && hitPoint.collider != null && Tower != null)
        {
            pos = hitPoint.collider.gameObject.transform.position;
            Instantiate(Tower, pos, Tower.transform.rotation);
        }

    }





    public void tower1()
    {
        Tower = Towers[0];
    }
    public void tower2()
    {
        Tower = Towers[1];
    }
    public void tower3()
    {
        Tower = Towers[2];
    }
    public void tower4()
    {
        Tower = Towers[3];
    }
    public void tower5()
    {
        Tower = Towers[4];
    }
    public void tower6()
    {
        Tower = Towers[5];
    }
    public void tower7()
    {
        Tower = Towers[6];
    }
    public void tower8()
    {
        Tower = Towers[7];
    }
    public void tower9()
    {
        Tower = Towers[8];
    }
    public void deleteTower()
    {
        Tower = null;
    }
}

