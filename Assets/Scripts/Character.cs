using UnityEngine;
using UnityEngine.UI; 

public abstract class Character : MonoBehaviour
{
    private int health;
    public int Health { get => health; set => health = (value < 0) ? 0 : value; }

    protected Animator anim;
    protected Rigidbody2D rb;
    
    [SerializeField] protected Slider healthBar; // เพิ่มมา
    protected int maxHealth;

    public void Intialize(int StartHealth)
    {
        maxHealth = StartHealth;
        Health = StartHealth;
        Debug.Log($"{this.name} is initialed Health: {this.Health}");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UpdateHealthBar(); //เพิ่มส่วนน้เข้ามา
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took {damage} damage! Current Health: {Health}.");
        UpdateHealthBar(); //เพิ่มเข้ามา
        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log($"{this.name} is dead and destroyed.");
            return true;
        }
        return false;
    }

    protected void UpdateHealthBar() 
    {
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth; // ใช้ในการตรวจสอบ Max hp Bar จะได้รู้ว่าเลือดสูงสุดมีเท่าไหร
            healthBar.value = Health; // ตั้งค่า Hp ปัจจุบันให้ตรงกับ Bar ที่ใส่เข้าไป  ##เพิ่มเติม Intialize ใส่เข้าไปตรงนั้นเพราะ กําหนดค่าเลือดทันทีที่ตัวละครนั้นถูกสร้างขึ้นมา
            // เเละใส่ใน Meathod TakeDamage เพราะจะได้อัปเดท Hp ทันทีที่โดนดาเมจ
        }
    }
}