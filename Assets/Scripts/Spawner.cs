using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject ball;
    public Text score;

    private readonly float _waitTimeMin = 7.5f;
    private readonly float _waitTimeMax = 3.5f;
    
    private Transform _transform;
    private int _answerInt;
    
    private void Start()
    {
        _transform = GetComponent<Transform>();
        
        StartCoroutine(SpawnCountDown());
    }
    
    private void Update()
    {
        // _answerInt = int.Parse(score.text.ToString());
        // Debug.Log(score.text);
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
