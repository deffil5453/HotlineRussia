using UnityEngine;

namespace Assets.Scripts.Interface
{
    internal interface IWeapon
    {
        void Equip(Animator animator);
        void Drop(Transform bodyTransform, int _weaponIndex, int currentAmmo = -1);
        void Attack(Transform transform, GameObject bullet);
    }
}
