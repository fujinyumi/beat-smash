using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class UpdateBeatmap : MonoBehaviour {

    public Button button;
    public InputField songField;
    public InputField beatmapField;
    public InputField titleField;
    public Text notice;
    public SongScrollList scrollList;

    // Use this for initialization
    void Start () {
        button.onClick.AddListener(UpdateBeatmaps);
    }
	
    void UpdateBeatmaps()
    {
        string songPath = songField.text;
        string beatmapPath = beatmapField.text;
        string title = titleField.text;

        bool songExists = File.Exists(songPath);
        bool beatmapExists = File.Exists(beatmapPath);

        if (songExists && beatmapExists)
        {
            string newSongPath = "Assets/Resources/Beatmaps/" + title + ".wav";
            string newBeatmapPath = "Assets/Resources/Beatmaps/" + title + ".txt";

            // copy beatmaps and audio files to resource folder
            FileUtil.CopyFileOrDirectory(songPath, newSongPath);
            FileUtil.CopyFileOrDirectory(beatmapPath, newBeatmapPath);

            // update buttons on screen
            SongInfo newSongInfo = new SongInfo(newSongPath, newBeatmapPath, title, "length not added");
            scrollList.AddNewSong(newSongInfo);
        }
        else if (!songExists)
        {
            notice.text = "Song file does not exist!";
        }
        else if (!beatmapExists)
        {
            notice.text = "Beatmap file does not exist!";
        }

    }


}
