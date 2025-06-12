using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RobotVacuum : MonoBehaviour
{
    public float speed = 2f;
    private Vector2 direction;
    private Rigidbody2D rb;

    private Vector2 lastPosition;
    private float stuckTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Random.insideUnitCircle.normalized;
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, lastPosition) < 0.01f)
        {
            stuckTime += Time.deltaTime;
            if (stuckTime > 1f)
            {
                direction = Random.insideUnitCircle.normalized; // ham doi huong random
                stuckTime = 0f;
            }
        }
        else
        {
            stuckTime = 0f;
        }

        lastPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0)
        {
            Vector2 normal = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, normal).normalized;

            float randomAngle = Random.Range(-45f, 45f);
            direction = Quaternion.Euler(0, 0, randomAngle) * direction;
            direction.Normalize();
        }
    }

    public void IncreaseSpeed()
    {
        speed = Mathf.Min(speed + 1f, 10f); // ghan max speed la 10 
    }

    public void DecreaseSpeed()
    {
        speed = Mathf.Max(0f, speed - 1f);
    }
}
