using UnityEngine;
using UnityEngine.InputSystem;

public class Player_movement : MonoBehaviour
{
    public InputActionAsset inputActions;

    [SerializeField]
    private float MovementSpeed;

    [SerializeField]
    private Rigidbody2D rb;

    private Vector2 moveInput;

    bool facingRight = true;

    private void Awake()
    {
       
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * MovementSpeed;

        if (rb.linearVelocityX < 0 && facingRight)
        {
            Flip();
        }

        if (rb.linearVelocityX > 0 && !facingRight)
        {
            Flip();
        }
    }

    

    public void Move(InputAction.CallbackContext context)
    {
       moveInput = context.ReadValue<Vector2>();
       //Debug.Log("toimii?" + context);
    }

    public void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
}
