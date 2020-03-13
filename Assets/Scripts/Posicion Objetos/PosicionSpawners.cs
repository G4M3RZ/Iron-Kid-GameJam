using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PosicionSpawners : MonoBehaviour
{
    public bool _activarEditor;

    [Range(0, 150)]
    public float _spawnersEjeZ;
    [Range(-10, 10)]
    public float _spawnersEjeY;
    [Range(0, 10)]
    public float _separacionSpawners = 2.4f;

    public GameObject[] _spawners;

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
            _spawners[0].transform.localPosition = new Vector3(-_separacionSpawners, _spawnersEjeY, _spawnersEjeZ);
            _spawners[1].transform.localPosition = new Vector3(0, _spawnersEjeY, _spawnersEjeZ);
            _spawners[2].transform.localPosition = new Vector3(_separacionSpawners, _spawnersEjeY, _spawnersEjeZ);
        }
    }
}
