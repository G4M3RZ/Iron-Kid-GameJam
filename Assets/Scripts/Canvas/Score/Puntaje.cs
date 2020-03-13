using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntaje : MonoBehaviour {

    public DeadCondition Player;
    public MenuInteractivoInGame _pausa;
    public GameObject[] ObsSpeed;
    public float Contador = 0f;

    public float CurrentSpeed = 50;

	void Start ()
    {
        ResetAll();
    }
	
	void Update ()
    {
        if (!Player._dead && !_pausa.IsPause)
        {
            ContadorInGame();
            if (ObsSpeed[0].GetComponent<ObsVelocity>()._objVelocity <= 75)
            {
                NuevoAumentoSpeed();
            }
        }
    }
    void ContadorInGame()
    {
        Contador += 1 * Time.deltaTime * 5;
    }
    void NuevoAumentoSpeed()
    {
        for (int i = 0; i < ObsSpeed.Length; i++)
        {
            ObsSpeed[i].GetComponent<ObsVelocity>()._objVelocity += Time.deltaTime / 3;
        }
    }
    void ResetAll()
    {
        for (int i = 0; i < ObsSpeed.Length; i++)
        {
            ObsSpeed[i].GetComponent<ObsVelocity>()._objVelocity = CurrentSpeed;
        }
    }
}
