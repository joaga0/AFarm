using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] item;
    public Image[] itemUI;
    public GameObject[] enemy;

    int randomItem, randomEnemy;
    float randomX, randomY;
    Vector2 RandomPos;

    void Start()
    {
        randomItem = UnityEngine.Random.Range(0, 3);
        randomEnemy = UnityEngine.Random.Range(0, 3);
        randomX = UnityEngine.Random.Range(-8.5f, 9f);
        randomY = UnityEngine.Random.Range(-5f, 4.5f);

        RandomPos = new Vector2(randomX, randomY);

        GameObject newItem = Instantiate(item[randomItem]);
        newItem.transform.position = RandomPos;

        for (int i = 0; i < randomEnemy; i++)
        {
            Instantiate(enemy[i]);
        }
    }

    void Update()
    {
        
    }
}
