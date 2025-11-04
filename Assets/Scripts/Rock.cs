using UnityEngine;

public class Rock : Weapon
{
    public Rigidbody2D rb;
    public Vector2 force;
    
    public override void Move()
    {
        rb.AddForce(force);
    }

    public override void OnHitWith(Character character)
    {
        if (character is Player)
            character.TakeDamage(this.damage);
        
    }
    void Start()
    {
        damage = 40;
        force = new Vector2(GetShootDirection() * 90, 400);
        Move();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
