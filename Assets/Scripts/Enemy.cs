using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform transform;
    public GameObject target;
	public Transform spawnTop;
	public Transform spawnBottom;
    
    void Start()
    {
    }

	void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Respown(spawnBottom);
        }
    }

    void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, 0.2f);
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 1;
    }

	void Respown(Transform spawn)
    {
        transform.position = new Vector3(1, spawn.position.x, spawn.position.y) * Time.deltaTime * 1;
    }
}
