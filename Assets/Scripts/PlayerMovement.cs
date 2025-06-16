using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathFling = new Vector2 (30f, 30f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;
    bool isAlive = true;

    public InputAction gunFire;
    private PlayerControls controls;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        ClimbLadder();
        Bounce();        
        Die();
    }

    void OnFire(InputValue value)
    {
        Debug.Log("Boom");
        if (!isAlive) { return; }  

        Instantiate(bullet, gun.position, transform.rotation);     
        FindFirstObjectByType<Sounds>().GunFireMethod();   
    }

    public void DisablePlayer()
    {
        isAlive = false;
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }

        try
        {
            moveInput = value.Get<Vector2>();
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error reading input: {ex.Message}");
        }
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }        
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if(value.isPressed)
        {
            myRigidbody.linearVelocity += new Vector2 (0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.linearVelocity.y);
        myRigidbody.linearVelocity = playerVelocity;

        bool playerHazHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHazHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.linearVelocity.x), 1f);

        }
    }

    void Bounce()
    {
        bool isMovingDown = false;

         // Check if the player has significant negative vertical speed (falling)
        if (myRigidbody.linearVelocityY < -Mathf.Epsilon)
        {
            isMovingDown = true;
        }

        //if (Physics2D.OverlapBox(myFeetCollider.bounds.center, myFeetCollider.bounds.size, 0, )

        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Bouncing")))
        {
            FindFirstObjectByType<Sounds>().MushroomBounceMethod();
        }
    }

    void ClimbLadder()
    {
        //if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        if (!Physics2D.OverlapBox(myFeetCollider.bounds.center, myFeetCollider.bounds.size, 0, LayerMask.GetMask("Climbing")))
        {
            myRigidbody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false);
            return; 
        }

        Debug.Log("climb");
        
        Vector2 climbVelocity = new Vector2 (myRigidbody.linearVelocity.x, moveInput.y * climbSpeed);
        myRigidbody.linearVelocity = climbVelocity;  
        myRigidbody.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.linearVelocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
    }

    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            myRigidbody.linearVelocity = deathFling;
            FindFirstObjectByType<Sounds>().DeathSoundMethod();
            StartCoroutine(HandleDeath());
        }
    }

    IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(3f); // Adjust the time as needed
        FindFirstObjectByType<GameSession>().ProcessPlayerDeath();
    }
}
