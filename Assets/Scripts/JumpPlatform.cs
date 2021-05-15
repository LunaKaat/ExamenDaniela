using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    [Header("Balance variables")]
    public float impulseForce = 0.7f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, impulseForce), ForceMode2D.Impulse);
        }
    }
}