using Assets.Scripts.Interface;
using UnityEngine;

[System.Serializable]
public enum WeaponType { Melee, Ranged }
[System.Serializable]
public class WeaponData : IWeapon
{
    public string Name;
    public float AttackCooldown;
    public GameObject WeaponPrefab;
    public GameObject BulletPrefab;
    public int BulletCount;
    public AnimatorOverrideController AnimatorOverrideController;
    public WeaponType WeaponType;

    public void Equip(Animator animator)
    {
        animator.runtimeAnimatorController = AnimatorOverrideController;
    }

    public void Drop(Transform transform)
    {
        Vector3 dropPosition = transform.position + transform.right * 1.5f;
        MonoBehaviour.Instantiate(WeaponPrefab, dropPosition, transform.rotation);
    }

    public void Attack(Transform transform)
    {
        if (WeaponType == WeaponType.Ranged)
        {
            if (BulletCount <= 0)
            {
                return;
            }
            else
            {
                BulletCount--;
                MonoBehaviour.Instantiate(BulletPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, Random.Range(-10, 10)));
            }
        }
    }
}
public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private WeaponData[] _weapons;
    [SerializeField] private RuntimeAnimatorController _defaultAnimatorController;
    [SerializeField] private int _weaponIndex;
    [SerializeField] private Transform _bodyTransform;
    [SerializeField] private bool _isEquipedWeapon = false;
    private IWeapon _currentWeapon;
    public bool IsEquipedWeapon() => _isEquipedWeapon;
    public int WeaponIndex
    {
        get { return _weaponIndex; }
        private set { _weaponIndex = value; }
    }
    private void Start()
    {
        if (_currentWeapon == null)
        {
            _animator.runtimeAnimatorController = _defaultAnimatorController;
        }
    }
    public void EquipWeapon(int index)
    {

        if (index < 0) return;
        Debug.Log("оружие взял");
        _isEquipedWeapon = true;
        _weaponIndex = index;
        _currentWeapon = _weapons[index];
        _currentWeapon.Equip(_animator);
    }
    public void DropWeapon()
    {
        _isEquipedWeapon = false;
        _currentWeapon.Drop(_bodyTransform);
        _currentWeapon = null;
        _animator.runtimeAnimatorController = _defaultAnimatorController;
        _weaponIndex = -1;
    }
    public void AttackWeapon()
    {
        _animator.SetTrigger("Attack");
        if (_currentWeapon == null)
        {
            return;
        }
        else
        {
            _currentWeapon.Attack(_bodyTransform);
        }
    }
    public float GetAttackColdown()
    {
        if (_currentWeapon == null)
        {
            return 0.5f;
        }
        return _weapons[_weaponIndex].AttackCooldown;
    }
}
