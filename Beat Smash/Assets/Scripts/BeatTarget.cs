using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* WARNING: DO NOT INSTANTIATE THIS PREFAB BY HAND IN UNITY!!!!!! Unless if you like Null Pointer Exceptions */
public class BeatTarget : MonoBehaviour {

    public static int onscreenInterval = 5000;
    public const float STARTING_Y = 0;

    private BeatInfo m_beatinfo;
    private float m_x;

    //prototype of this Unity object
    public static Object prototype;

    public void SetBeatInfo(BeatInfo beatinfo) { m_beatinfo = beatinfo; }

    public static BeatTarget Create(BeatInfo beatinfo)
    {
        BeatTarget newTarget = Instantiate(prototype) as BeatTarget;
        newTarget.SetBeatInfo(beatinfo);
        return newTarget;
    }

	// Use this for initialization
	void Start () {
        prototype = Resources.Load("Prefabs/BeatTarget");

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

        transform.position = new Vector3(m_x, transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
