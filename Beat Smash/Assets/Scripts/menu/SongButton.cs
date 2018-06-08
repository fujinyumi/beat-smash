using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongButton : MonoBehaviour {

    public Button button;
    public Text TitleText;
    private SongInfo m_songInfo;

    private OutlineEbb myOutlineScript;
    private Outline myOutline;
    private Image myImage;

    private AudioSource myPlayer;
    private AudioClip sound;

	// Use this for initialization
	void Start () {

        sound = null;

        myPlayer = GameObject.Find("AudioPlayer").GetComponent<AudioSource>();

        gameObject.name = m_songInfo.m_title;

        myImage = GetComponent<Image>();
        myOutline = GetComponent<Outline>();
        myOutlineScript = GetComponent<OutlineEbb>();
        //disable outline
        myOutlineScript.enabled = false;

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
        SetActive();

        // update infomation text on side of screen
        Text title = GameObject.Find("TitleText").GetComponent<Text>();
        title.text = "Selected Song:    " + m_songInfo.m_title;
        //Text length = GameObject.Find("LengthText").GetComponent<Text>();
        //length.text = "LENGTH\n" + m_songInfo.m_length;
        Text notice = GameObject.Find("NoticeText").GetComponent<Text>();
        notice.text = "Press ENTER to play";

        // update SongToBePlayed
        SongToBePlayed.songInfo = m_songInfo;
    }

    public void SetActive()
    {
        myImage.color = new Vector4(1f, (83f / 255f), (170f / 255f), 1f);
        myOutlineScript.enabled = true;
    }

    public void SetInactive()
    {
        myImage.color = new Vector4((200f/255f), (22f / 255f), (112f / 255f), 1f);
        myOutline.effectColor = new Vector4(0f, 0f, 0f, 0f);
        myOutlineScript.enabled = false;
    }

    public void playSong()
    {
        //only load on first attempt to play: for performance
        if(sound == null)
        {
            string audioPath = m_songInfo.m_pathToAudio;
            sound = Resources.Load<AudioClip>(audioPath);
        }

        myPlayer.clip = sound;
        myPlayer.Play();
    }
}

