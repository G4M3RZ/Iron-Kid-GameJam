using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    public GameObject[] _world;
    private GameObject _word;
    public GameObject _lastObject;

    public MenuInteractivoInGame _pausa;

    private void Start()
    {
        _word = this.gameObject;
    }
    public void MundoProcedural()
    {
        if (!_pausa.IsPause)
        {
            GameObject _newInstance = Instantiate(_world[Random.Range(0, _world.Length)], _lastObject.transform.position, _lastObject.transform.rotation) as GameObject;
            _newInstance.transform.parent = _word.transform;
            _lastObject = _newInstance.GetComponent<NewTarget>()._newTarget;
        }
    }
}
