using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour {

    public LimitMovePlayer _limites;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update ()
    {
        Limites();
    }
    public void Limites()
    {
        if(_player.transform.position.x > _limites._limites[1].transform.localPosition.x)
        {
            _player.transform.position = new Vector3(_limites._limites[1].transform.localPosition.x, _player.transform.position.y, _player.transform.position.z);
        }
        else if(_player.transform.position.x < _limites._limites[0].transform.position.x)
        {
            _player.transform.position = new Vector3(_limites._limites[0].transform.localPosition.x, _player.transform.position.y, _player.transform.position.z);
        }
    }
}
