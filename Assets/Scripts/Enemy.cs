using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float randomMoveTime;

    Vector2 moveVec;
    Vector2 playerPosition;
    bool detect;

    Rigidbody2D rigid;
    Animator anim;

    void Start()
    {
        float RandomX = UnityEngine.Random.Range(-8.0f, 9f);
        float RandomY = UnityEngine.Random.Range(-4f, 4.0f);

        gameObject.transform.position = new Vector2(RandomX, RandomY);

        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        detect = false;

        StartCoroutine(RandomMove());
    }


    void Update()
    {
        if (detect)
        {
            moveVec = (playerPosition - (Vector2)transform.position).normalized;
            UpdateAnimation(moveVec);
        }
    }
    void FixedUpdate()
    {
        Vector2 nextVec = moveVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void UpdateAnimation(Vector2 direction)
    {
        if (direction.x > 0)
        {
            anim.speed = 1;
            anim.SetInteger("animation_state", 4);
        }
        else if (direction.x < 0)
        {
            anim.speed = 1;
            anim.SetInteger("animation_state", 3);
        }
        else if (direction.y > 0)
        {
            anim.speed = 1;
            anim.SetInteger("animation_state", 1);
        }
        else if (direction.y < 0)
        {
            anim.speed = 1;
            anim.SetInteger("animation_state", 2);
        }
        else
        {
            anim.speed = 0;
        }
    }

    IEnumerator RandomMove()
    {
        while (!detect)
        {
            float randomX = UnityEngine.Random.Range(-1, 2);
            float randomY = UnityEngine.Random.Range(-1, 2);
            moveVec = new Vector2(randomX, randomY).normalized;

            UpdateAnimation(moveVec);

            yield return new WaitForSeconds(randomMoveTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detect = true;
            StopCoroutine(RandomMove());
            playerPosition = collision.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPosition = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detect = false;
            if (this.gameObject.activeInHierarchy)
                StartCoroutine(RandomMove());
        }
    }
}
