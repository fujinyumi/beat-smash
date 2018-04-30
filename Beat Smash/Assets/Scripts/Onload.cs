using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Lane { D, F, Space, J, K };

public class Onload : MonoBehaviour {

    //hit intervals, in milliseconds - may need to be tweaked later when playtested
    public const int INTERVAL_GREAT = 10;
    public const int INTERVAL_GOOD = 20;
    public const int INTERVAL_BAD = 30;

    private int score;
    private int totalGreats;
    private int totalGoods;
    private int totalBads;
    private int totalMisses;

    public int getScore() { return score; }
    public int getGreats() { return totalGreats; }
    public int getGoods() { return totalGoods; }
    public int getBads() { return totalBads; }
    public int getMisses() { return totalMisses; }

    // Use this for initialization
    void Start () {
        score = totalGreats = totalGoods = totalBads = totalMisses = 0;

        //perform preprocessing
        /* i'm going to leave this empty for now */
		
	}
	
	// Update is called once per frame
	void Update () {
		/* overall controller which recognizes if notes have been hit?
         * we need to decide whether or not we want every single note object to be created during the preprocessing phase,
         * or if they should be created dynamically.
         * As a result, we need to decide whether this overall controller script handles the timing events, or
         * if the beats themselves handle their own timing and subsequent destruction. 
         */
	}
}
