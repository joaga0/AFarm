using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public int damage = 10; // 공격 데미지

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // EnemyHealth 스크립트에 데미지를 전달
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Debug.Log($"Enemy hit! Remaining health: {enemyHealth.GetHealth()}");
            }

            // 공격 이펙트 제거 (선택 사항)
            Destroy(gameObject);
        }
    }
}
