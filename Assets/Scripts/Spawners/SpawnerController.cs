using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private int _randObs;
    private DeadCondition _player;

    private bool _activarSpawn;
    public GameObject[] _spawners;

    [Range(0,5)]
    public float _timer;
    private float _time;

    void Start()
    {
        _activarSpawn = false;
        _time = _timer;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<DeadCondition>();
    }

    void Update()
    {
        if (!_player._dead)
        {
            if(_time > 0)
            {
                _time -= Time.deltaTime;
            }
            else
            {
                _activarSpawn = true;
                _randObs = Random.Range(0, 3);
                Spawn();
                _time = _timer;
            }
        }
    }
    void Spawn()
    {
        if (_activarSpawn)
        {
            _spawners[_randObs].GetComponent<Spawn>()._activarSpawn = true;
            _activarSpawn = false;
        }
    }
}
