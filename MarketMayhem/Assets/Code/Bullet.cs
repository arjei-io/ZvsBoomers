using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private int damage = 100;
    public float speed = 20f;
    private float aliveTimer = 3f;

    
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
        Destroy(gameObject, aliveTimer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Debug.Log(collision.tag);

        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.tag == "Player")
        {
            return;
        }

        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

        Destroy(gameObject, aliveTimer);
       
    }

    public void AllBullets()
    {
        Destroy(gameObject);
    }
}
