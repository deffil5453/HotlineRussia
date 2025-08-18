using UnityEngine;

public class WeaponEquip : MonoBehaviour
{
    private WeaponController _weaponController;
    private bool _playerInTrigger = false;
    private GameObject _playerObject;
    private PlayerCombat _playerCombat;

    private void Start()
    {
        _weaponController = GetComponent<WeaponController>();
        WeaponEvent.DropEvent += PickUpWeapon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInTrigger = true;
            _playerObject = collision.gameObject;
            _playerCombat = _playerObject.GetComponent<PlayerCombat>();

            if (_playerCombat != null)
            {
                _playerCombat.IsPickUpZoneWeapon = _playerInTrigger;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInTrigger = false;

            if (_playerCombat != null)
            {
                _playerCombat.IsPickUpZoneWeapon = false;
            }

            _playerObject = null;
            _playerCombat = null;
        }
    }
    private void PickUpWeapon()
    {
        if (_playerObject == null)
        {
            return;
        }

        WeaponSystem weaponSystem = _playerObject.GetComponent<WeaponSystem>();
        if (weaponSystem == null)
        {
            return;
        }
        if (weaponSystem.IsEquipedWeapon())
        {
            weaponSystem.DropWeapon();
        }
        weaponSystem.EquipWeapon(_weaponController.WeaponIndex, _weaponController.CurrentAmmo);

        Destroy(gameObject);
    }
}