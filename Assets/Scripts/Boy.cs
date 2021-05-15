using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer boy;
    public Rigidbody2D rigidbody;

    [Header("Balance variables")]
    [SerializeField]
    private float moveSpeed = 0.5f;



    [SerializeField]
    private float jumpForce = 8;
    [SerializeField]
    public int HP = 30;
    [SerializeField]
    public int currentHp = 30;

    private float horizontal;
    private float vertical;
    private Vector3 direction;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0f, vertical);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            boy.flipX = true;
            animator.SetBool("Run", true);
            transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            boy.flipX = false;
            animator.SetBool("Run", true);
            transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y);

        }

        if (direction.magnitude == 0f)
        {
            animator.SetBool("Run", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision, int currentHP)
    {
        if ((currentHp - collision.GetComponent<Hazard>().damageAmount) < 0)
        {
            currentHp = 0;
            animator.SetTrigger("Fall");
        }
        else
        {
            currentHp = currentHp - collision.GetComponent<Hazard>().damageAmount;
        }

        if (collision.CompareTag("Heal"))
        {
            
          if((currentHP + collision.GetComponent<Heal>().healAmount) > HP)
              currentHP = HP;
          else
              currentHP += collision.GetComponent<Heal>().healAmount;
        }

    }
}
 
