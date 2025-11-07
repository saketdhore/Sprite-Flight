using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject BoosterFlame;
    public float thrust = 5f;
    public float maxSpeed = 5f;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Mouse.current.leftButton.isPressed)
        {
            //get mouse position and get direction
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;

            //face the mouse click direction
            transform.up = direction;

            //thrust towards the mouse click
            rb.AddForce(direction * thrust);

            //clamp speed
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            BoosterFlame.SetActive(true);
        }
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            BoosterFlame.SetActive(false);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
