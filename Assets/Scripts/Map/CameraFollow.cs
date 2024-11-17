using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player; // 플레이어의 Transform
    [SerializeField]
    private float smoothSpeed = 0.125f; // 카메라 이동 속도
    [SerializeField]
    private Vector3 offset; // 카메라의 상대 위치 오프셋

    private void LateUpdate()
    {
        // 목표 위치 계산
        Vector3 targetPosition = player.position + offset;

        // 부드럽게 카메라 이동
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
