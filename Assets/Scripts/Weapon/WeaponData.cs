using UnityEngine;
[System.Serializable]
public enum WeaponType { Melee, Ranged }
[System.Serializable]
public class WeaponData
{
    public string Name;
    public float AttackCooldown;
    public GameObject WeaponPrefab;
    
    public int MaxAmmo;
    public AnimatorOverrideController AnimatorOverrideController;
    public WeaponType WeaponType;
}