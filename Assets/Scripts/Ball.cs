﻿using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameObject target;
    public GameObject pointTop;
    public GameObject pointBottom;
    public ParticleSystem dead;
    public Text score;

    private bool _check = true;
    private int _score = 0;
    private bool _isLastTop = false;
    private bool _isLastBottom = false;
    
    private void Start()
    {
        dead.Clear();
        dead.Stop();
    }
    
    private void Update()
    {
        if (_check)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointTop.transform.position, 2f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointBottom.transform.position, 2f * Time.deltaTime);
        }
        
        transform.rotation *= Quaternion.Euler(0f, 0f, 0.8f);
    }

    private void Change()
    {
        _check = !_check;
    }
    
    private void ChangePointPosition(string pointName)
    {
        if (pointName == "point_top")
        {
            var tempTransform = pointTop.transform.position;
            tempTransform.x = Random.Range(-2.4f, 0.8f);
            pointTop.transform.position = tempTransform;
        }
        else
        {
            var tempTransform = pointBottom.transform.position;
            tempTransform.x = Random.Range(0.8f, -2.4f);
            pointBottom.transform.position = tempTransform;
        }
    }
    
    private void Crash()
    {
        target.SetActive(false);
        dead.Clear();
        dead.Play();
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
        _score++;
        score.text = _score.ToString() + " Pts";
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            Change();
            SetLastPoint(collision.gameObject.name);
            ChangePointPosition(collision.gameObject.name);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Crash();
        }
    }
}
