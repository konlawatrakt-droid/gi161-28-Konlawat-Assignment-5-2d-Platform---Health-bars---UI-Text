using Unity.VisualScripting;
using UnityEngine;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
                banana.InitWeapon(20, this);

            WaitTime = 0.0f;
        }
    }
    void Start()
    {
        base.Intialize(100);
        ReloadTime = 1.0f;
        WaitTime = 0.0f;
    }

    public void OnHItwith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHItwith(enemy);
        }
    }

    void Update()
    {
        //Debug.Log("Fixed Update: " + Time.fixedDeltaTime);
        Shoot();
    }

    void FixedUpdate()
    {

        WaitTime += Time.fixedDeltaTime;
    }
} 