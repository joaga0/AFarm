using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player; // �÷��̾��� Transform
    [SerializeField]
    private float smoothSpeed = 0.125f; // ī�޶� �̵� �ӵ�
    [SerializeField]
    private Vector3 offset; // ī�޶��� ��� ��ġ ������

    private void LateUpdate()
    {
        // ��ǥ ��ġ ���
        Vector3 targetPosition = player.position + offset;

        // �ε巴�� ī�޶� �̵�
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
