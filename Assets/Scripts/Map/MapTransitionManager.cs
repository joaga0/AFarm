using UnityEngine;

public class MapTransitionManager : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint; // 플레이어가 나타날 위치
    [SerializeField]
    private Transform cameraTargetPosition; // 카메라가 이동할 위치
    [SerializeField]
    private Camera mainCamera; // 메인 카메라
    [SerializeField]
    private float collisionIgnoreTime = 0.5f; // 충돌 무시 시간

    private bool isTransitioning = false; // 맵 전환 중인지 확인

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTransitioning && collision.CompareTag("Player"))
        {
            StartCoroutine(TransitionToNextMap(collision.gameObject));
        }
    }

    private System.Collections.IEnumerator TransitionToNextMap(GameObject player)
    {
        isTransitioning = true; // 맵 전환 시작

        // 플레이어를 새 위치로 이동
        player.transform.position = spawnPoint.position;

        // 카메라를 새 위치로 이동
        if (mainCamera != null && cameraTargetPosition != null)
        {
            mainCamera.transform.position = new Vector3(
                cameraTargetPosition.position.x,
                cameraTargetPosition.position.y,
                mainCamera.transform.position.z // Z축은 유지
            );
        }

        // 플레이어와 현재 문 간 충돌 무시
        Collider2D playerCollider = player.GetComponent<Collider2D>();
        Collider2D doorCollider = GetComponent<Collider2D>();
        if (playerCollider != null && doorCollider != null)
        {
            Physics2D.IgnoreCollision(playerCollider, doorCollider, true);
            yield return new WaitForSeconds(collisionIgnoreTime); // 충돌 무시 시간 대기
            Physics2D.IgnoreCollision(playerCollider, doorCollider, false);
        }

        isTransitioning = false; // 맵 전환 가능 상태로 변경
    }
}
