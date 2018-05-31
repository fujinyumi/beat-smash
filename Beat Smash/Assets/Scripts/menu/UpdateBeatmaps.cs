using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class UpdateBeatmap : MonoBehaviour {

    public InputField songField;
    public InputField beatmapField;
    public InputField titleField;
    public SongScrollList scrollList;

    // Use this for initialization
    void Start () {
		
	}
	
    void UpdateBeatmaps()
    {
        string songPath = songField.text;
        string beatmapPath = beatmapField.text;
        string title = titleField.text;
        string newSongPath = "Assets/Resources/Beatmaps/" + title + ".wav";
        string newBeatmapPath = "Assets/Resources/Beatmaps/" + title + ".btmp"; 

        // copy beatmaps and audio files to resource folder
        FileUtil.CopyFileOrDirectory(songPath, newSongPath);
        FileUtil.CopyFileOrDirectory(beatmapPath, newBeatmapPath);

        // update buttons on screen
        SongInfo newSongInfo = new SongInfo(newSongPath, newBeatmapPath, title, "0", 898789);
        scrollList.AddNewSong(newSongInfo);

    }


}
