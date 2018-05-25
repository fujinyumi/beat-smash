using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOnload : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SongToBePlayed.songInfo = null;
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Return) && SongToBePlayed.songInfo != null)
        {
            SceneManager.LoadScene("gamescreen");
        }
	}
}
