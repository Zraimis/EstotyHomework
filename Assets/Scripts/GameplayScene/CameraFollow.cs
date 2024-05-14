using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 _velocity = Vector3.zero;

    private void Update()
    {
        Vector3 targetPosition = target.position;
        targetPosition.y = 300f;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, 0f);
    }
}