using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameObject PointTop;
    public GameObject PointBottom;
    public Text Score;

    bool check = true;
    int score = 1;

    public ParticleSystem Dead;

    void Start()
    {
        Dead.Clear();
        Dead.Stop();
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

    }

    void Change()
    {
        check = !check;
    }

    void Crash()
    {
        Dead.Clear();
        Dead.Play();
    }

    void Increment()
    {
        score++;
        Score.text = score.ToString() + "Pts";
    }
}
