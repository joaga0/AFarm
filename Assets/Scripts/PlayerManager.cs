using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static List<string> dontDestroyObjects = new List<string>();
    public int teleport_num;   //player가 마지막으로 이동한 텔레포트 번호
    int health;
    int[] major;

    void Start()
    {
        if (dontDestroyObjects.Contains(gameObject.name))
        {
            Destroy(gameObject);
            return;
        }

        dontDestroyObjects.Add(gameObject.name);
        DontDestroyOnLoad(gameObject);

        teleport_num = 0;
        health = 0;
    }

    void Update()
    {
        
    }
}
