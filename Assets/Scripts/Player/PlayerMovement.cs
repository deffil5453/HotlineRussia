using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator PlayerAnimatorLegsMove;
    public Animator PlayerAnimatorBodyMove;
    private Vector2 _position;
    [SerializeField] private float _speed = 4.0f;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        StartMove();
    }

    private void StartMove()
    {
        _position.x = Input.GetAxisRaw("Horizontal");
        _position.y = Input.GetAxisRaw("Vertical");

        bool isWalking = _position.magnitude > 0.1f;
        PlayerAnimatorLegsMove.SetBool("IsWalking", isWalking);
        PlayerAnimatorBodyMove.SetBool("IsWalking", isWalking);
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        //_playerRigidbody.linearVelocity = _position.normalized * _speed;
        _playerRigidbody.MovePosition(_playerRigidbody.position + _position.normalized * _speed * Time.fixedDeltaTime);
        if (_position != Vector2.zero)
        {
            float angle = Mathf.Atan2(_position.y, _position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}


//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    public Animator PlayerAnimatorLegsMove;
//    public Animator PlayerAnimatorBodyMove;
//    private Vector2 _position;
//    [SerializeField] private float _speed = 4.0f;
//    [SerializeField] private Rigidbody2D _playerRigidbody;

//    private Vector2 _moveInput;
//    private Vector2 _smothedDirection;
//    private float _rotationSmoothness = 10f;

//    private void Awake()
//    {
//        if (_playerRigidbody == null)
//        {
//            _playerRigidbody = GetComponent<Rigidbody2D>();
//        }
//    }
//    private void Update()
//    {
//        StartMove();
//    }

//    private void StartMove()
//    {
//        _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
//        _smothedDirection = Vector2.Lerp(_smothedDirection, _moveInput, _rotationSmoothness * Time.deltaTime);

//        bool _isWalking = _moveInput.magnitude > 0.1f;
//        PlayerAnimatorLegsMove.SetBool("IsWalking", _isWalking);
//        PlayerAnimatorBodyMove.SetBool("IsWalking", _isWalking);

//        if (_isWalking)
//        {
//            float angle = Mathf.Atan2(_smothedDirection.y, _smothedDirection.x) * Mathf.Rad2Deg;
//            _playerRigidbody.MoveRotation(angle);
//        }
//    }

//    private void FixedUpdate()
//    {
//        Move();
//    }
//    private void Move()
//    {
//        _playerRigidbody.linearVelocity = _moveInput * _speed;
//    }
//}
