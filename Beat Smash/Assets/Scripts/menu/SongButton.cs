using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongButton : MonoBehaviour {

    public Button button;
    public Text TitleText;
    //private SongInfo m_songInfo;

	// Use this for initialization
	void Start () {
        TitleText.text = m_songInfo.m_title;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static SongButton CreateSongButton(SongInfo info)
    {
        GameObject newButtonObj = Instantiate(Resources.Load("Prefabs/menu/SongButton")) as GameObject;
        SongButton newButton = newButtonObj.GetComponent<SongButton>();
        //m_songInfo = info;
        //SetSongInfo(info);
        TitleText.text = info.m_title;

        return newButton;
    }


    private void SetSongInfo(SongInfo info)
    {
        m_songInfo = info;
    }


}
