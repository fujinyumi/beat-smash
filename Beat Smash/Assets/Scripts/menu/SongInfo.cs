using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongInfo
{
    // members
    public string m_title;
    public string m_length ;
    public int m_highScore;



    public SongInfo(string title = "", string length = "" , int highScore = 0)
    {
        m_title = title;
        m_length = length;
        m_highScore = highScore;
    }

}