using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    private int score;
    public Text scoreText;

	// Use this for initialization
	void Start () {
        score = 0;
        scoreText.text = "Score: 0";
	}

    public int GetScore()
    {
        return score;
    }

    public void UpdateScore(int increase)
    {
        score += increase;
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("Score updated: " + score.ToString());
    }

    // Update is called once per frame
    void Update () {
		
	}
}
