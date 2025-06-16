using System;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UIElements;

public class EnemyMoovement : MonoBehaviour
{
    [SerializeField] float movespeed = 1f;
    Rigidbody2D myRigidbody;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        myRigidbody.linearVelocity = new Vector2(movespeed, 0f);
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        movespeed = -movespeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
        // this works but doesn't take into account velocity
        //transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
        transform.localScale = new Vector2 (-(Mathf.Sign(myRigidbody.linearVelocity.x)), 1f);
    }
}