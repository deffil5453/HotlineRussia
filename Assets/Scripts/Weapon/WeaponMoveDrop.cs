using System.Collections;
using UnityEngine;

public class WeaponMoveDrop : MonoBehaviour
{
    private Vector3 startPositon;
    private Vector3 endPositon;
    private void Start()
    {
        startPositon = transform.position;
        endPositon = transform.position + transform.right * 12f;
        StartCoroutine(MoveWeaponToPosition(transform, startPositon, endPositon, 1f));
    }
    private IEnumerator MoveWeaponToPosition(Transform weaponPosition, Vector3 startPosition, Vector3 dropPosition, float duration)
    {
        float elapsed = 0f; // Текущая продолжительность
        float rotationSpeed = 60f; // скорость вращения(градуссы/c)
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            weaponPosition.position = Vector3.Lerp(startPosition, dropPosition, t);
            weaponPosition.Rotate(Vector3.forward, rotationSpeed);
            elapsed += Time.deltaTime;
            yield return null;
        }
        weaponPosition.position = dropPosition;
        GetComponent<WeaponEquip>().enabled = true;
    }
}
