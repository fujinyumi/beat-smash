using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResultOnload : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

	void Update () {

        // TODO: change screen to menu 
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("gamescreen");
        }
    }


}
