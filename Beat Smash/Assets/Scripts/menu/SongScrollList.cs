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
        SongInfo s0 = new SongInfo("yoyo", "10", 898789);
        SongInfo s1 = new SongInfo("yoyo", "10", 898789);
        SongInfo s2 = new SongInfo("2", "10", 898789);
        SongInfo s3 = new SongInfo("3", "10", 898789);
        SongInfo s4 = new SongInfo("4", "10", 898789);
        SongInfo s5 = new SongInfo("5", "10", 898789);
        SongInfo s6 = new SongInfo("6", "10", 898789);
        songList.Add(s0);
        songList.Add(s1);
        songList.Add(s2);
        songList.Add(s3);
        songList.Add(s4);
        songList.Add(s5);
        songList.Add(s6);

        AddButtons();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    

    // create buttons from songList
    private void AddButtons()
    {
        for (int i = 0; i < songList.Count; i++)
        {
            SongInfo songInfo = songList[i];
            //SongButton newButton =  Instantiate(button);
            GameObject newButton = Instantiate(Resources.Load("Prefabs/menu/SongButton")) as GameObject;
            newButton.transform.SetParent(contentPanel);

            SongButton songButton = newButton.GetComponent<SongButton>();
            songButton.Setup(songInfo);
        }
    }

}
