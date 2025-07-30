using UnityEngine;

public class PersonDead : MonoBehaviour
{
    [SerializeField] private Sprite[] _deadSpriteRenderes;
    [SerializeField] private SpriteRenderer _currentSpriteRenderes;

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
        Debug.Log(deadNumberSprite);
        _currentSpriteRenderes.sprite = _deadSpriteRenderes[deadNumberSprite];
    }
}