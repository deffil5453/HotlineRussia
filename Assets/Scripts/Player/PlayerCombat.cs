using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private WeaponSystem _weaponSystem;
    private float _nextAttackTime;
    private void Start()
    {
        _weaponSystem = GetComponent<WeaponSystem>();
    }
    private void Update()
    {
        Attack();
        if (_weaponSystem.IsEquipedWeapon())
        {
            DropAttack();
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
    private void DropAttack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_weaponSystem.IsEquipedWeapon())
            {
                _weaponSystem.DropWeapon();
            }
        }
    }
}
