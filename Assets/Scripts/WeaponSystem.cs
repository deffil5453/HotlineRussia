using TMPro;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CreateWeapon _weapons;
    [SerializeField] private RuntimeAnimatorController _defaultAnimatorController;
    [SerializeField] private int _weaponIndex;
    [SerializeField] private Transform _bodyTransform;
    [SerializeField] private bool _isEquipedWeapon = false;
    [SerializeField] private GameObject _bulletPrefab;

    [Header("Отображение кол-ва патронов")]
    [SerializeField] private GameObject _textAmmoBlock;
    [SerializeField] private TMP_Text _textCurrentAmmo;

    private WeaponInstance _currentWeapon;
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
    public void EquipWeapon(int index, int currentAmmo)
    {
        if (index < 0) return;
        Debug.Log("оружие взял");
        _isEquipedWeapon = true;
        _weaponIndex = index;

        WeaponData currentWeaponData = _weapons.Weapons[index];
        _currentWeapon = new WeaponInstance(currentWeaponData);

        _currentWeapon.CurrentAmmo = currentAmmo;
        if (_currentWeapon.WeaponData.WeaponType == WeaponType.Ranged)
        {
            _textAmmoBlock.SetActive(true);
            UpdateAmmoUi(_currentWeapon.CurrentAmmo, _currentWeapon.WeaponData.MaxAmmo);
        }

        _currentWeapon.Equip(_animator);
    }
    public void DropWeapon()
    {
        if (_currentWeapon == null) return;

        //Сохраняем кол-во патронов
        int currentAmmo = _currentWeapon.CurrentAmmo;

        _isEquipedWeapon = false;
        //Создаём само оружие
        _currentWeapon.Drop(_bodyTransform, _weaponIndex, currentAmmo);

        _textAmmoBlock.SetActive(false);
        _currentWeapon = null;

        _animator.runtimeAnimatorController = _defaultAnimatorController;
        _weaponIndex = -1;
    }
    public void AttackWeapon()
    {
        if (!_isEquipedWeapon)
        {
            AttachNoWeapon();
        }
        else
        {
            UpdateAmmoUi(_currentWeapon.CurrentAmmo, _currentWeapon.WeaponData.MaxAmmo);
            if (_currentWeapon.CurrentAmmo == 0)
            {
                return;
            }
            _animator.SetTrigger("Attack");
            if (true)
            {
                _currentWeapon.Attack(_bodyTransform, _bulletPrefab);
            }
        }

    }
    public float GetAttackColdown()
    {
        if (_currentWeapon == null)
        {
            return 0.5f;
        }
        return _weapons.Weapons[_weaponIndex].AttackCooldown;
    }
    private void AttachNoWeapon()
    {
        _animator.SetTrigger("Attack");
    }
    private void UpdateAmmoUi(int currentAmmo, int maxAmmo)
    {
        if (_textAmmoBlock == null)
        {
            return;
        }

        Debug.Log(currentAmmo);
        _textCurrentAmmo.text = $"{currentAmmo}/{maxAmmo}";
    }
}