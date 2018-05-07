using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldTarget : BeatTarget {

    public static HoldTarget Create(BeatInfo beatinfo)
    {
        GameObject newTargetObj = Instantiate(Resources.Load("Prefabs/Hold Target")) as GameObject;
        HoldTarget newTarget = newTargetObj.GetComponent<HoldTarget>();
        newTarget.SetBeatInfo(beatinfo);
        return newTarget;
    }

    // Use this for initialization
    void Start()
    {
        BeatInfo myBeatInfo = GetBeatInfo();

        if (myBeatInfo == null)
        {
            Debug.Log("wtf");
            return;
        }
        Lane myLane = myBeatInfo.GetLane();

        GameObject correspondingLane = null;

        switch (myLane)
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
            SetXPos(correspondingLane.transform.position.x);
        }
        else
        {
            Debug.Log("Couldn't find correct lane");
        }

        transform.position = new Vector3(GetXPos(), OFFSCREEN_Y, 5);
    }

    // Update is called once per frame
    void Update()
    {
        float songPos = SongPosition.instance.getSongPos();
        BeatInfo myBeatInfo = GetBeatInfo();

        // Interpolation 
        if (myBeatInfo.GetOffset() - songPos <= onscreenInterval && GetLerp())
        {
            // movement from top to lane target
            transform.position = Vector3.Lerp(
                new Vector3(GetXPos(), TOP_Y, -1),
                new Vector3(GetXPos(), GOAL_Y, -1),
                (onscreenInterval - (myBeatInfo.GetOffset() - songPos)) / onscreenInterval
                );

            // reached lane target
            if (transform.position.y == GOAL_Y)
            {
                SetLerp(false);
                transform.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
            }
        }
        // movement from lane target offscreen
        if (!GetLerp())
        {
            transform.position = Vector3.Lerp(
               new Vector3(GetXPos(), GOAL_Y, -1),
               new Vector3(GetXPos(), BOTTOM_Y, -1),
                (songPos - myBeatInfo.GetOffset()) / onscreenInterval
               );
            if (transform.position.y == BOTTOM_Y)
            {
                Destroy(gameObject);
            }

        }
    }
}
