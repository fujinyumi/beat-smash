using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* WARNING: DO NOT INSTANTIATE THIS PREFAB BY HAND IN UNITY!!!!!! Unless if you like Null Pointer Exceptions */
public class BeatTarget : MonoBehaviour {

    public static int onscreenInterval = 5000;
    public const float STARTING_Y = 15;
    public const float ENDING_Y = -2.5f;
    public const float OFFSCREEN_Y = 100;

    private BeatInfo m_beatinfo = null;
    private float m_x;

    public void SetBeatInfo(BeatInfo beatinfo) { m_beatinfo = beatinfo; }

    public static BeatTarget Create(BeatInfo beatinfo)
    {
        GameObject newTargetObj = Instantiate(Resources.Load("Prefabs/Beat Target")) as GameObject;
        BeatTarget newTarget = newTargetObj.GetComponent<BeatTarget>();
        Debug.Log(newTarget);
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

        transform.position = new Vector3(m_x, OFFSCREEN_Y, transform.position.z);

        Debug.Log(m_beatinfo.GetOffset());
    }
	
	// Update is called once per frame
	void Update () {
        float songPos = SongPosition.instance.getSongPos();
        if(m_beatinfo.GetOffset() - songPos < onscreenInterval)
        {
            //interpolation! Yay!!! 
         transform.position = Vector2.Lerp(
             new Vector3(m_x, STARTING_Y, 1),
             new Vector3(m_x, ENDING_Y, 1),
             (onscreenInterval - (m_beatinfo.GetOffset() - songPos)) / onscreenInterval
             );
        }
    }
}
