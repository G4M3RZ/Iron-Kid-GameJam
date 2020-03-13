using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LimitMovePlayer : MonoBehaviour
{
    public bool _activarEditor;

    [Range(0,10)]
    public float _separacion;
    [Range(0,10)]
    public float _ejeZ;

    public GameObject[] _limites;
   
    void Start()
    {
        _activarEditor = false;
    }

    void Update()
    {
        if (_activarEditor)
        {
            _limites[0].transform.localPosition = new Vector3(-_separacion, 0, _ejeZ);
            _limites[1].transform.localPosition = new Vector3(_separacion, 0, _ejeZ);
        }
    }
}
