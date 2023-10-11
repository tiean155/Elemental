using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float speed;
    public float jump;

    private float Move;

    public Rigidbody2D rb;

    public bool isJumping;
    public float dirX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Move = 3f;
        }
        else
        {
            Move = 1.2f;
        }
        dirX = Input.GetAxis("Horizontal") * Move;
           
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (dirX, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }
}
