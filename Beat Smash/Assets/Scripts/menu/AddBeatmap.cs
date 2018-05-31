using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;

public class AddBeatmap : MonoBehaviour {

    public Button button;

    // Use this for initialization
    void Start () {
        button.onClick.AddListener(SelectBeatmap);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SelectBeatmap()
    {
        string path = EditorUtility.OpenFilePanel("Choose Beatmap", "", "btmp");
        if (path.Length != 0)
        {
            var fileContent = File.ReadAllBytes(path);
            Debug.Log(path);
            Debug.Log(fileContent);
            FileUtil.CopyFileOrDirectory(path, "Assets/Resources/Beatmaps/new.btmp");
        }



    }

}
