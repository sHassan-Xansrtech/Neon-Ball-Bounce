using Assets.Script;
using UnityEngine;


public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPosition;
    private int defaultForce;

    [SerializeField, Range(0, 30)] private int _initialMinValue = 10;
    [SerializeField, Range(0, 30)] private int _initialMaxValue = 16;
    private Rigidbody2D _ballRB;

    private CustomBouncyBall _ball;

    public void SpawnBall()
    {
        if (_ball != null)
        {
            Destroy(_ball.gameObject);
            _ball = null;
        }

        GameObject ballGO = Instantiate(ballPrefab, spawnPosition.position, Quaternion.identity);
        if (ballGO != null)
        {
            _ball = ballGO.GetComponent<CustomBouncyBall>();
            _ballRB = ballGO.GetComponent<Rigidbody2D>();
        }

        if (_ball == null)
        {
            Debug.LogError("Something went very wrong. Cannot spawn ball");
            return;
        }
        _ballRB.AddForce(Vector2.right * Random.Range(_initialMinValue, _initialMaxValue), ForceMode2D.Impulse);

        _ball.SetBallAtSpawn(spawnPosition);
    }
}
