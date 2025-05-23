using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator PlayerAnimatorMove;
    [SerializeField] private float _speed = 4.0f;
    private Vector2 _position;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    private void Start()
    {
        //PlayerAnimatorMove = GetComponent<Animator>();
        //_playerRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _position.x = Input.GetAxisRaw("Horizontal");
        _position.y = Input.GetAxisRaw("Vertical");


        bool isWalking = _position.magnitude > 0.1f;
        PlayerAnimatorMove.SetBool("IsWalking", isWalking);

        // Если нужно просто включать/выключать анимацию
        if (isWalking)
        {
            PlayerAnimatorMove.Play("PlayerRun");
        }
        else
        {
            PlayerAnimatorMove.Play("Idle");
        }
    }
    private void FixedUpdate()
    {
        _playerRigidbody.linearVelocity = _position.normalized * _speed;
        if (_position != Vector2.zero)
        {
            float angle = Mathf.Atan2(_position.y, _position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
