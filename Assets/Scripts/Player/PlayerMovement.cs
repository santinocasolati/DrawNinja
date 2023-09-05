using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity;

    private Rigidbody2D rb;
    private int timesJumped;
    public float jumpForce = 1f;

    void Move()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * horizontalAxis * Time.deltaTime * velocity);

        Vector3 rotation = transform.rotation.eulerAngles;
        if (horizontalAxis > 0)
        {
            rotation.y = 0;
        }
        else if (horizontalAxis < 0)
        {
            rotation.y = 180;
        }

        transform.rotation = Quaternion.Euler(rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            timesJumped = 0;
        }
    }

    void Jump()
    {
        if (timesJumped < 2)
        {
            timesJumped++;
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void InputCheck()
    {
        Move();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Update()
    {
        InputCheck();
    }
}
