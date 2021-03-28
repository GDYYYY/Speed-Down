using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float xSpeed;
    public float ySpeed;
    public float force;
    public float checkRadius;
  //  public float checkHight;

    public LayerMask platformMask;
  //  public LayerMask blowerMask;

    public GameObject checkPoint;
    private Collider2D blower;
    private bool isOnGround;
    private bool isBlown;

    private float blowForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isBlown = false;
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(checkPoint.transform.position, checkRadius, platformMask);
        animator.SetBool("isOnGround",isOnGround);
        //isBlown = false;
        //if (!isOnGround)
        //{
        //    Vector2 posVector2 = checkPoint.transform.position;

        //    blower = Physics2D.OverlapBox(new Vector2(posVector2.x,posVector2.y-checkHight/2), new Vector2(2*checkRadius,checkHight), 0,blowerMask|~platformMask);
        //    Debug.Log(blower.gameObject.layer);
        //    isBlown = blower;
        //}

        Move();
    }

    void Move()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        if (!isOnGround) yInput = 0;
        //jump();
       // blow();
        rb.velocity = new Vector2(xInput * xSpeed, rb.velocity.y+yInput*ySpeed);
        if (xInput != 0)
            transform.localScale = new Vector3(xInput, 1, 1);
        animator.SetFloat("speed",Mathf.Abs(rb.velocity.x));
        animator.SetBool("isJump", rb.velocity.y > 0 ? true : false);
    }

    void blow()
    {
        if (isBlown)
        {
            blowForce = 1 / (checkPoint.transform.position.y - blower.transform.position.y);
            Debug.Log(blowForce);
            rb.AddForce(new Vector2(0.0f, force * blowForce));
        }
    }

    void jump()
    {
        if (isBlown)
        {
            blowForce = 1 / (checkPoint.transform.position.y - blower.transform.position.y);
            Debug.Log(blowForce);
            rb.AddForce(new Vector2(0.0f, force * blowForce));
        }
    }

    public void Die()
    {
        //Debug.Log("Die");
        GameManager.GameOver(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            Die();
        }

    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            Die();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 posVector2 = checkPoint.transform.position;
        Gizmos.color=Color.blue;
        Gizmos.DrawWireSphere(checkPoint.transform.position,checkRadius);
    //    Gizmos.DrawWireCube(new Vector2(posVector2.x, posVector2.y - checkHight / 2), new Vector3(2*checkRadius,checkHight));
    }
}
