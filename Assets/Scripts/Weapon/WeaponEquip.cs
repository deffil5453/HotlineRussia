using UnityEngine;

public class WeaponEquip : MonoBehaviour
{
    private WeaponController _weaponController;
    private void Start()
    {
        _weaponController = GetComponent<WeaponController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WeaponSystem weaponSystem = collision.GetComponent<WeaponSystem>();
            if (weaponSystem != null && !weaponSystem.IsEquipedWeapon()) 
            {
                weaponSystem.EquipWeapon(_weaponController.WeaponIndex, _weaponController.CurrentAmmo);
                Destroy(gameObject);
            }
        }
    }
}