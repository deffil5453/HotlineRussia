using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int WeaponIndex;
    public int CurrentAmmo = 30;
    public void Inizialize(int index, int currentAmmo = -1)
    {
        WeaponIndex = index;
        CurrentAmmo = currentAmmo;
    }
}
