using UnityEngine;
using UnityEngine.UI;

public class TowerPVO : Tower
{

    private new void Update()
    {
        int enemyLayer = LayerMask.NameToLayer("EnemyFly");
        layerMask = (1 << enemyLayer);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, layerMask);
        Debug.DrawRay(transform.position, Vector2.right * range, Color.yellow);
        if (hit.collider != null)
        {
            target = true;
        }
        else target = false;
    }

}