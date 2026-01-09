using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Live_system : MonoBehaviour
{
    [SerializeField] private int currentLives;
    [SerializeField] private int maxLives = 3;

    //private float resetTimer = 10f;
    public Enemy enemy;
    private Rigidbody2D rb;
    private Bullet bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        bullet = GetComponent<Bullet>();
        currentLives = maxLives;
    }

    // Update is called once per frame
    public void Update()
    {
        if (currentLives <= 0)
        {
            Die();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
            currentLives--;
            Time.timeScale = 0;
            Spawn();
            StartCoroutine(Timer());
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(go);
        }

        foreach (GameObject go1 in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(go1);
        }

        
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        rb.transform.position = new Vector3(1.5f, -4, 0);
    }

    public void ContinueLevel()
    {
        Time.timeScale = 1;
    }

    IEnumerator Timer()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSecondsRealtime(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        ContinueLevel();
    }

}
