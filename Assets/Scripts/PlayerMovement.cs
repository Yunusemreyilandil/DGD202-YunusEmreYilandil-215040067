using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private LayerMask jumpableGround ;
   [SerializeField] private float moveSpeed = 7f;
   [SerializeField] private float jumpForce = 14f; 


    private enum MovementState { idle, running, jumping, falling }
    private MovementState state = MovementState.idle;
    private float dirX = 0f ;
    private SpriteRenderer sprite; 
    private Rigidbody2D rb;  
    private Animator anim;
    private BoxCollider2D coll;

    private void Start()
    {
        GetComponents();

    }

    private void GetComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        JumpInput();
        UpdateAnimationState();
    }

    void FixedUpdate()
    {
        HorizontalMovement();
    }
    private void HorizontalMovement()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private void JumpInput()
    {
        if (Input.GetKey("space") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void UpdateAnimationState()
{   
         if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true; 
        }

        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        } 

        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        
        anim.SetInteger("state", (int)state);
 
       }
       private bool IsGrounded() 
       {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
       }
       
}

