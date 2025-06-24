using UnityEngine;

public class WeaponEquip : MonoBehaviour
{
    public int Index;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WeaponSystem weaponSystem = collision.GetComponent<WeaponSystem>();
            if (weaponSystem != null) 
            {
                weaponSystem.EquipWeapon(Index);
                Destroy(gameObject);
            }
        }
    }
}