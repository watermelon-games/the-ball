using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    public GameObject ball;
	public Transform spawnTop;
	public Transform spawnBottom;

	private Transform _transform;
    
	private void Start()
    {
		_transform = GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
	        var randomSpawn = Random.Range(1, 2);
	        
	        Debug.Log(randomSpawn);
	        
			if (ball.activeSelf)
			{
				Respawn(randomSpawn == 1 ? spawnTop : spawnBottom);
			} else {
				Destroy(target);
			}
        }
    }

    private void Update()
    {
        _transform.rotation *= Quaternion.Euler(0f, 0f, 0.3f);
        _transform.position += new Vector3(1, 0, 0) * (Time.deltaTime * 1);
    }

    private void Respawn(Transform spawn)
    {
        _transform.position = spawn.position;
    }
}
