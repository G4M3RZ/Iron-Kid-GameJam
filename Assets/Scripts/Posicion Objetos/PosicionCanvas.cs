using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[ExecuteInEditMode]
public class PosicionCanvas : MonoBehaviour
{
    public bool _activarEditor;

    [Range(0,0.01f)]
    public float _size;
    [Range(0,10)]
    public float _canvasEjeY;
    [Range(0,10)]
    public float _canvasEjeZ;
    // Start is called before the first frame update
    void Start()
    {
        _activarEditor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_activarEditor)
        {
            transform.localScale = new Vector3(_size, _size, 1);
            transform.localPosition = new Vector3(0, _canvasEjeY, _canvasEjeZ);
        }
    }
}
