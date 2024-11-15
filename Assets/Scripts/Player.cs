using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec; // Player input save
    public float speed;      // move speed var

    public GameObject attackEffect;

    Rigidbody2D rigid;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");  // user A/D input
        inputVec.y = Input.GetAxisRaw("Vertical");    // user W/S input

        if (inputVec.x != 0 || inputVec.y != 0)       // Player move => ismove T / not move => ismove F 
            anim.SetBool("ismove", true);
        else
            anim.SetBool("ismove", false);

        anim.SetFloat("inputx", inputVec.x);
        anim.SetFloat("inputy", inputVec.y);

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

        effect.transform.position = new Vector3(effect.transform.position.x, effect.transform.position.y, 1f);

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
   

}
