using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;



public class SongScrollList : MonoBehaviour {

    public List<SongInfo> songList = new List<SongInfo>();
    public Transform contentPanel;
    //public SongButton button;


    // Use this for initialization
    void Start () {

        // Load all song/beatmap information 
        var beatmaps = Resources.LoadAll("Beatmaps", typeof(TextAsset));
        foreach (var b in beatmaps)
        {
            Debug.Log(b.name);

            var song_name = b.name;
            var audio_path = "Audio/" + b.name;
            var btmp_path = "Beatmaps/" + b.name;

            var full_audio_path = System.IO.Path.GetFullPath("Assets/Resources/" + audio_path + ".wav");
            var full_btmp_path = System.IO.Path.GetFullPath("Assets/Resources/" + btmp_path + ".txt");
            var has_audio = File.Exists(full_audio_path);
            var has_btmp = File.Exists(full_btmp_path);
            // Debug.Log(has_audio);
            // Debug.Log(full_audio_path);
            // Debug.Log(has_btmp);
            // Debug.Log(full_btmp_path);
            if(!has_audio || !has_btmp){
                // Debug.LogError("Couldn't find both audio and beatmap file.");
                Debug.Log("Couldn't find both audio and beatmap file.");
            }

            SongInfo song = new SongInfo(audio_path, btmp_path, song_name, "0");
            songList.Add(song);
        }

        AddButtons();
    }
    
    // create buttons from songList
    private void AddButtons()
    {
        SortSongList();
        for (int i = 0; i < songList.Count; i++)
        {
            SongInfo songInfo = songList[i];
            GameObject newButton = Instantiate(Resources.Load("Prefabs/menu/SongButton")) as GameObject;
            newButton.transform.SetParent(contentPanel);
            SongButton songButton = newButton.GetComponent<SongButton>();
            songButton.Setup(songInfo);
        }
    }

    // removes all buttons from Unity content panel
    private void RemoveButtons()
    {

        foreach(Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }



    }

    private void SortSongList()
    {
        songList.Sort((x, y) => x.m_title.CompareTo(y.m_title));
    }

    // called when user selects new beatmap and song 
    public void AddNewSong(SongInfo newSong)
    {
        songList.Add(newSong);
        SortSongList();
        RemoveButtons();
        AddButtons();
    }



}
