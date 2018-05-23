using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SongScrollList : MonoBehaviour {

    public List<SongInfo> songList = new List<SongInfo>();
    public Transform contentPanel;
    public SongButton button;


    // Use this for initialization
    void Start () {

        //TODO: Pre processiing here: should update songList
        SongInfo s0 = new SongInfo("Audio/radio", "Beatmaps/Test", "radio", "0", 898789);
        SongInfo s1 = new SongInfo("Audio/STRM_MAP_C3", "Beatmaps/Test", "STRM_MAP_C3", "1", 898789);
        SongInfo s2 = new SongInfo("Audio/TestA", "Beatmaps/Test", "TestA", "2", 898789);
        SongInfo s3 = new SongInfo("Audio/TestB", "Beatmaps/Test", "TestB", "3", 898789);
        songList.Add(s0);
        songList.Add(s1);
        songList.Add(s2);
        songList.Add(s3);
        AddButtons();
    }
    
    // create buttons from songList
    private void AddButtons()
    {
        for (int i = 0; i < songList.Count; i++)
        {
            SongInfo songInfo = songList[i];
            GameObject newButton = Instantiate(Resources.Load("Prefabs/menu/SongButton")) as GameObject;
            newButton.transform.SetParent(contentPanel);
            SongButton songButton = newButton.GetComponent<SongButton>();
            songButton.Setup(songInfo);
        }
    }

}
