using UnityEngine;

public class PersonDead : MonoBehaviour
{
    [SerializeField] private Sprite[] _deadSpriteRenderes;
    [SerializeField] private SpriteRenderer _currentSpriteRenderes;

    private Rigidbody2D _currentRigidbody;
    private Collider2D _currentCollider;

    private void Awake()
    {
        _currentRigidbody = GetComponent<Rigidbody2D>();
        _currentCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Die();
            Destroy(collision.gameObject);
        }
        
    }
    private void Die()
    {
        GetComponentInChildren<Animator>().enabled = false;
        int deadNumberSprite = Random.Range(0, _deadSpriteRenderes.Length);
        _currentCollider.enabled = false;
        _currentSpriteRenderes.sprite = _deadSpriteRenderes[deadNumberSprite];
    }
}