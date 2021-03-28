using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blown : MonoBehaviour
{
    public LayerMask blowerMask;
    private Rigidbody2D rb;
    private float blowForce;
    public float force;
    private bool isBlown;
    private Collider2D blower;
    public GameObject checkPoint;
    public float checkRadius;
    public float checkHight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isBlown = false;
        //if (!isOnGround)
        {
            Vector2 posVector2 = checkPoint.transform.position;

            blower = Physics2D.OverlapBox(new Vector2(posVector2.x,posVector2.y-checkHight/2), new Vector2(2*checkRadius,checkHight),0, blowerMask);
           // Debug.Log(blower.gameObject.layer);
            isBlown = blower;
            blow();
        }
    }
    void blow()
    {
        if (isBlown)
        {
            blowForce = 1 / (checkPoint.transform.position.y - blower.transform.position.y);
           // Debug.Log(blowForce);
            rb.AddForce(new Vector2(0.0f, force * blowForce));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 posVector2 = checkPoint.transform.position;
        Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(checkPoint.transform.position, checkRadius); 
        Gizmos.DrawWireCube(new Vector2(posVector2.x, posVector2.y - checkHight / 2), new Vector3(2*checkRadius,checkHight));
    }
}
