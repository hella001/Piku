using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    PlayerControls controls;
    float direction = 0;

    public Rigidbody2D playerRB;
    public float speed = 400;
    public Animator animator;
    bool isFachingRight = true;

    public float jumpForce = 5;
    int numberOfJumps = 0;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        //Debug.Log(isGrounded);
        animator.SetBool("isGrounded", isGrounded);
        playerRB.velocity = new Vector2 (direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));

        if (isFachingRight && direction < 0 || !isFachingRight && direction >0 )
            Flip();
    }

    void Flip()
    {
        isFachingRight = !isFachingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        //Debug.Log("Player jump");
        if (isGrounded)
        {
            numberOfJumps = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps++;
            AudioManager.instance.Play("FirsJump");
        }
        else
        {
            if(numberOfJumps == 1)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJumps++;
                AudioManager.instance.Play("SecondJump");
            }
        }
            
    }
}
