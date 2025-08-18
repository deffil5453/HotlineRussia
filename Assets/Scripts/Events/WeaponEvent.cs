using System;
using UnityEngine;

public class WeaponEvent : MonoBehaviour
{
    public static event Action DropEvent;
    public static void WeaponDropAction()
    {
        DropEvent?.Invoke();
    }
}
