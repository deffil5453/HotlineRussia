using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed = 15.0f;
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed);
    }
}
