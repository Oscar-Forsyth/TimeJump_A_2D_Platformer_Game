using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5;
    public float jumpForce = 10;
    public bool canJump = true;

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

        Move(dir);
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
            canJump = false;
        }
    }

    private void Move(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity += Vector2.up * jumpForce;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Ground"))
        {
            canJump = true;
        }
    }
}
