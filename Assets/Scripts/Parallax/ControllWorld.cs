using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllWorld : MonoBehaviour
{
    public GameObject _camara;
    private float _rotCamaraY;

    void Update()
    {
        _rotCamaraY = _camara.transform.localEulerAngles.y;
        transform.rotation = Quaternion.Euler(0, _rotCamaraY, 0);
    }
}
