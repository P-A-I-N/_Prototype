
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    public bool unlocked;

    public void Locked()
    {
        unlocked = false;
    }

    public void Unlocked()
    {
        unlocked = true;
    }

    public void Locked(Button button)
    {
        button.enabled = false;
        Locked();
    }

    public void Unlocked(Button button)
    {
        button.enabled = true;
        Unlocked();
    }
}
