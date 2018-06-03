using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongButton : MonoBehaviour {

    public Button button;
    public Text TitleText;
    private SongInfo m_songInfo;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(HandleClick);
	}

    // sets attibutes of the button
    public void Setup(SongInfo currInfo)
    {
        m_songInfo = currInfo;
        TitleText.text = m_songInfo.m_title;
    }

    public void HandleClick()
    {
        // update infomation text on side of screen
        Text title = GameObject.Find("TitleText").GetComponent<Text>();
        title.text = "TITLE:\n" + m_songInfo.m_title;
        //Text length = GameObject.Find("LengthText").GetComponent<Text>();
        //length.text = "LENGTH\n" + m_songInfo.m_length;
        Text notice = GameObject.Find("NoticeText").GetComponent<Text>();
        notice.text = "Press ENTER to play";

        // update SongToBePlayed
        SongToBePlayed.songInfo = m_songInfo;
    }

}

