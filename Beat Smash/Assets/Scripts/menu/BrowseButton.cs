using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class BrowseButton : MonoBehaviour {

    public Button button;
    public InputField inputField;
    public bool isSong;

    private string selectedPath = "";


	// Use this for initialization
	void Start () {
        if (isSong)
        {
            button.onClick.AddListener(delegate { Browse("Select Song", "wav"); } );
        }
        else
        {
            button.onClick.AddListener(delegate { Browse("Select Beatmap", "txt"); });
        }
	}

    void Browse(string broswerTitle, string fileExtension) 
    {
        string path = EditorUtility.OpenFilePanel(broswerTitle, "", fileExtension);
        if (path.Length != 0)
        {
            selectedPath = path;
            inputField.text = selectedPath;
            Debug.Log(selectedPath);
        }
    }

}
