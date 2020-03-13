using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CanvasSelector : MonoBehaviour
{
    public GameObject[] _canvas;
    private GameObject _player;

    [Range(1,2)]
    public int _selector;
    public bool _activarCambios;

    private void Start()
    {
        _activarCambios = false;
    }

    private void Update()
    {
        _player = GameObject.FindGameObjectWithTag("Player Rig");
        transform.position = new Vector3(0, _player.transform.position.y, 0);

        if (_activarCambios)
        {
            for (int i = 0; i < _canvas.Length; i++)
            {
                if (_selector - 1 == i)
                    _canvas[i].SetActive(true);
                else
                    _canvas[i].SetActive(false);
            }
        }
    }
}
