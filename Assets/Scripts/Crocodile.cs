using UnityEngine;

public class Crocodile : Enemy, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    [SerializeField] private float atkRange;
    public Player player;

    void Start()
    {
        base.Intialize(50);
        DamageHit = 30;
        
      
        atkRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();
        WaitTime = 0.0f;
        ReloadTime = 1.0f;
    }

    void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime; 
        Behavior();
    }

    public override void Behavior() 
    {
        // Find distance between Crocodile and Player
        Vector2 distance = player.transform.position - transform.position;

        if (distance.magnitude <= atkRange)
        {
            Debug.Log($"{player.name} is in the {this.name}'s atk range!");
            Shoot();
        }
    }

    public void Shoot()  
    {
        if (WaitTime >= ReloadTime && Bullet != null) 
        {
            anim.SetTrigger("Shoot");
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Rock rock = bullet.GetComponent<Rock>();
            if (rock != null)
                rock.InitWeapon(20, this);
            
            WaitTime = 0.0f;
            Debug.Log($"{this.name} shoots rock to the {player.name}!");
        }
    }
}