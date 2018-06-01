using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class UpdateBeatmaps : MonoBehaviour {

    public Button button;
    public InputField songField;
    public InputField beatmapField;
    public InputField titleField;
    public Text notice;
    public SongScrollList scrollList;
    public GameObject popWindow;

   
    void Start () {
        button.onClick.AddListener(UpdateSongList);
        popWindow.SetActive(false);
    }
	
    void UpdateSongList()
    {
        string songPath = songField.text;
        string beatmapPath = beatmapField.text;
        string title = titleField.text;

        bool songExists = File.Exists(songPath);
        bool beatmapExists = File.Exists(beatmapPath);

        if (songExists && beatmapExists && title != "")
        {
            // copy beatmaps and audio files to resource folder
            FileUtil.CopyFileOrDirectory(songPath, "Assets/Resources/Audio/" + title + ".wav");
            FileUtil.CopyFileOrDirectory(beatmapPath, "Assets/Resources/Beatmaps/" + title + ".txt");

            // update buttons on screen
            Debug.Log("new song info");
            string newSongPath = "Audio/" + title;
            string newBeatmapPath = "Beatmaps/" + title;
            SongInfo newSongInfo = new SongInfo(newSongPath, newBeatmapPath, title, "length not added");
            scrollList.AddNewSong(newSongInfo);

            //close window and reset
            ResetWindow();
            popWindow.SetActive(false);
        }
        else if (!songExists)
        {
            notice.text = "Song file does not exist!";
        }
        else if (!beatmapExists)
        {
            notice.text = "Beatmap file does not exist!";
        }
        else if (title == "")
        {
            notice.text = "Please enter title";
        }
    }


    //string audioPath = SongToBePlayed.songInfo.m_pathToAudio;
    //AudioClip sound = Resources.Load<AudioClip>(audioPath);
    //myAudio.clip = sound;

    //    initialDspTime = (float) AudioSettings.dspTime;

    //play audio with delay
    //myAudio.PlayDelayed(TIME_BEFORE_AUDIO_START);

    //    songLength = myAudio.clip.length*1000;


    private void ResetWindow()
    {
        songField.text = "";
        beatmapField.text = "";
        titleField.text = "";
        notice.text = "";
    }

    public void Show()
    {
        popWindow.SetActive(true);
    }


}
