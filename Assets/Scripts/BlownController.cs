//无法作用力
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlownController : MonoBehaviour
{
    private bool isBlowing;
    public Rigidbody2D rb;
    private float blowForce;
    private Collider2D blower;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponentInParent<Rigidbody2D>();
       isBlowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isBlowing = true;
            //rb = other.GetComponent<Rigidbody2D>();
            //Debug.Log($"aaaa"+rb.transform.position.y);
            blow();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isBlowing = false;
        }
    }
    void blow()
    {
        if (isBlowing)
        {
            blowForce = 1 / (rb.transform.position.y - transform.position.y);
           // Debug.Log(blowForce);
            rb.AddForce(new Vector2(0.0f, force * blowForce));
        }
    }
}
