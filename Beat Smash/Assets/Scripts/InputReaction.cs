using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* please initialize inputKey in Unity before use. */
public class InputReaction : MonoBehaviour {

    //hit intervals, in milliseconds - may need to be tweaked later when playtested
    public const int INTERVAL_GREAT = 50;
    public const int INTERVAL_GOOD = 150;
    public const int INTERVAL_BAD = 250;

    public const int SCORE_GREAT = 100;
    public const int SCORE_GOOD = 50;
    public const int SCORE_BAD = 25;

    public string inputKey;

    private Queue<BeatTarget> upcomingNotes = new Queue<BeatTarget>();

    public void Enqueue(BeatTarget bt)
    {
        upcomingNotes.Enqueue(bt);
    }

    public BeatTarget Peek()
    {
        return upcomingNotes.Peek();
    }

    public void Dequeue()
    {
        upcomingNotes.Dequeue();
    }

	// Use this for initialization
	void Start () {
        //set name of this game object
        gameObject.name = inputKey;
    }
	
	// Update is called once per frame
	void Update () {
        float songPos = SongPosition.instance.getSongPos();

        //pop all notes which have been missed
        while (
            upcomingNotes.Count > 0 && 
            (songPos - upcomingNotes.Peek().GetBeatInfo().GetOffset()) > INTERVAL_BAD
            )
        {
            Debug.Log("Miss");
            Onload.score.missCombo();
            Onload.health.decHealth(0);
            upcomingNotes.Dequeue();
        }

		if(Input.GetKeyDown(inputKey))
        {
            transform.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);

            if (upcomingNotes.Count > 0)
            {
                BeatTarget upcoming = upcomingNotes.Peek();
                if (System.Math.Abs(upcoming.GetBeatInfo().GetOffset() - songPos) <= INTERVAL_GREAT)
                {
                    Onload.score.UpdateScore(SCORE_GREAT);
                    Onload.health.incHealth(0);
                    Debug.Log("Great");
                    upcoming.DeleteMe();
                    upcomingNotes.Dequeue();
                }
                else if (System.Math.Abs(upcoming.GetBeatInfo().GetOffset() - songPos) <= INTERVAL_GOOD)
                {
                    Onload.score.UpdateScore(SCORE_GOOD);
                    Onload.health.incHealth(1);
                    Debug.Log("Good");
                    upcoming.DeleteMe();
                    upcomingNotes.Dequeue();
                }
                else if (System.Math.Abs(upcoming.GetBeatInfo().GetOffset() - songPos) <= INTERVAL_BAD)
                {
                    Onload.score.UpdateScore(SCORE_BAD);
                    Onload.health.decHealth(1);
                    Debug.Log("Bad");
                    upcoming.DeleteMe();
                    upcomingNotes.Dequeue();
                }
            }

        }
        if (Input.GetKeyUp(inputKey))
        {
            transform.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }
}
