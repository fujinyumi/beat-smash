using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongInfo
{
    // members
    public string m_title;
    public string m_length;
    // public int m_highScore;
    public string m_pathToAudio;  // in the form of "Audio/TestB"
    public string m_pathToBeatmap;  // however you want to access it during preprocessing 

    public SongInfo(string pathToAudio, string pathToBeatMap, 
                    string title = "", string length = "")
    {
        m_pathToAudio = pathToAudio;
        m_pathToBeatmap = pathToBeatMap;
        m_title = title;
        m_length = length;
        // m_highScore = highScore;
    }

}