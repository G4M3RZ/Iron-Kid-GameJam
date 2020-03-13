using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] _obstaculos;
    public bool _activarSpawn;

    private int _randomObs;

    void Start()
    {
        _activarSpawn = false;
    }

    void Update()
    {
        if (_activarSpawn)
        {
            _randomObs = Random.Range(0, _obstaculos.Length);
            GameObject _instance = Instantiate(_obstaculos[_randomObs], transform.localPosition, transform.localRotation) as GameObject;
            _instance.transform.parent = this.gameObject.transform;
            _activarSpawn = false;
        }
    }
}
