using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePlay : MonoBehaviour {


    public Material ColorInicial;
    public float Speed = 0.1f;

    private float alpha = 1f;

	// Use this for initialization
	void Start ()
    {
        alpha = 1f;
        gameObject.GetComponent<Renderer>().material = ColorInicial;
        ColorInicial.color = new Color(0, 0, 0, alpha);
    }
	
	// Update is called once per frame
	public void Update ()
    {
        gameObject.GetComponent<Renderer>().material = ColorInicial;
        ColorInicial.color = new Color(0,0,0,alpha);
        
        if (alpha >= 0)
        {
            alpha -= Speed * Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
}
