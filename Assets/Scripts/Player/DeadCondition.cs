using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DeadCondition : MonoBehaviour
{
    [HideInInspector]
    public bool _dead, _shield;
    public GameObject _particulas;
    [Range(0,5)]
    public float _separacion;
    [Range(0,5)]
    public float _distance;

    private Vector3 Izq;
    private Vector3 Der;

    private GameObject[] _enemyObsList;
    private GameObject[] _ObsList;
    public LayerMask _ignoreLayer;

    private void Start()
    {
        _dead = false;
    }

    private void Update()
    {
        Izq = new Vector3(transform.position.x + _separacion, transform.position.y, transform.position.z);
        Der = new Vector3(transform.position.x - _separacion, transform.position.y, transform.position.z);

        if (!_shield)
        {
            RaycastHit hit;
            if (Physics.Raycast(Izq, transform.forward, out hit, _distance, _ignoreLayer))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    _dead = true;
                }
            }
            RaycastHit hit2;
            if (Physics.Raycast(Der, transform.forward, out hit2, _distance, _ignoreLayer))
            {
                if (hit2.collider.CompareTag("Enemy"))
                {
                    _dead = true;
                }
            }
        }

        if (_dead)
        {
            Instantiate(_particulas, transform.position, transform.rotation);
            _enemyObsList = GameObject.FindGameObjectsWithTag("Enemy");
            _ObsList = GameObject.FindGameObjectsWithTag("PowerUp");
            for (int i = 0; i < _enemyObsList.Length; i++)
            {
                Destroy(_enemyObsList[i].gameObject);
            }
            for (int i = 0; i < _ObsList.Length; i++)
            {
                Destroy(_ObsList[i].gameObject);
            }
            this.enabled = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Izq, transform.forward * _distance);
        Gizmos.DrawRay(Der, transform.forward * _distance);
    }
}
