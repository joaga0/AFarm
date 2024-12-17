using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static List<string> dontDestroyObjects = new List<string>();
    public int teleport_num;   //player가 마지막으로 이동한 텔레포트 번호
    int health;
    int[] major;
    bool attack_sound;
    bool background_sound;

    public GameObject attack_effect;
    AudioSource attack_source;

    public GameObject audioManager;

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

        attack_sound = true;
        background_sound = true;
        attack_source = attack_effect.GetComponent<AudioSource>();
        attack_source.volume = 1.0f;
    }

    void Update()
    {
        audioManager = GameObject.Find("AudioManager");
        if (background_sound == true)
        {
            audioManager.GetComponent<AudioSource>().volume = 1.0f;
        }
        else
        {
            audioManager.GetComponent<AudioSource>().volume = 0.0f;
        }
    }
    public void set_attack_sound()
    {
        if (attack_sound == true)
        {
            attack_sound = false;
            attack_source.volume = 0.0f;
        }
        else
        {
            attack_sound = true;
            attack_source.volume = 1.0f;
        }
    }

    public void set_background_sound()
    {
        if (background_sound == true)
        {
            background_sound = false;
            audioManager.GetComponent<AudioSource>().volume = 0.0f;
        }
        else
        {
            background_sound = true;
            audioManager.GetComponent<AudioSource>().volume = 1.0f;
        }
    }
}
