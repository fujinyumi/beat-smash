using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* representation of a BeatTarget as a non-Unity object so information can be created without a Unity object */
public class BeatInfo {

    //member variables
    private Lane m_lane;
    private BeatType m_type;
    private float m_offset;
    private float m_duration = -1;

    //reference to corresponding BeatTarget - necessary?
    private BeatTarget m_beattarget;

    //getters
    public Lane GetLane() { return m_lane; }
    public BeatType GetBeatType() { return m_type; }
    public float GetOffset() { return m_offset; }

    //constructor
    public BeatInfo(Lane lane, BeatType type, float offset)
    {
        m_lane = lane;
        m_type = type;
        m_offset = offset;
    }

    public BeatInfo(Lane lane, BeatType type, float offset, float duration)
    {
        m_lane = lane;
        m_type = type;
        m_offset = offset;
        m_duration = duration;
    }

    //create the corresponding GUI component - BeatTarget - when called
    public BeatTarget CreateBeatTarget()
    {
        BeatTarget newBeat = null;

        if(m_type == BeatType.Hit)
        {
            newBeat = HitTarget.Create(this);
            m_beattarget = newBeat;
        }
        else if (m_type == BeatType.Held)
        {
            newBeat = HoldTarget.Create(this);
            m_beattarget = newBeat;
        }

        return newBeat;
    }
}
