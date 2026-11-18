using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
   private void Update()
    {
        Jump();
    }

    //create a private method for player movement
    private void MovePlayer()
    {
        BitVector32 movement = new BitVector32(0);

    }
    //create a private method for player jumping
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }







}

