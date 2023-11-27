using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private AudioClip jumpSound;

    private Rigidbody2D rb;
    private int timesJumped;
    public float jumpForce = 1f;
    private Animator animator;

    void Move()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * horizontalAxis * Time.deltaTime * velocity);

        Vector3 rotation = transform.rotation.eulerAngles;
        if (horizontalAxis > 0)
        {
            rotation.y = 0;
            animator.SetBool("isRunning", true);
        }
        else if (horizontalAxis < 0)
        {
            rotation.y = 180;
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        transform.rotation = Quaternion.Euler(rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            timesJumped = 0;
            animator.SetBool("hasJumped", false);
        }
    }

    void Jump()
    {
        if (timesJumped < 2)
        {
            timesJumped++;
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("hasJumped", true);
            AudioManager.instance.PlaySound(jumpSound);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void InputCheck()
    {
        Move();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        InputCheck();
    }
}
