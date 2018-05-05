using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* WARNING: DO NOT INSTANTIATE THIS PREFAB BY HAND IN UNITY!!!!!! Unless if you like Null Pointer Exceptions */
public class BeatTarget : MonoBehaviour {

    public static float onscreenInterval = SongPosition.TIME_BEFORE_AUDIO_START*1000;
    public const float OFFSCREEN_Y = 100;
    public const float TOP_Y = 6;
    public const float GOAL_Y = -2.5f;
    public const float BOTTOM_Y = GOAL_Y - (TOP_Y - GOAL_Y);

    private BeatInfo m_beatinfo = null;
    private float m_x;

    private bool isBeginLerp = true;

    public void SetBeatInfo(BeatInfo beatinfo) { m_beatinfo = beatinfo; }

    public static BeatTarget Create(BeatInfo beatinfo)
    {
        GameObject newTargetObj = Instantiate(Resources.Load("Prefabs/Beat Target")) as GameObject;
        BeatTarget newTarget = newTargetObj.GetComponent<BeatTarget>();
        //Debug.Log(newTarget);
        newTarget.SetBeatInfo(beatinfo);
        return newTarget;
    }

	// Use this for initialization
	void Start () {
        if(m_beatinfo == null)
        {
            Debug.Log("wtf");
            return;
        }
        Lane myLane = m_beatinfo.GetLane();

        GameObject correspondingLane = null;

        switch(myLane)
        {
            case Lane.D:
                correspondingLane = GameObject.Find("d");
                break;
            case Lane.F:
                correspondingLane = GameObject.Find("f");
                break;
            case Lane.Space:
                correspondingLane = GameObject.Find("space");
                break;
            case Lane.J:
                correspondingLane = GameObject.Find("j");
                break;
            case Lane.K:
                correspondingLane = GameObject.Find("k");
                break;
            default:
                break;
        }
        
        if (correspondingLane != null)
        {
            m_x = correspondingLane.transform.position.x;
        }
        else
        {
            Debug.Log("Couldn't find correct lane");
        }

        transform.position = new Vector3(m_x, OFFSCREEN_Y, 5);

    }
	
	// Update is called once per frame
	void Update () {
        float songPos = SongPosition.instance.getSongPos();

        // Interpolation 
        if (m_beatinfo.GetOffset() - songPos <= onscreenInterval  && isBeginLerp)
        {
            // movement from top to lane target
             transform.position = Vector3.Lerp(
                 new Vector3(m_x, TOP_Y, -1),
                 new Vector3(m_x, GOAL_Y, -1),
                 (onscreenInterval - (m_beatinfo.GetOffset() - songPos)) / onscreenInterval
                 );

            // reached lane target
            if (transform.position.y == GOAL_Y)
            {
                    isBeginLerp = false;
                    transform.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
            }
        }
        // movement from lane target offscreen
        if (!isBeginLerp)
        {
            transform.position = Vector3.Lerp(
               new Vector3(m_x, GOAL_Y, -1),
               new Vector3(m_x, BOTTOM_Y, -1),
                (songPos - m_beatinfo.GetOffset())  / onscreenInterval
               );

        }
    }
}
