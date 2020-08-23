using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameObject target;
    public GameObject enemy;
    public GameObject pointTop;
    public GameObject pointBottom;
    public ParticleSystem dead;
    public Text scoreText;

    public int score = 0;

    private bool _check = true;
    private bool _isLastTop = false;
    private bool _isLastBottom = false;

    private void Start()
    {
        dead.Clear();
        dead.Stop();
        Restart();
    }

    private void Update()
    {
        if (_check)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, pointTop.transform.position, 2f * Time.deltaTime);
        }
        else
        {
            transform.position =
                Vector3.MoveTowards(transform.position, pointBottom.transform.position, 2f * Time.deltaTime);
        }

        transform.rotation *= Quaternion.Euler(0f, 0f, 0.8f);
    }

    public void Change()
    {
        _check = !_check;
    }

    private void Restart()
    {
        var clones = GameObject.FindGameObjectsWithTag("Clone");

        foreach (var clone in clones)
        {
            Destroy(clone);
        }

        scoreText.text = "0 Pts";
        score = 0;

        target.transform.position = new Vector3(0.5f, -0.1f, 0.0f);
        enemy.transform.position = new Vector3(-1.8f, -0.1f, 0.0f);
    }

    private void ChangePointPosition(string pointName)
    {
        if (pointName == "point_top")
        {
            var tempTransform = pointTop.transform.position;
            tempTransform.x = Random.Range(-1.9f, 0.7f);
            pointTop.transform.position = tempTransform;
        }
        else
        {
            var tempTransform = pointBottom.transform.position;
            tempTransform.x = Random.Range(0.7f, -1.9f);
            pointBottom.transform.position = tempTransform;
        }
    }

    private void Crash()
    {
        target.SetActive(false);
        dead.transform.position = target.transform.position;
        dead.Clear();
        dead.Play();
        SceneManager.LoadScene("Menu");
    }

    private void SetLastPoint(string pointName)
    {
        NeedIncrement(pointName);

        if (pointName == "point_top")
        {
            _isLastTop = true;
            _isLastBottom = false;
        }
        else
        {
            _isLastTop = false;
            _isLastBottom = true;
        }
    }

    private void NeedIncrement(string pointName)
    {
        if (pointName == "point_top" && !_isLastTop)
        {
            Increment();
        }

        if (pointName == "point_bottom" && !_isLastBottom)
        {
            Increment();
        }
    }

    private void Increment()
    {
        score++;
        scoreText.text = score.ToString() + " Pts";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            Change();
            SetLastPoint(collision.gameObject.name);
            ChangePointPosition(collision.gameObject.name);
        }

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Clone"))
        {
            Crash();
        }
    }
}