using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private SpriteRenderer Sprite;

    private float dirX = 0f;

    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * 7, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 14f);

        }

        if (dirX > 0f)
        {
            Sprite.flipX = true;
        }
        if (dirX < 0f)
        {
            Sprite.flipX = false;
        }
    }



    private bool IsGrounded => Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .5f, jumpableGround);
}
    