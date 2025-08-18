using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerTarget;
    [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10);
    [SerializeField] private float duration;
    private Camera _camera;
    private Vector3 _velocity = Vector3.zero;
    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    private void Update()
    {
        LookAHead();
    }
    private void LateUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 desiredPosition = _playerTarget.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, duration);
    }
    private void LookAHead()
    {
        Vector3 camPosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        camPosition += _offset;
        transform.Translate((camPosition - transform.position) * Time.deltaTime);
    }
}