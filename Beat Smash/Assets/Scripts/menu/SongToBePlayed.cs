using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SongToBePlayed  {

    private static SongInfo m_songInfo = null;

	public static SongInfo songInfo
    {
        get
        {
            return m_songInfo;
        }
        set
        {
            if (m_songInfo != null && value != null && m_songInfo != value) {
                GameObject.Find(m_songInfo.m_title).GetComponent<SongButton>().SetInactive();
             }
            m_songInfo = value;
        }
    }
}
