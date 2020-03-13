using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour {

    private DeadCondition _dead;

    public TextMeshProUGUI ElScore;
    public TextMeshProUGUI HighScoreDead;
    public TextMeshProUGUI HighScorePause;
    private float numb;

	void Start ()
    {
        _dead = GameObject.FindGameObjectWithTag("Player").GetComponent<DeadCondition>();

        HighScoreDead.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("f0");
        HighScorePause.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("f0");

        numb = 0;
    }
	
	void Update ()
    {
        Score();
        if(!_dead._dead)
            numb += Time.deltaTime * 5;
    }

    public void Score()
    {
        ElScore.text = numb.ToString("Score: " + "0");
        if (numb > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", numb);
            HighScoreDead.text = numb.ToString("f0");
            HighScorePause.text = numb.ToString("f0");
        }
    }
}
