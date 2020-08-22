using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform transform;
    public GameObject Enemy;
    
    void Start()
    {
        StartCoroutine(SpawnCountDown());
    }

    void Repeat()
    {
        StartCoroutine(SpawnCountDown());
    }

    IEnumerator SpawnCountDown()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(Enemy, transform.position, Quaternion.identity);
        Repeat();
    }
}
