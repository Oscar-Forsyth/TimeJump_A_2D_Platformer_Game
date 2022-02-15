using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5;
    public float jumpForce = 10;
    public bool canJump = true;
    public Animator animator;
    public SpriteRenderer sprite;

    float currentSpeed = 0f;
    bool facingRight = true;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);

        currentSpeed = Input.GetAxisRaw("Horizontal") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
        checkFalling();

        Move(dir);
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
            canJump = false;
        }

    }
    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    private void Move(Vector2 dir)
    {
        if (currentSpeed > 0 && !facingRight)
        {
            Flip();
        }
        if (currentSpeed < 0 && facingRight)
        {
            Flip();
        }
        rb.velocity = new Vector2(dir.x * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity += Vector2.up * jumpForce;
        animator.SetBool("isJumping", true);

    }
    public void checkFalling()
    {
        if (rb.velocity.y < -0.1)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground") == true)
        {
            canJump = true;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
    }
}
