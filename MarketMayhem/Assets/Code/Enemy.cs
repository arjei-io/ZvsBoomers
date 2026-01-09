using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int health = 100;

    private Rigidbody2D rb;


    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Enemy_Die();
        }
    }

    public void Enemy_Die()
    {

        // Set to destroy rather than SetActive because performance is not important now
        // Will pool later

        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
