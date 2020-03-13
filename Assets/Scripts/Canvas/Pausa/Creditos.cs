using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    private bool _goToCreditos;

    public GameObject _cam;
    public GameObject fadeFinal;

    private bool _instantFade;
    private float timeToSetScene = 1.5f;


    void Start()
    {
        _instantFade = true;
        _goToCreditos = false;
    }

    // Update is called once per frame
    void Update()
    {
        Menu();
    }
    void Menu()
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
                SceneManager.LoadScene("00-Menu");
            }
            else
            {
                timeToSetScene -= Time.deltaTime;
            }
        }
    }

    public void MenuButton()
    {
        _goToCreditos = true;
    }
}
