using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D enemyRB;
    Animator enemyAnimator;
    public float moveSpeed = 1f;

    bool facingRight = true;

    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();

        if (enemyRB.velocity.x < 0 && facingRight)
        {
            //yüzünü sola çevir
            FlipFace();
        }
        else if (enemyRB.velocity.x > 0 && !facingRight)
        {
            //yüzünü saða çevir
            FlipFace();
        }


    }

    void HorizontalMove()
    {
        enemyRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, enemyRB.velocity.y);
        enemyAnimator.SetFloat("enemySpeed", Mathf.Abs(enemyRB.velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        enemyAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}
