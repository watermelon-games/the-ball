using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform transform;
    public GameObject enemy;
    public GameObject ball;

    void Start()
    {
        StartCoroutine(SpawnCountDown());
    }

    void Repeat()
    {
        if (ball.activeSelf) {
            StartCoroutine(SpawnCountDown());
        }
    }

    IEnumerator SpawnCountDown()
    {
        yield return new WaitForSeconds(3f);
        // Instantiate(enemy, transform.position, Quaternion.identity);
        Repeat();
    }
}
