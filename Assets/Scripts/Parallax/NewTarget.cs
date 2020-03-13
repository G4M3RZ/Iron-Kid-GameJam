using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTarget : MonoBehaviour
{
    public GameObject _newTarget;
    private Procedural _procedural;
    public float _objVelocity;

    void Start()
    {
        _procedural = GameObject.FindGameObjectWithTag("World").GetComponent<Procedural>();
    }

    private void Update()
    {
        transform.Translate(0, 0, -_objVelocity * 2 * Time.deltaTime);

        if (transform.position.z < -30)
        {
            _procedural.MundoProcedural();
            Destroy(this.gameObject);
        }
    }
}
