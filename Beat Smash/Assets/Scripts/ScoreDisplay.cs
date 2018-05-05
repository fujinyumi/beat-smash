using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {
    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
	}

    public void GetScore()
    {
        return score;
    }

    public void UpdateScore(int increase)
    {
        score += increase;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
