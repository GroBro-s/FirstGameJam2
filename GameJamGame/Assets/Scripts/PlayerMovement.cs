using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int jumpPower = 5;
    [SerializeField] private int playerSpeed = 5;
    public Animator animator;


    private void Awake()
    {
        Physics2D.queriesStartInColliders = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();

        if (Input.GetButton("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    private bool IsGrounded()
    {
        var birdName = GameObject.FindGameObjectWithTag("Player").name;
        switch (birdName)
        {
            case "Small Player":
                var smallGroundCheck = Physics2D.Raycast(transform.position, Vector2.down, 1f);
                return smallGroundCheck.collider != null && smallGroundCheck.collider.CompareTag("Ground");
            case "Big Player":
                var bigGroundCheck = Physics2D.Raycast(transform.position, Vector2.down, 2.1f);
                return bigGroundCheck.collider != null && bigGroundCheck.collider.CompareTag("Ground");
            default: 
                return false;
		}
    }

    void Jump()
    {
        rb.velocity = new Vector2(0, jumpPower);
    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (horizontalInput < 0f) {spriteRenderer.flipX = true;}
        else{spriteRenderer.flipX = false;}
    }
}