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

        try
        {
            if (songExists && beatmapExists && title != "")
            {
                // copy beatmaps and audio files to resource folder
                FileUtil.CopyFileOrDirectory(songPath, "Assets/Resources/Audio/" + title + ".wav");
                FileUtil.CopyFileOrDirectory(beatmapPath, "Assets/Resources/Beatmaps/" + title + ".txt");

                // Refresh asset folder for Unity
                AssetDatabase.Refresh();

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
        catch (System.IO.IOException)
        {
            notice.text = "Cannot copy files!";
        }
    }

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
