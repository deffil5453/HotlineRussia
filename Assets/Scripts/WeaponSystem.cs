using UnityEngine;

[System.Serializable]
public enum WeaponType { Melee, Ranged }
[System.Serializable]
public class WeaponData
{
    public string Name;
    public GameObject WeaponPrefab;
    public float AttackColdown;
    public AnimatorOverrideController AnimatorOverrideController;
    public WeaponType WeaponType;

}
public class WeaponSystem : MonoBehaviour
{
    public Animator Animator;
    [SerializeField] private WeaponData[] _weapons;
    [SerializeField] private RuntimeAnimatorController _defaultAnimatorController;
    [SerializeField] private int _weaponIndex;
    [SerializeField] private Transform _bodyTransform;
    public int WeaponIndex
    {
        get { return _weaponIndex; }
        private set { _weaponIndex = value; }
    }
    public void EquipWeapon(int index)
    {
        if (index < 0) return;
        _weaponIndex = index;
        WeaponData weaponData = _weapons[index];
        if (weaponData.AnimatorOverrideController != null)
        {
            Animator.runtimeAnimatorController = weaponData.AnimatorOverrideController;
        }
    }
    public void DropWeapon()
    {
        Transform transform = GetComponentInChildren<Transform>();
        Vector3 weaponPosition = _bodyTransform.position + (_bodyTransform.right *10f);
        Instantiate(_weapons[_weaponIndex].WeaponPrefab, weaponPosition, _bodyTransform.rotation);
        Animator.runtimeAnimatorController = _defaultAnimatorController;
        _weaponIndex = -1;
    }
    public float GetAttackColdown()
    {
        return _weapons[_weaponIndex].AttackColdown;
    }
}
