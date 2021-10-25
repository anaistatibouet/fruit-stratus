using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public Transform groundCheck;
  	public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator anim; 
    public SpriteRenderer spriteRenderer;

    private bool isJumping;
    private bool isGrounded;
    private Vector3 velocity = Vector3.zero;
	private float horizontalMovement;


	void Update(){
	   
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
        }
        
        FlipPlayer(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        anim.SetFloat("Speed", characterVelocity);
	}
    
    void FixedUpdate()
    { 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    // Permet de retourner le personnage quand il recule.
    void FlipPlayer(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
	
	// Visual test
 	private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
