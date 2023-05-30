using System.Collections;
using UnityEngine;

namespace Assets.Script
{
    public class CustomBouncyBall : MonoBehaviour
    {
        //[SerializeField] private float smoothTime = 0.1f;

       /* private Rigidbody2D rb;
       // private Vector2 velocity;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
           
        }

        private void FixedUpdate()
        {
          //  velocity = Vector2.Lerp(velocity, rb.velocity, smoothTime);
          //  rb.velocity = velocity;
        }*/
        public void SetBallAtSpawn(Transform inTransform)
        {
            transform.position = inTransform.position;
        }
    }
}
