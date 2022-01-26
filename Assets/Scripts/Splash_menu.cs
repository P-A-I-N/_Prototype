
using UnityEngine;

public class Splash_menu : MonoBehaviour
{
    GameObject icon_levelup, icon_delete, menu;
    public bool mouse_over;
    // Start is called before the first frame update
    void Start()
    {
        icon_levelup = transform.parent.gameObject.GetComponent<Tower>().icon_levelup;
        icon_delete = transform.parent.gameObject.GetComponent<Tower>().icon_delete;
        menu = transform.parent.gameObject.GetComponent<Tower>().Splash_menu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (icon_levelup != null)
        {
            mouse_over = true;
            menu.SetActive(true);
            icon_levelup.SetActive(true);
            icon_delete.SetActive(true);
        }
    }
    //private void OnMouseExit()
    //{
    //    if (icon_levelup != null)
    //    {
    //        mouse_over = false;
    //        if (!transform.parent.GetComponent<Tower>().mouse_over && !transform.parent.parent.GetComponent<BlockPointer>().mouse_over && !icon_levelup.GetComponent<levelup>().mouse_over && !icon_delete.GetComponent<delete>().mouse_over)
    //        {
    //            menu.SetActive(false);
    //            icon_levelup.SetActive(false);
    //            icon_delete.SetActive(false);
    //        }
    //    }
    //}
}
