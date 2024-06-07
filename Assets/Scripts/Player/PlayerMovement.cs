using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    float direction = 0;

    public Rigidbody2D playerRB;
    public float speed = 400;
    public Animator animator;
    public bool isFachingRight = true;

    public float jumpForce = 7;
    int numberOfJumps = 0;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool isMoving = false;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx => Jump();
    }

    void FixedUpdate()
    {
        RaycastHit2D[] hits = Physics2D.CapsuleCastAll(
            groundCheck.position,
            new Vector2(0.3293138f, 0.9425843f),
            CapsuleDirection2D.Horizontal,
            0.1f,
            Vector2.down,
            0.1f,
            groundLayer
        );

        isGrounded = (hits.Length > 0);
        animator.SetBool("isGrounded", isGrounded);

        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));

        // Audio play logic for running
        if (Mathf.Abs(direction) > 0 && !isMoving)
        {
            isMoving = true;
            AudioManager.instance.Play("Run");
        }
        else if (Mathf.Abs(direction) == 0 && isMoving)
        {
            isMoving = false;
            AudioManager.instance.Stop("Run");
        }

        if (isFachingRight && direction < 0 || !isFachingRight && direction > 0)
            Flip();
    }

    void Flip()
    {
        isFachingRight = !isFachingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        if (isGrounded || numberOfJumps < 2)
        {
            AudioManager.instance.Play("FirsJump");
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps++;

            if (numberOfJumps == 0)
            {
                animator.SetTrigger("Jump");
                AudioManager.instance.Play("FirsJump");
            }
            else if (numberOfJumps == 1)
            {
                //AudioManager.instance.Play("SecondJump");
                AudioManager.instance.Play("FirsJump");
            }
        }
    }
}
