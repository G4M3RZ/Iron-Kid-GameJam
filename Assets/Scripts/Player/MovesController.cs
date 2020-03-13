using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesController : MonoBehaviour
{
    private Vector3 _startPos;
    public float _limit;

    private float _moves;

    public Swipe _control;
    public CanvasSelector _mainCanvas;

    private void Start()
    {
        _startPos = transform.position;
        _moves = 0;

        if (_mainCanvas._selector == 2)
            this.enabled = false;
    }
    private void Update()
    {
        _startPos = new Vector3(_moves, transform.localPosition.y, transform.localPosition.z);
        transform.position = Vector3.Lerp(transform.localPosition, _startPos, Time.deltaTime * 10);

        if (_control._swipeLeft)
        {
            Left();
        }

        if (_control._swipeRight)
        {
            Right();
        }
    }
    void Left()
    {
        if(_moves > -_limit)
        {
            _moves -= _limit;
        }
    }
    void Right()
    {
        if(_moves < _limit)
        {
            _moves += _limit;
        }
    }
}
