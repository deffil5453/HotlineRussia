using Assets.Scripts.Interface;
using System;
using UnityEngine;

public class WeaponInstance : IWeapon
{
    public int CurrentAmmo;
    public WeaponData WeaponData;
    public GameObject BulletPrefab;

    public WeaponInstance(WeaponData weaponData)
    {
        WeaponData = weaponData;
    }

    public void Attack(Transform transform, GameObject bullet)
    {
        if (WeaponData.WeaponType == WeaponType.Ranged)
        {
            MonoBehaviour.Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, UnityEngine.Random.Range(-5, 5)));
            CurrentAmmo--;
            AmmoChanged?.Invoke();
        }
    }

    public void Drop(Transform bodyTransform, int _weaponIndex, int currentAmmo = -1)
    {
        Vector3 dropPosition = bodyTransform.position + bodyTransform.right * 1.5f;
        GameObject createWeapon = MonoBehaviour.Instantiate(WeaponData.WeaponPrefab, dropPosition, bodyTransform.rotation);
        WeaponController weaponController = createWeapon.GetComponent<WeaponController>();
        if (weaponController != null)
        {
            weaponController.Inizialize(_weaponIndex, currentAmmo);
        }
    }

    public void Equip(Animator animator)
    {
        animator.runtimeAnimatorController = WeaponData.AnimatorOverrideController;
    }
    public event Action AmmoChanged;
}
