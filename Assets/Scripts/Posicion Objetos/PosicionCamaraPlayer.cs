using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PosicionCamaraPlayer : MonoBehaviour
{
    public bool _activarEditor;

    public GameObject _camara;
    [Range(0, 10)]
    public float _camaraEjeY = 1.8f;
    [Range(0, 10)]
    public float _camaraEjeZ = 0f;
    [Range(0, 90)]
    public float _camaraRotX = 0f;

    public GameObject _player;
    [Range(-10, 10)]
    public float _playerEjeY = 0.5f;
    [Range(0, 10)]
    public float _playerEjeZ = 4f;

    void Start()
    {
        _activarEditor = false;
    }

    void Update()
    {
        if (_activarEditor)
        {
            _camara.transform.localPosition = new Vector3(0, _camaraEjeY, _camaraEjeZ);
            _camara.transform.localEulerAngles = new Vector3(_camaraRotX, 0, 0);
            _player.transform.localPosition = new Vector3(0, _playerEjeY, _playerEjeZ);
        }
    }
}
