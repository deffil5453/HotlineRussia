using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed = 15.0f;
    private float _currentlifeTime = 0.0f;
    private void Update()
    {
        Move();
        Dead(5f); // временная мера
    }
    private void Move()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed);
    }
    private void Dead(float lifeTime)
    {
        _currentlifeTime += Time.deltaTime;
        if (_currentlifeTime >= lifeTime)
        {
            Destroy(gameObject);
            _currentlifeTime = 0.0f;
        }
    }
}
