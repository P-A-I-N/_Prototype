
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    public void Locked(Button button)
    {
        button.enabled = false;
    }

    public void Unlocked(Button button)
    {
        button.enabled = true;
    }
}
