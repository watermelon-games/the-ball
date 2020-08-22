using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject ball;

    private readonly float _waitTimeMin = 7.5f;
    private readonly float _waitTimeMax = 3.5f;
    
    private Transform _transform;
    private int _score;
    
    private void Start()
    {
        _transform = GetComponent<Transform>();
        
        StartCoroutine(SpawnCountDown());
    }
    
    private void Update()
    {
        _score = GameObject.Find("ball").GetComponent<Ball>().score;
    }

    private void Repeat()
    {
        if (ball.activeSelf) {
            StartCoroutine(SpawnCountDown());
        }
    }

    private IEnumerator SpawnCountDown()
    {
        var waitTime =  Random.Range(_waitTimeMin, _waitTimeMax);
        
        yield return new WaitForSeconds(waitTime);
        Instantiate(enemy, transform.position, Quaternion.identity);
        Repeat();
    }
}
