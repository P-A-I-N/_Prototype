using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float distanse;
    public Vector3 pos;
    public GameObject[] Towers;
    public LayerMask TD;
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


        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (Tower == null)
        //    {
        //        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.tag == "AttackRangeTower1" || hit.collider.gameObject.tag == "AttackRangeTower2" || hit.collider.gameObject.tag == "AttackRangeTower3"))
        //        {
        //            Destroy(hit.collider.gameObject);
        //        }
        //    }
        //    if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Tower Position")
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





    //public void tower1()
    //{
    //    Tower = Towers[0];
    //}
    //public void tower2()
    //{
    //    Tower = Towers[1];
    //}
    //public void tower3()
    //{
    //    Tower = Towers[2];
    //}
    //public void towerWall()
    //{
    //    Tower = Towers[3];
    //}

    //public void deleteTower()
    //{
    //    Tower = null;

    //}
}

