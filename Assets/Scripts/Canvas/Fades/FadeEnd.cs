using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEnd : MonoBehaviour {

    public Material ColorInicial;
    public float Speed = 0.1f;

    private float alpha = 0f;

    // Use this for initialization
    void Start()
    {
        alpha = 0f;
        gameObject.GetComponent<Renderer>().material = ColorInicial;
        ColorInicial.color = new Color(0, 0, 0, alpha);
    }

    // Update is called once per frame
    public void Update()
    {
        gameObject.GetComponent<Renderer>().material = ColorInicial;
        ColorInicial.color = new Color(0, 0, 0, alpha);
        
        if (alpha <= 1)
        {
            alpha += Speed * Time.deltaTime;
        }
    }
}
