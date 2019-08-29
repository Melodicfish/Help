using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    private float defultSpeed;
    private float moveInput;
    public float jumpForce;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private bool hasJumped=false;
   [HideInInspector] public bool canMove=true;
    private float moveSpeed=10f;
    public Transform targetPos;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defultSpeed = speed;
        canMove = true;
    }

    private void Update()
    {
        if (canMove)
        {
            //Air Speed Adjustment
            if (!isGrounded) { speed = defultSpeed / 1.5f; }
            else if (isGrounded) { speed = defultSpeed; }

            // Ground Check
            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

            //Movement left or right flip Sprite
            if (moveInput > 0) { transform.eulerAngles = new Vector3(0, 0, 0); }
            else if (moveInput < 0) { transform.eulerAngles = new Vector3(0, 180, 0); }

            //Jump 
            if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                hasJumped = true;
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
            }
            //Still have air time
            if (Input.GetKey(KeyCode.Space) && isJumping)
            {
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else { isJumping = false; }
            }
            //check is jump key has been released
            if (Input.GetKeyUp(KeyCode.Space)) { isJumping = false; }
        }
        else if (!canMove) { moveToPosition(); }
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
    }

  
    private void moveToPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPos.transform.position.x, transform.position.y), moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetPos.transform.position) < .1f)
        {
            canMove = true;
        }

    }



}
