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
            m_songInfo = value;
        }
    }
}
