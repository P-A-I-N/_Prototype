using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float distanse;
    public Vector3 pos;
    public GameObject[] Towers;
    public GameObject Tower;



    void Update()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
            }
        }

        if (Input.GetMouseButtonDown(0) && hit.collider != null)
        {
            if (hit.collider.gameObject.layer == 8 && Tower == null)
            {
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider.gameObject.layer == 7 && Tower != null)
            {
                pos = hit.collider.gameObject.transform.position;
                Instantiate(Tower, pos, Tower.transform.rotation);
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (Tower == null)
        //    {
        //        if ((hit.collider.gameObject.tag == "AttackRangeTower1" || hit.collider.gameObject.tag == "AttackRangeTower2" || hit.collider.gameObject.tag == "AttackRangeTower3"))
        //        {
        //            Destroy(hit.collider.gameObject);
        //        }
        //    }
        //    if (hit.collider.gameObject.tag == "Tower Position")
        //    {

        //        if (Tower == null)
        //        {
        //            if (hit.collider.gameObject.tag == "AttackRangeTower1" || hit.collider.gameObject.tag == "AttackRangeTower2" || hit.collider.gameObject.tag == "AttackRangeTower3")
        //            {
        //                Destroy(hit.collider.gameObject);
        //            }
        //        }
        //        else if (hit.collider.gameObject.tag == "AttackRangeTower1")
        //        {
        //            return;
        //        }
        //        else if (hit.collider.gameObject.tag == "AttackRangeTower2")
        //        {
        //            return;
        //        }
        //        else if (hit.collider.gameObject.tag == "AttackRangeTower3")
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            pos = hit.collider.gameObject.transform.position;
        //            Instantiate(Tower, pos, Tower.transform.rotation);
        //        }
        //    }
        //}
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

