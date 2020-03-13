using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsVelocity : MonoBehaviour
{
    public float _objVelocity;
    public Rigidbody _rb;

    void Start()
    {
        _rb.useGravity = false;
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        Destroy(this.gameObject, 4f);
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(0, 0, -_objVelocity * 2);
    }
}
