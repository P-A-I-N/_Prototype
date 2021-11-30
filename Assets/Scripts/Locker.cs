
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    public bool unlocked;

    public void SetUnlockState(bool unlock)
    {
        unlocked = unlock;
    }

    public void SetUnlockStateWithButton(bool unlock, Button button)
    {
        button.enabled = unlock;
        SetUnlockState(unlock);
    }
}
