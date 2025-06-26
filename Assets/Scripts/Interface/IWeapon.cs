using UnityEngine;

namespace Assets.Scripts.Interface
{
    internal interface IWeapon
    {
        void Equip(Animator animator);
        void Drop(Transform transform);
        void Attack(Transform transform);
    }
}
