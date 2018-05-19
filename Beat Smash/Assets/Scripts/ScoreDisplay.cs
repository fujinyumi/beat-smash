using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    private int score;
    private int combo;
    private int maxCombo;
    public Text scoreText;
    public Text comboText;

	// Use this for initialization
	void Start () {
        score = 0;
        combo = 0;
        maxCombo = 0;
        scoreText.text = "Score: 0";
        comboText.text = "";
	}

    public int GetScore()
    {
        return score;
    }

    public int GetCombo()
    {
        return combo;
    }

    public int GetMaxCombo()
    {
        return maxCombo;
    }

    public void incrementCombo()
    {
        combo++;
        comboText.text = "Combo x" + combo.ToString();
        if (combo > maxCombo)
        {
            maxCombo = combo;
        }
    }

    public void missCombo()
    {
        combo = 0;
        comboText.text = "";
    }

    public void UpdateScore(int increase)
    {
        incrementCombo();
        score += (increase * combo);
        scoreText.text = "Score: " + score.ToString();
        // Debug.Log("Score updated: " + score.ToString());
    }

    // Update is called once per frame
    void Update () {
		
	}
}
