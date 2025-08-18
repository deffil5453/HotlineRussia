using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private WeaponSystem _weaponSystem;
    private float _nextAttackTime;
    public bool IsPickUpZoneWeapon { get; set; }

    private void Start()
    {
        _weaponSystem = GetComponent<WeaponSystem>();
    }

    private void Update()
    {
        Attack();
        if (Input.GetMouseButtonDown(1))
        {
            if (IsPickUpZoneWeapon)
            {
                WeaponEvent.WeaponDropAction();
            }
            else 
            {
                DropAttack();
            }
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButton(0) && Time.time >= _nextAttackTime)
        {
            _weaponSystem.AttackWeapon();
            _nextAttackTime = Time.time + _weaponSystem.GetAttackColdown();
        }
    }

    public void DropAttack()
    {
        if (_weaponSystem.IsEquipedWeapon())
        {
            _weaponSystem.DropWeapon();
        }
    }
}