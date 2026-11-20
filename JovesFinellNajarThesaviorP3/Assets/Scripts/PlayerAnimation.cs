using UnityEngine;

public class PlayerAnimation : MonoBehaviour 
{
    private Animator anim;

    void Start() 
    {
        // Grab the Animator component attached to this player
        anim = GetComponent<Animator>();
    }

    void Update() 
    {
        // Check for WASD or Arrow key input (-1, 0, or 1)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // If either axis is not zero, the player is moving
        bool moving = (moveX != 0 || moveY != 0);

        // Send the true/false value to the Animator
        anim.SetBool("moving", moving);

        // Flip the character left or right
        if (moveX < 0)
        {
            // Moving left: flip X scale to negative
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (moveX > 0)
        {
            // Moving right: reset X scale to positive
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}