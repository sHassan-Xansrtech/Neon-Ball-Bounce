using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    public float bounciness = 0.8f;
    public float gravity = 9.81f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Apply gravity
        rb.velocity += Vector2.down * gravity * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Calculate the force of impact
        float impactForce = collision.relativeVelocity.magnitude;

        // Calculate the bounce direction based on the collision normal
        Vector2 bounceDirection = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);

        // Apply the bounce force with reduced intensity based on bounciness and impact force
        rb.velocity = bounceDirection * impactForce * bounciness;
    }
    public void SetBallAtSpawn(Transform inTransform)
    {
        transform.position = inTransform.position;
    }
}
