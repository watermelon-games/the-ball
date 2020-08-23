using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject ball;

    private float _waitTimeMin;
    private float _waitTimeMax;

    private Transform _transform;
    private int _score;

    private void Start()
    {
        _transform = GetComponent<Transform>();

        _waitTimeMin = 8f;
        _waitTimeMax = 2f;

        StartCoroutine(SpawnCountDown());
    }

    private void Update()
    {
        if (GameObject.Find("ball"))
        {
            _score = GameObject.Find("ball").GetComponent<Ball>().score;
        }
        
        CalculateWaitTimeByPoints(_score);
    }

    private void Repeat()
    {
        if (ball.activeSelf)
        {
            StartCoroutine(SpawnCountDown());
        }
    }

    private IEnumerator SpawnCountDown()
    {
        var waitTime = Random.Range(_waitTimeMin, _waitTimeMax);

        yield return new WaitForSeconds(waitTime);
        var duplicate = Instantiate(enemy, transform.position, Quaternion.identity);
        duplicate.tag = "Clone";
        Repeat();
    }

    private void CalculateWaitTimeByPoints(int score)
    {
        if (score > 5)
        {
            _waitTimeMin = 6f;
            _waitTimeMax = 2f;
        }

        if (score > 10)
        {
            _waitTimeMin = 4f;
            _waitTimeMax = 2f;
        }

        if (score > 20)
        {
            _waitTimeMin = 10f;
            _waitTimeMax = 2f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this);
        }
    }
}