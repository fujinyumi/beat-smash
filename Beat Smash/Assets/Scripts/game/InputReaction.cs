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

    private SpriteRenderer myRenderer;
    private Sprite splatted;
    private Sprite ring;

    private AudioSource myAudio;

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

    void Awake()
    {
        ring = Resources.Load<Sprite>("Sprites/GlowCircle2 copy");
        splatted = Resources.Load<Sprite>("Sprites/splat-tentative");
    }

    // Use this for initialization
    void Start () {
        //set name of this game object
        gameObject.name = inputKey;

        //disable visibility
        myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.enabled = false;

        //get audio
        myAudio = GetComponent<AudioSource>();
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
            myRenderer.enabled = true;
            myAudio.Play();
            
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
                    myRenderer.sprite = splatted;
                    transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                }
                else if (System.Math.Abs(upcoming.GetBeatInfo().GetOffset() - songPos) <= INTERVAL_GOOD)
                {
                    Onload.score.UpdateScore(SCORE_GOOD);
                    Onload.health.incHealth(1);
                    Debug.Log("Good");
                    upcoming.DeleteMe();
                    upcomingNotes.Dequeue();
                    myRenderer.sprite = splatted;
                    transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                }
                else if (System.Math.Abs(upcoming.GetBeatInfo().GetOffset() - songPos) <= INTERVAL_BAD)
                {
                    Onload.score.UpdateScore(SCORE_BAD);
                    Onload.health.decHealth(1);
                    Debug.Log("Bad");
                    upcoming.DeleteMe();
                    upcomingNotes.Dequeue();
                    myRenderer.sprite = splatted;
                    transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                }
            }

        }
        if (Input.GetKeyUp(inputKey))
        {
            myRenderer.enabled = false;
            myRenderer.sprite = ring;
            transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
        }
    }
}
