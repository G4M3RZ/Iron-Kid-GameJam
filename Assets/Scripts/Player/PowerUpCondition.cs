using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PowerUpCondition : MonoBehaviour
{
    [Range(0, 5)]
    public float _separacion;
    [Range(0, 5)]
    public float _distance;

    private Vector3 Izq;
    private Vector3 Der;

    private DeadCondition _dead;
    public MenuInteractivoInGame _pausa;
    public LayerMask _ignoreLayer;

    public ParticleSystem _shield;

    public AudioSource _soundtrack;
    private float _slowFactor = 0.05f;
    private float _slowLength = 4f;

    private void Start()
    {
        _dead = GetComponent<DeadCondition>();
    }
    private void Update()
    {
        VolverNormalidad();

        Izq = new Vector3(transform.position.x + _separacion, transform.position.y, transform.position.z);
        Der = new Vector3(transform.position.x - _separacion, transform.position.y, transform.position.z);

        RaycastHit hit;
        if (Physics.Raycast(Izq, transform.forward, out hit, _distance, _ignoreLayer))
        {
            if (hit.collider.CompareTag("PowerUp"))
            {
                switch (hit.collider.GetComponent<DiferenciadorPowerUp>()._numControl)
                {
                    case 1: Realentizar(); break;
                    case 2: Proteccion(); break;
                    default: break;
                }
                
                Destroy(hit.collider.gameObject);
            }
        }
        RaycastHit hit2;
        if (Physics.Raycast(Der, transform.forward, out hit2, _distance, _ignoreLayer))
        {
            if (hit2.collider.CompareTag("PowerUp"))
            {
                switch (hit2.collider.GetComponent<DiferenciadorPowerUp>()._numControl)
                {
                    case 1: Realentizar(); break;
                    case 2: Proteccion(); break;
                    default: break;
                }

                Destroy(hit2.collider.gameObject);
            }
        }
    }

    void Proteccion()
    {
        StartCoroutine(Protection(10));
    }

    void Realentizar()
    {
        Time.timeScale = _slowFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    void VolverNormalidad()
    {
        if (_slowFactor != 1 && !_pausa.IsPause)
        {
            Time.timeScale += (1f / _slowLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
        _soundtrack.pitch = Time.timeScale;
    }

    IEnumerator Protection(float timer)
    {
        _dead._shield = true;
        var emission = _shield.emission;
        emission.rateOverTime = 20;
        yield return new WaitForSeconds(timer);

        _dead._shield = false;
        emission.rateOverTime = 0;

        StopCoroutine("Protection");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(Izq, transform.forward * _distance);
        Gizmos.DrawRay(Der, transform.forward * _distance);
    }
}