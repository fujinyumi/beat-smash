using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BeatType { Hit, Held };

public class BeatTarget : MonoBehaviour {

    private Lane m_lane;
    private BeatType m_type;
    private int m_offset;

    public static Object prototype;

    public void SetLane(Lane lane) { m_lane = lane; }
    public void SetType(BeatType type) { m_type = type; }
    public void SetOffset(int offset) { m_offset = offset; }

    public static BeatTarget Create(Lane lane, BeatType type, int offset)
    {
        BeatTarget newTarget = Instantiate(prototype) as BeatTarget;
        newTarget.SetLane(lane);
        newTarget.SetType(type);
        newTarget.SetOffset(offset);
        return newTarget;
    }

	// Use this for initialization
	void Start () {
        prototype = Resources.Load("Prefabs/BeatTarget");
    }
	
	// Update is called once per frame
	void Update () {
	}

    void BeginDescent()
    {
    }
}
