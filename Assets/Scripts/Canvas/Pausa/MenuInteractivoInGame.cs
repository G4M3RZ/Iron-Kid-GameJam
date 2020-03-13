using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteractivoInGame : MonoBehaviour {

    private DeadCondition _dead;
    public GameObject PauseMenuUI;
    public GameObject DeadMenuUI;

    public AudioSource _sound;

    public bool IsPause = false;

    private GameObject _cam;
    public GameObject fadeFinal;

    private bool _restart, _goToMenu, _instantFade;

    private float timeToSetScene = 1.5f;

    private bool _look = false;

    void Start()
    {
        _look = _instantFade = true;
        _restart = _goToMenu = false;
        _sound.volume = 0;
        _dead = GameObject.FindGameObjectWithTag("Player").GetComponent<DeadCondition>();
        _cam = GameObject.FindGameObjectWithTag("MainCamera");

        PauseMenuUI.SetActive(false);
        DeadMenuUI.SetActive(false);
    }

    void Update()
    {
        PauseController();
        AudioManager();
        Restart();
        Dead();
        Menu();
    }

    #region Buttons
    public void PauseButton()
    {
        IsPause = !IsPause;
        _look = false;
    }
    public void RestartButton()
    {
        if(!_goToMenu)
            _restart = true;
    }
    public void MenuButton()
    {
        if(!_restart)
            _goToMenu = true;
    }
    #endregion

    void PauseController()
    {
        if (!_look && !_dead._dead)
        {
            if (IsPause)
            {
                Time.timeScale = 0f;
                PauseMenuUI.SetActive(true);
                _sound.Pause();
                _look = true;
            }
            else 
            {
                Time.timeScale = 1f;
                PauseMenuUI.SetActive(false);
                _sound.Play();
                _look = true;
            }
        }
    }

    void Restart()
    {
        if (_restart)
        {
            if (_instantFade)
            {
                GameObject _hijo = Instantiate(fadeFinal, transform.position, transform.rotation) as GameObject;
                _hijo.transform.parent = _cam.transform;
                _hijo.transform.position = _cam.transform.position;
                _hijo.transform.rotation = _cam.transform.rotation;
                Time.timeScale = 1f;
                _instantFade = false;
            }
            if (timeToSetScene <= 0)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            else
            {
                timeToSetScene -= Time.deltaTime;
                _sound.volume -= Time.deltaTime;
            }
        }
    }

    void Dead()
    {
        if (_dead._dead)
        {
            DeadMenuUI.SetActive(true);
        }
    }

    void Menu()
    {
        if (_goToMenu)
        {
            if (_instantFade)
            {
                GameObject _hijo = Instantiate(fadeFinal, transform.position, transform.rotation) as GameObject;
                _hijo.transform.parent = _cam.transform;
                _hijo.transform.position = _cam.transform.position;
                _hijo.transform.rotation = _cam.transform.rotation;
                Time.timeScale = 1f;
                _instantFade = false;
            }
            if (timeToSetScene <= 0)
            {
                SceneManager.LoadScene("00-Menu");
            }
            else
            {
                timeToSetScene -= Time.deltaTime;
                _sound.volume -= Time.deltaTime;
            }
        }
    }

    #region Auduio Manager
    void AudioManager()
    {
        if (!_dead._dead)
        {
            if (_sound.volume < 1 && !IsPause)
            {
                _sound.volume += Time.deltaTime * 10;
            }
            else if (_sound.volume > 0 && IsPause)
            {
                _sound.volume = 0;
            }
        }
    }
    #endregion
}
