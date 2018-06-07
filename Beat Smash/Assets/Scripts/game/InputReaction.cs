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
    public const int SCORE_GOOD = 80;
    public const int SCORE_BAD = 50;

    public string inputKey;

    private Queue<BeatTarget> upcomingNotes = new Queue<BeatTarget>();

    private SpriteRenderer myRenderer;
    private Sprite splatted;
    private Sprite ring;

    public static HitTypeDisplay hitTypeD;
    public static HitTypeDisplay hitTypeF;
    public static HitTypeDisplay hitTypeSpace;
    public static HitTypeDisplay hitTypeJ;
    public static HitTypeDisplay hitTypeK;

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

    public void SetHitTypeObject(Lane l, HitType ht)
    {
        switch (l)
        {
            case Lane.D:
                hitTypeD.SetSprite(ht);
                break;
            case Lane.F:
                hitTypeF.SetSprite(ht);
                break;
            case Lane.Space:
                hitTypeSpace.SetSprite(ht);
                break;
            case Lane.J:
                hitTypeJ.SetSprite(ht);
                break;
            case Lane.K:
                hitTypeK.SetSprite(ht);
                break;
            default:
                break;
        }
    }

    void Awake()
    {
        ring = Resources.Load<Sprite>("Sprites/GlowCircle2 copy");
        splatted = Resources.Load<Sprite>("Sprites/splat-tentative");
        hitTypeD = GameObject.FindWithTag("HitTypeDLane").GetComponent<HitTypeDisplay>();
        hitTypeF = GameObject.FindWithTag("HitTypeFLane").GetComponent<HitTypeDisplay>();
        hitTypeSpace = GameObject.FindWithTag("HitTypeSpaceLane").GetComponent<HitTypeDisplay>();
        hitTypeK = GameObject.FindWithTag("HitTypeKLane").GetComponent<HitTypeDisplay>();
        hitTypeJ = GameObject.FindWithTag("HitTypeJLane").GetComponent<HitTypeDisplay>();
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
        HitType hitType = HitType.UnInit;

        //pop all notes which have been missed
        while (
            upcomingNotes.Count > 0 && 
            (songPos - upcomingNotes.Peek().GetBeatInfo().GetOffset()) > INTERVAL_BAD
            )
        {
            Debug.Log("Miss");
            hitType = HitType.Miss;
            SetHitTypeObject(upcomingNotes.Peek().GetBeatInfo().GetLane(), hitType);
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
                    hitType = HitType.Great;
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
                    hitType = HitType.Good;
                    upcoming.DeleteMe();
                    upcomingNotes.Dequeue();
                    myRenderer.sprite = splatted;
                    transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                }
                else if (System.Math.Abs(upcoming.GetBeatInfo().GetOffset() - songPos) <= INTERVAL_BAD)
                {
                    Onload.score.UpdateScore(SCORE_BAD, 1);
                    Onload.health.decHealth(1);
                    Debug.Log("Bad");
                    hitType = HitType.Bad;
                    upcoming.DeleteMe();
                    upcomingNotes.Dequeue();
                    myRenderer.sprite = splatted;
                    transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                }
                SetHitTypeObject(upcoming.GetBeatInfo().GetLane(), hitType);
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
