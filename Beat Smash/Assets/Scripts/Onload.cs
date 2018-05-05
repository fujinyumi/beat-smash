using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Lane { D, F, Space, J, K };
public enum BeatType { Hit, Held };

public class Onload : MonoBehaviour {

    /* MEMBER VARIABLES */
    //hit intervals, in milliseconds - may need to be tweaked later when playtested
    public const int INTERVAL_GREAT = 10;
    public const int INTERVAL_GOOD = 20;
    public const int INTERVAL_BAD = 30;

    public const int LOOKAHEAD_INTERVAL = 1000;

    //score trackers
    private int totalGreats;
    private int totalGoods;
    private int totalBads;
    private int totalMisses;

    //our ordered map, which will be populated during preprocessing
    SortedDictionary<int, List<BeatInfo>> upcomingBeats;
    //enumerator for this dictionary that will progressively advance.
    SortedDictionary<int, List<BeatInfo>>.Enumerator upcomingBeatsEnumerator;

    /* "GETTER" Functions */

    public int GetGreats() { return totalGreats; }
    public int GetGoods() { return totalGoods; }
    public int GetBads() { return totalBads; }
    public int GetMisses() { return totalMisses; }

    /* "SETTER" Functions
     * NOTE: Update() functions of Unity objects are run in SEQUENCE on a single core unless multithreading is explicitly stated.
     * Thus there is no need for mutexes or locks.
     */

    public void AddGreat() { totalGreats++; }
    public void AddGood() { totalGoods++; }
    public void AddBad() { totalBads++; }
    public void AddMiss() { totalMisses++; }

    /* UNITY FUNCTIONS */

    // Use this for initialization
    void Start () {
        //member variable initialization
        totalGreats = totalGoods = totalBads = totalMisses = 0;
        upcomingBeats = new SortedDictionary<int, List<BeatInfo>>();
        upcomingBeatsEnumerator = upcomingBeats.GetEnumerator();
        //move to first position
        upcomingBeatsEnumerator.MoveNext();

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
        listToInsert.Add(new BeatInfo(Lane.D, BeatType.Hit, 1195));
        List<BeatInfo> listToInsert3 = new List<BeatInfo>();
        listToInsert.Add(new BeatInfo(Lane.D, BeatType.Hit, 1820));
        upcomingBeats.Add(510, listToInsert);
        upcomingBeats.Add(1195, listToInsert2);
        upcomingBeats.Add(1820, listToInsert3);
    }

    // Update is called once per frame
    void Update () {

    }
}
