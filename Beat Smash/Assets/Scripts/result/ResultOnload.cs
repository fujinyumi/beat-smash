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
        grade.text = "A";
        score = GameObject.Find("ScoreVar").GetComponent<Text>();
        score.text = "a score";
        combo = GameObject.Find("ComboVar").GetComponent<Text>();
        combo.text = "a combo";

        great = GameObject.Find("GreatVar").GetComponent<Text>();
        great.text = "1";
        good = GameObject.Find("GoodVar").GetComponent<Text>();
        good.text = "2";
        bad = GameObject.Find("BadVar").GetComponent<Text>();
        bad.text = "3";
        miss = GameObject.Find("MissVar").GetComponent<Text>();
        miss.text = "4";

        title = GameObject.Find("TitleVar").GetComponent<Text>();
        title.text = "5";
        length = GameObject.Find("LengthVar").GetComponent<Text>();
        length.text = "6";

    }
	

	void Update () {
        // TODO: change screen to menu 
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("gamescreen");
        }
    }


}
