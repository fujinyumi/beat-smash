using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Lane { D, F, Space, J, K };
public enum BeatType { Hit, Held };

public class Onload : MonoBehaviour {

    public static Onload instance = null;

    /* MEMBER VARIABLES */

    public const float LOOKAHEAD_INTERVAL = SongPosition.TIME_BEFORE_AUDIO_START*1000;

    //score trackers
    private int score;
    private int totalGreats;
    private int totalGoods;
    private int totalBads;
    private int totalMisses;

    private bool beatsDone;

    //our ordered map, which will be populated during preprocessing
    SortedDictionary<int, List<BeatInfo>> upcomingBeats;
    //enumerator for this dictionary that will progressively advance.
    SortedDictionary<int, List<BeatInfo>>.Enumerator upcomingBeatsEnumerator;

    /* "GETTER" Functions */

    public int GetScore() { return score; }
    public int GetGreats() { return totalGreats; }
    public int GetGoods() { return totalGoods; }
    public int GetBads() { return totalBads; }
    public int GetMisses() { return totalMisses; }

    /* "SETTER" Functions
     * NOTE: Update() functions of Unity objects are run in SEQUENCE on a single core unless multithreading is explicitly stated.
     * Thus there is no need for mutexes or locks.
     */

     public void UpdateScore(int increase)
    {
        score += increase;
    }

    public void AddGreat() { totalGreats++; }
    public void AddGood() { totalGoods++; }
    public void AddBad() { totalBads++; }
    public void AddMiss() { totalMisses++; }

    /* UNITY FUNCTIONS */

    //enforce singleton
    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        //member variable initialization
        score = totalGreats = totalGoods = totalBads = totalMisses = 0;
        beatsDone = false;
        upcomingBeats = new SortedDictionary<int, List<BeatInfo>>();

        /* FOR MICHELLE AND OTHER PREPROCESSORS
         * Insert preprocessing script here.
         * INPUT: Read the beatmap file in (using System.IO.File?)
         * OUTPUT: Using an ordered map (implemented as a red-black tree, so O(logn) access, search, insertion, deletion)
         * of type < int, List<BeatInfo> > where int corresponds to the time offset (in ms) and BeatInfo is a class containing target info, 
         * process the beatmap file and consolidate beats with the same ms offset into the List of each key-value pair
         */

        /* TO EVENTUALLY REMOVE: HARD CODED DATA */
        List<BeatInfo> listToInsert = new List<BeatInfo>();
        listToInsert.Add(new BeatInfo(Lane.D, BeatType.Hit, 510));
        List<BeatInfo> listToInsert2 = new List<BeatInfo>();
        listToInsert.Add(new BeatInfo(Lane.F, BeatType.Hit, 1195));
        List<BeatInfo> listToInsert3 = new List<BeatInfo>();
        listToInsert.Add(new BeatInfo(Lane.J, BeatType.Held, 1820, 1000));
        upcomingBeats.Add(510, listToInsert);
        upcomingBeats.Add(1195, listToInsert2);
        upcomingBeats.Add(1820, listToInsert3);

        upcomingBeatsEnumerator = upcomingBeats.GetEnumerator();
        //move to first position
        if (!upcomingBeatsEnumerator.MoveNext()) beatsDone = true;
    }

    // Update is called once per frame
    void Update () {
        float songPos = SongPosition.instance.getSongPos();
        if (!beatsDone)
        {
            if (upcomingBeatsEnumerator.Current.Key - songPos < LOOKAHEAD_INTERVAL)
            {
                foreach (BeatInfo bi in upcomingBeatsEnumerator.Current.Value)
                {
                    bi.CreateBeatTarget();
                }
                if (!upcomingBeatsEnumerator.MoveNext())
                {
                    beatsDone = true;
                }
            }
        }
    }
}
