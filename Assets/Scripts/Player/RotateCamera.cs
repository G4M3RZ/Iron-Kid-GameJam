using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {

    public float currentRotationZ;
    [Range(0,50)]
    public float _speed = 50;
    public bool AllStop = true;

    public LimitMovePlayer _limites;

	void Start ()
    {
        currentRotationZ = 0;
	}

	void Update ()
    {
        if (AllStop)
        {
            currentRotationZ -= transform.localRotation.z * Time.deltaTime * _speed;
        }
        if (currentRotationZ > _limites._limites[1].transform.position.x)
        {
            currentRotationZ = _limites._limites[1].transform.position.x;
        }
        else if(currentRotationZ < _limites._limites[0].transform.position.x)
        {
            currentRotationZ = _limites._limites[0].transform.position.x;
        }
    }
    public float GetCurrentRotationZ()
    {
        return currentRotationZ;
    }
}
