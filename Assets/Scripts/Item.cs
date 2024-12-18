using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int heal = 1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Health player_Health = collision.GetComponent<Player_Health>();
            if (player_Health != null) { 
                player_Health.Heal(heal);
            }
            Destroy(gameObject);
        }
    }
}
