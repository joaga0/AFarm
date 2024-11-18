using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector2 inputVec; // Player input save
    public float speed;      // move speed var

    public GameObject attackEffect;
    PlayerManager playerManager;
    string currentSceneName;

    Rigidbody2D rigid;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameObject playerManagerObject = GameObject.Find("PlayerManager");
        playerManager = playerManagerObject.GetComponent<PlayerManager>();

        currentSceneName = SceneManager.GetActiveScene().name;

        if (playerManager.teleport_num == 0)
            gameObject.transform.position = new Vector2(0, 0);
        else if (playerManager.teleport_num == 1 && currentSceneName == "Class1" || playerManager.teleport_num == 2 && currentSceneName == "Class2")
            gameObject.transform.position = new Vector2(-8, 4);
        else if (playerManager.teleport_num == 2 && currentSceneName == "Class1" || playerManager.teleport_num == 1 && currentSceneName == "Class2")
            gameObject.transform.position = new Vector2(8, 4);
        else if (playerManager.teleport_num == 3 && currentSceneName == "Class1" || playerManager.teleport_num == 4 && currentSceneName == "Class2")
            gameObject.transform.position = new Vector2(0, 4);
        else if (playerManager.teleport_num == 4 && currentSceneName == "Class1" || playerManager.teleport_num == 3 && currentSceneName == "Class2")
            gameObject.transform.position = new Vector2(0, -4.5f);
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");  // user A/D input
        inputVec.y = Input.GetAxisRaw("Vertical");    // user W/S input

        if (inputVec.x > 0)
        {
            anim.speed = 1;
            anim.SetInteger("animation_state", 4);
        }
        else if (inputVec.x < 0)
        {
            anim.speed = 1;
            anim.SetInteger("animation_state", 3);
        }
        else if (inputVec.y > 0)
        {
            anim.speed = 1;
            anim.SetInteger("animation_state", 1);
        }
        else if (inputVec.y < 0)
        {
            anim.speed = 1;
            anim.SetInteger("animation_state", 2);
        }
        else
            anim.speed = 0;

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Attack();
        }

    }

    void Attack()
    {
        Vector3 attackPosition = transform.Find("attackPoint").position;

        if (inputVec.x > 0)
        {
            attackPosition += new Vector3(0.7f, 0, 0);
        }
        else if (inputVec.x < 0)
        {
            attackPosition += new Vector3(-0.7f, 0, 0);
        }
        else if (inputVec.y > 0)
        {
            attackPosition += new Vector3(0, 0.7f, 0);
        }
        else if (inputVec.y < 0)
        {
            attackPosition += new Vector3(0, -0.7f, 0);
        }
        else
        {
            attackPosition += new Vector3(0, -0.7f, 0);
        }

        GameObject effect = Instantiate(attackEffect, attackPosition, Quaternion.identity);

        effect.transform.position = new Vector3(effect.transform.position.x, effect.transform.position.y, -1f);

        if (inputVec.x != 0 || inputVec.y != 0)
        {
            float angle = Mathf.Atan2(inputVec.y, inputVec.x) * Mathf.Rad2Deg;
            effect.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else
        { 
            effect.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        }

        Destroy(effect, 0.3f);
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (collision.CompareTag("tel1"))
        {
            playerManager.teleport_num = 1;
            if (currentSceneName == "Class1")
                SceneManager.LoadScene("Class2");
            else
                SceneManager.LoadScene("Class1");
        }
        else if (collision.CompareTag("tel2"))
        {
            playerManager.teleport_num = 2;
            if (currentSceneName == "Class1")
                SceneManager.LoadScene("Class2");
            else
                SceneManager.LoadScene("Class1");
        }
        else if (collision.CompareTag("tel3"))
        {
            playerManager.teleport_num = 3;
            if (currentSceneName == "Class1")
                SceneManager.LoadScene("Class2");
            else
                SceneManager.LoadScene("Class1");
        }
        else if (collision.CompareTag("tel4"))
        {
            playerManager.teleport_num = 4;
            if (currentSceneName == "Class1")
                SceneManager.LoadScene("Class2");
            else
                SceneManager.LoadScene("Class1");
        }
    }
}
