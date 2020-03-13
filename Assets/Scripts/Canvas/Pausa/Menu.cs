using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private bool _goToGame, _goToCreditos;
    public AudioSource _sound;

    private GameObject _cam;
    public GameObject fadeFinal;

    private bool _instantFade;
    private float timeToSetScene = 1.5f;

    private void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
        _goToGame = _goToCreditos = false;
        _instantFade = true;
        _sound.volume = 1;

        Time.timeScale = 1;
    }

    private void Update()
    {
        PlayGame();
        Creditos();
    }

    void PlayGame()
    {
        if (_goToGame)
        {
            if (_instantFade)
            {
                GameObject _hijo = Instantiate(fadeFinal, transform.position, transform.rotation) as GameObject;
                _hijo.transform.parent = _cam.transform;
                _hijo.transform.position = _cam.transform.position;
                _hijo.transform.rotation = _cam.transform.rotation;
                _instantFade = false;
            }
            if (timeToSetScene <= 0)
            {
                SceneManager.LoadScene("Nivel");
            }
            else
            {
                timeToSetScene -= Time.deltaTime;
                _sound.volume -= Time.deltaTime;
            }
        }
    }
    void Creditos()
    {
        if (_goToCreditos)
        {
            if (_instantFade)
            {
                GameObject _hijo = Instantiate(fadeFinal, transform.position, transform.rotation) as GameObject;
                _hijo.transform.parent = _cam.transform;
                _hijo.transform.position = _cam.transform.position;
                _hijo.transform.rotation = _cam.transform.rotation;
                _instantFade = false;
            }
            if (timeToSetScene <= 0)
            {
                SceneManager.LoadScene("Creditos");
            }
            else
            {
                timeToSetScene -= Time.deltaTime;
            }
        }
    }

    public void PlayButton()
    {
        _goToGame = true;
    }
    public void CreditosButton()
    {
        _goToCreditos = true;
    }
}
