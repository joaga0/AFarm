using UnityEngine;

public class MapTransitionManager : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint; // �÷��̾ ��Ÿ�� ��ġ
    [SerializeField]
    private Transform cameraTargetPosition; // ī�޶� �̵��� ��ġ
    [SerializeField]
    private Camera mainCamera; // ���� ī�޶�
    [SerializeField]
    private float collisionIgnoreTime = 0.5f; // �浹 ���� �ð�

    private bool isTransitioning = false; // �� ��ȯ ������ Ȯ��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTransitioning && collision.CompareTag("Player"))
        {
            StartCoroutine(TransitionToNextMap(collision.gameObject));
        }
    }

    private System.Collections.IEnumerator TransitionToNextMap(GameObject player)
    {
        isTransitioning = true; // �� ��ȯ ����

        // �÷��̾ �� ��ġ�� �̵�
        player.transform.position = spawnPoint.position;

        // ī�޶� �� ��ġ�� �̵�
        if (mainCamera != null && cameraTargetPosition != null)
        {
            mainCamera.transform.position = new Vector3(
                cameraTargetPosition.position.x,
                cameraTargetPosition.position.y,
                mainCamera.transform.position.z // Z���� ����
            );
        }

        // �÷��̾�� ���� �� �� �浹 ����
        Collider2D playerCollider = player.GetComponent<Collider2D>();
        Collider2D doorCollider = GetComponent<Collider2D>();
        if (playerCollider != null && doorCollider != null)
        {
            Physics2D.IgnoreCollision(playerCollider, doorCollider, true);
            yield return new WaitForSeconds(collisionIgnoreTime); // �浹 ���� �ð� ���
            Physics2D.IgnoreCollision(playerCollider, doorCollider, false);
        }

        isTransitioning = false; // �� ��ȯ ���� ���·� ����
    }
}
