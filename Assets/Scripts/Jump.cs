using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float maxJumpForce = 0.3f;

    [SerializeField]
    private float jumpBoost;

    [SerializeField]
    private int maxJumps = 2;

    private int jumps;

    private Rigidbody rb;
    
    private bool isGrounded;
    
    private bool isJumping;

    private float jumpTimeCounter;
    private bool buttonPressed;

    private bool canJump = true;
    private float maxJumpTime;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetCanJump(bool value)
    {
        canJump = value;
    }

    private void RestartJumps()
    {
       jumps = maxJumps;
    }
    public void StartJump()
    {
        buttonPressed = true;

        if (!canJump)
        {
            return;
        }
        if (isGrounded || jumps > 0)
        {
            jumps--;
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            rb.linearVelocity = Vector3.up * jumpForce;
            isGrounded = false;
        }
    }
    public void EndJump()
    {
        buttonPressed = false;  
    }
    private void FixedUpdate()
    {
        HandleJump();
    }
    private void HandleJump()
    {
        if (jumpTimeCounter > 0)
        {
            rb.linearVelocity = Vector3.up * (jumpForce + jumpBoost);
            jumpTimeCounter -= Time.deltaTime;
        }
        else
        { 
            isJumping = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            RestartJumps();
            isGrounded = true;
        }
    }

}
