using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] item;
    public Image[] itemUI;

    int RamdomItem;
    float RandomX, RandomY;
    Vector2 RandomPos;

    void Start()
    {
        RamdomItem = UnityEngine.Random.Range(0, 3);
        RandomX = UnityEngine.Random.Range(-8.5f, 9f);
        RandomY = UnityEngine.Random.Range(-5f, 4.5f);
 
        RandomPos = new Vector2(RandomX, RandomY);

        GameObject newItem = Instantiate(item[RamdomItem]);
        newItem.transform.position = RandomPos;
    }

    void Update()
    {
        
    }
}
