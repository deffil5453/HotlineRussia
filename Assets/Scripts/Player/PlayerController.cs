using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator PlayerAnimatorLegsMove;
    private Vector2 _position;
    [SerializeField] private float _speed = 4.0f;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private WeaponSystem _weaponSystem;
    private float _nextAttackTime;
    private void Awake()
    {
        _weaponSystem = GetComponent<WeaponSystem>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _weaponSystem.DropWeapon();
        }
        Attack();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Attack()
    {
        if (Input.GetMouseButton(0) && Time.time>=_nextAttackTime)
        {
            _weaponSystem.Animator.SetTrigger("Attack");
            _nextAttackTime = Time.time + _weaponSystem.GetAttackColdown();
        }
    }
    private void Move()
    {
        _position.x = Input.GetAxisRaw("Horizontal");
        _position.y = Input.GetAxisRaw("Vertical");

        bool isWalking = _position.magnitude > 0.1f;
        PlayerAnimatorLegsMove.SetBool("IsWalking", isWalking);
        _weaponSystem.Animator.SetBool("IsWalking", isWalking);
        

        _playerRigidbody.linearVelocity = _position.normalized * _speed;
        if (_position != Vector2.zero)
        {
            float angle = Mathf.Atan2(_position.y, _position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}