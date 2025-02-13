using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Movement : MonoBehaviour
{
    // Movement speed of the player
    [SerializeField] private float MovementSpeed = 1;
    [SerializeField] private float DashSpeed = 2;
    [SerializeField] private float DashCoolDown = 5;
    [SerializeField] private float dashTime = 1;
    public Rigidbody2D _rigidbody;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject GameObject;
    [SerializeField] private float jumpsAmount;
    [SerializeField] private GameObject Player;


    bool dashOnCD = false;
    bool dashing = false;
    public Animator animator;
    Vector2 movement;
    public AudioSource src;
    public AudioClip sfx1;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("hit ground jumps reset");
            jumpsAmount = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleDash();
        HandleJumping();
        HandleMovement();
    }

    void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !dashOnCD)
        {
            _rigidbody.AddForce(transform.right * DashSpeed, ForceMode2D.Impulse);
            animator.SetFloat("Speed", Mathf.Abs(movement.x * DashSpeed));
            StartCoroutine(IsDashing());
            StartCoroutine(ResetDash());
            Debug.Log("SHIT");
            animator.SetTrigger("Dash");
        }
    }

    void HandleJumping()
    {
        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpsAmount > 0)
            {
                Debug.Log("jump");
                _rigidbody.AddForce(Vector2.up * jumpForce);
                jumpsAmount -= 1;
                src.clip = sfx1;
                src.Play();
            }
        }
    }

    IEnumerator IsDashing()
    {
        dashing = true;
        yield return new WaitForSeconds(dashTime);
        dashing = false;
    }

    void HandleMovement()
    {
        // Get horizontal movement input
        movement.x = Input.GetAxis("Horizontal") * MovementSpeed;
        movement.y = _rigidbody.linearVelocity.y;

        animator.SetFloat("Speed", Mathf.Abs(_rigidbody.linearVelocity.magnitude));


        // Flip the player model when pressing "A" or "D"
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Set the scale on the X-axis to -1
            Vector3 scale = transform.localScale;
            scale.x = -0.1f;
            transform.localScale = scale;

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // Set the scale on the X-axis to 1
            Vector3 scale = transform.localScale;
            scale.x = 0.1f;
            transform.localScale = scale;
        }
    }

    private void FixedUpdate()
    {
        if (!dashing)
            _rigidbody.linearVelocity = movement;
    }

    IEnumerator ResetDash()
    {
        dashOnCD = true;
        yield return new WaitForSeconds(DashCoolDown);
        dashOnCD = false;

    }
}