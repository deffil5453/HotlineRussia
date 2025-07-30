using Assets.Scripts.Interface;
using System;
using System.Collections;
using UnityEngine;

public class WeaponInstance : IWeapon
{
    public int CurrentAmmo;
    public WeaponData WeaponData;
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
        GameObject createWeapon = MonoBehaviour.Instantiate(WeaponData.WeaponPrefab, bodyTransform.position, bodyTransform.rotation);
        createWeapon.GetComponent<WeaponEquip>().enabled = false;
        createWeapon.AddComponent<WeaponMoveDrop>();
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
