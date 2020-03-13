using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    private RotateCamera compRotateCamera;
    public MenuInteractivoInGame _pausa;
    private float initialPosX;

    private GameObject _player;

	void Start ()
    {
        initialPosX = transform.position.x;
        _player = GameObject.FindGameObjectWithTag("Player");
        compRotateCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RotateCamera>();
	}
	
	void Update ()
    {
        float rotZ = compRotateCamera.GetCurrentRotationZ();

        if (_pausa.IsPause == false)
        {
            _player.transform.position = new Vector3(initialPosX + rotZ, _player.transform.position.y, _player.transform.position.z);
        }
    }
}
