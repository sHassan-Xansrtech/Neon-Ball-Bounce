using UnityEngine;

public class MotionBlurRemoval: MonoBehaviour
{
    private Vector2 previousPosition;

    private void Start()
    {
        previousPosition = transform.position;
    }

    private void LateUpdate()
    {
        // Calculate the current velocity
        Vector2 velocity = (Vector2)(transform.position - (Vector3)previousPosition) / Time.deltaTime;

        // Adjust the fixed timestamp based on the velocity
        float fixedTimestamp = Mathf.Clamp(Time.fixedDeltaTime - velocity.magnitude * Time.fixedDeltaTime, 0f, Time.fixedDeltaTime);

        // Update the physics timestep
        Time.fixedDeltaTime = fixedTimestamp;

        previousPosition = transform.position;
    }
}
