using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public int damage = 10; // ���� ������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // EnemyHealth ��ũ��Ʈ�� �������� ����
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Debug.Log($"Enemy hit! Remaining health: {enemyHealth.GetHealth()}");
            }

            // ���� ����Ʈ ���� (���� ����)
            Destroy(gameObject);
        }
    }
}
