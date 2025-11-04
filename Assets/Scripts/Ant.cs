using UnityEngine;

public class Ant : Enemy
{
    public Vector2 velocity;
    public Transform[] movePoints;

    void Start()
    {
        base.Intialize(120);
        DamageHit = 20;
        
        // Set speed and direction of movement
        velocity = new Vector2(-1.0f, 0.0f); // Start with moving left
    }

    void FixedUpdate()
    {
        Behavior();
    }

    public override void Behavior()
    {
        // Move from current position
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        // Move left
        if (velocity.x < 0 && rb.position.x <= movePoints[0].position.x)
        {
            Flip();
        }
        
        // Move right
        if (velocity.x > 0 && rb.position.x >= movePoints[1].position.x)
        {
            Flip();
        }
    }

    // Flip ant to the opposite direction
    public void Flip()
    {
        velocity.x *= -1; // Change direction of movement
        
        // Flip the image
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}