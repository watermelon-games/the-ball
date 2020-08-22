using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameObject Target;
    public GameObject PointTop;
    public GameObject PointBottom;
    public Text Score;

    bool check = true;
    int score = 0;
    bool lastTop = false;
    bool lastBottom = false;

    public ParticleSystem Dead;

    void Start()
    {
        Dead.Clear();
        Dead.Stop();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            Change();
            SetLastPoint(collision.gameObject.name);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Crash();
        }
    }
    
    void Update()
    {
        if (check)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointTop.transform.position, 2f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, PointBottom.transform.position, 2f * Time.deltaTime);
        }
        
        transform.rotation *= Quaternion.Euler(0f, 0f, 0.8f);
    }

    void Change()
    {
        check = !check;
    }

    void SwitchPosition()
    {
        PointTop.SetActive(false);
        PointTop.transform.position = new Vector3(PointTop.transform.position.x, -1.3f, 0.0915f);
        PointTop.SetActive(true);
    }

    void SetLastPoint(string pointName)
    {
        NeedIncrement(pointName);
        
        if (pointName == "point_top")
        {
            lastTop = true;
            lastBottom = false;
        }
        else
        {
            lastTop = false;
            lastBottom = true;
        }
    }

    void Crash()
    {
        Target.SetActive(false);
        Dead.Clear();
        Dead.Play();
    }

    void NeedIncrement(string pointName)
    {
        if (pointName == "point_top" && !lastTop)
        {
            Increment();
        }

        if (pointName == "point_bottom" && !lastBottom)
        {
            Increment();
        }
    }

    void Increment()
    {
        score++;
        Score.text = score.ToString() + " Pts";
    }
}
