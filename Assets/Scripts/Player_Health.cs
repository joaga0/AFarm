using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public float max_health = 5.0f;
    private float cur_health;
    // Start is called before the first frame update
    void Start()
    {
        cur_health = max_health;   
    }
    public void Take_Damage(float damage) 
    { 
        cur_health -= damage;
        if (cur_health <= 0)
        {
            Die();
        }
    }

    public void Heal(int heal) { 
        cur_health += heal;
        if (cur_health > max_health) // �ִ�ü���� ������ ȸ�� x
            cur_health = max_health;
    }
    void Die()
    {   
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� �� �ٽ� �ε�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
