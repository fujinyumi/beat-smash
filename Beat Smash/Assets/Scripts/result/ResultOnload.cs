using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ResultOnload : MonoBehaviour {

    private Text grade;
    private Text score;
    private Text combo;

    private Text great;
    private Text good;
    private Text bad;
    private Text miss;

    private Text title;
    private Text length;


	// Use this for initialization
	void Start () {

        grade = GameObject.Find("Grade").GetComponent<Text>();
        grade.text = ResultStats.Grade;
        score = GameObject.Find("ScoreVar").GetComponent<Text>();
        score.text = ResultStats.Score.ToString();
        combo = GameObject.Find("ComboVar").GetComponent<Text>();
        combo.text = ResultStats.MaxCombo.ToString();

        great = GameObject.Find("GreatVar").GetComponent<Text>();
        great.text = ResultStats.Great.ToString();
        Debug.Log("Great:" + ResultStats.Great.ToString());
        good = GameObject.Find("GoodVar").GetComponent<Text>();
        good.text = ResultStats.Good.ToString();
        bad = GameObject.Find("BadVar").GetComponent<Text>();
        bad.text = ResultStats.Bad.ToString();
        miss = GameObject.Find("MissVar").GetComponent<Text>();
        miss.text = ResultStats.Miss.ToString();
        Debug.Log("Miss:" + ResultStats.Miss.ToString());

        title = GameObject.Find("TitleVar").GetComponent<Text>();
        title.text = "5";
        length = GameObject.Find("LengthVar").GetComponent<Text>();
        length.text = "6";

    }
	

	void Update () {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("menuscreen");
        }
    }


}
