using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHit : MonoBehaviour
{
    private Animator animator;
    //public GameObject checkPoint;
    // public bool isHit;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isHit", true);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isHit", false);
        }
    }
}
