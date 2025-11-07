using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float minSize = 0.5f;
    public float maxSize = 2.0f;
    public float minSpeed = 50f;
    public float maxSpeed = 100f;
    public float maxSpin = 50f;
    Rigidbody2D rb;
    void Start()
    {
        float obSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(obSize, obSize, 1);
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        float obSpeed = randomSpeed * (maxSize / obSize);
        Vector2 obDirection = Random.insideUnitCircle;
        float obSpin = Random.Range(-maxSpin, maxSpin);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(obDirection * obSpeed);
        rb.AddTorque(obSpin);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
