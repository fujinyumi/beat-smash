using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget : BeatTarget {
    public static HitTarget Create(BeatInfo beatinfo)
    {
        GameObject newTargetObj = Instantiate(Resources.Load("Prefabs/Hit Target")) as GameObject;
        HitTarget newTarget = newTargetObj.GetComponent<HitTarget>();
        newTarget.SetBeatInfo(beatinfo);
        return newTarget;
    }

    // Use this for initialization
    void Start () {
        //set sorting layer
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite)
        {
            sprite.sortingLayerName = TARGET_LAYER;
        }
        else { Debug.Log("Error retrieving sprite layer."); }

        Debug.Log(sprite.sortingLayerName);
        BeatInfo myBeatInfo = GetBeatInfo();
        Lane myLane = myBeatInfo.GetLane();

        switch (myLane)
        {
            case Lane.D:
                SetLane(GameObject.Find("d").GetComponent<InputReaction>());
                break;
            case Lane.F:
                SetLane(GameObject.Find("f").GetComponent<InputReaction>());
                break;
            case Lane.Space:
                SetLane(GameObject.Find("space").GetComponent<InputReaction>());
                break;
            case Lane.J:
                SetLane(GameObject.Find("j").GetComponent<InputReaction>());
                break;
            case Lane.K:
                SetLane(GameObject.Find("k").GetComponent<InputReaction>());
                break;
            default:
                break;
        }

        if (GetLane() != null)
        {
            SetXPos(GetLane().transform.position.x);
            GetLane().Enqueue(this);
        }
        else
        {
            Debug.Log("Couldn't find correct lane");
        }

        transform.position = new Vector3(GetXPos(), OFFSCREEN_Y, 0);
    }
	
	// Update is called once per frame
	void Update () {
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
