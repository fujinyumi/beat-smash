using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* representation of a BeatTarget as a non-Unity object so information can be created without a Unity object */
public class BeatInfo {

    //member variables
    private Lane m_lane;
    private BeatType m_type;
    private int m_offset;
    private int m_duration; // Set to default = 1 ms if not a held beat, logic implemented in Onload.cs

    //reference to corresponding BeatTarget - necessary?
    private BeatTarget m_beattarget;

    //getters
    public Lane GetLane() { return m_lane; }
    public BeatType GetBeatType() { return m_type; }
    public int GetOffset() { return m_offset; }
    public int GetBeatDuration() { return m_duration; }

    // //constructor - Hit type
    // public BeatInfo(Lane lane, BeatType type, int offset)
    // {
    //     m_lane = lane;
    //     m_type = type;
    //     m_offset = offset;
    //     m_duration = 1;
    // }

    //constructor - Held type
    public BeatInfo(Lane lane, BeatType type, int offset, int duration)
    {
        m_lane = lane;
        m_type = type;
        m_offset = offset;
        m_duration = duration;
    }

    //create the corresponding GUI component - BeatTarget - when called
    public BeatTarget CreateBeatTarget()
    {
        BeatTarget newBeat = BeatTarget.Create(this);
        m_beattarget = newBeat;
        return newBeat;
    }
}
