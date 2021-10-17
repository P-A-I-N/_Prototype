
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    public bool locke;

    public void Locked(Button button)
    {
        button.enabled = false;
        locke = false;
    }

    public void Unlocked(Button button)
    {
        button.enabled = true;
        locke = true;
    }
}
