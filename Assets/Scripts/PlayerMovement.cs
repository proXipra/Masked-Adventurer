using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    [SerializeField] float moveSpeed = 5f;
    bool isFacingRight = false;
    float jumpPower = 6.5f;
    bool isGrounded = false;
    Rigidbody2D rb;
    Animator animator;
    public CoinManager cm;
    bool isCoinCollected = false;


    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new UnityEngine.Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new UnityEngine.Vector2(moveSpeed * horizontalInput, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            UnityEngine.Vector3 ls = transform.localScale;
            ls.x *= -1;
            transform.localScale = ls;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Coin coin = coll.GetComponent<Coin>(); // Coin objesinin Coin script'ini al
        if (coin && !coin.IsCollected()) // Eğer coin varsa ve daha önce alınmamışsa
        {
            Destroy(coll.gameObject); // Coin'i yok et
            CoinCounter.instance.totalCoin++; // Coin sayısını artır
            coin.CollectCoin(); // Coin'in alındığını işaretle
        }
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Fire") || collision.gameObject.CompareTag("Saw"))
        {
            BackToLevelStart();
        }
    }

    void BackToLevelStart()
    {
        transform.position = new Vector3(-6.96f,-2.53f,0f);
    }
}
