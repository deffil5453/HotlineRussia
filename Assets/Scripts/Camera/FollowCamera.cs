using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerTarget;
    [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10);
    [SerializeField] private float duration;
    private Vector3 _velocity = Vector3.zero;
    private void LateUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 desiredPosition = _playerTarget.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, duration);
    }
}