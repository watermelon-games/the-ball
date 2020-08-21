using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform transform;
    
    void Start()
    {
    }

    void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, 0.2f);
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 1;
    }
}
