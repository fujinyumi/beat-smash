using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum Lane { D, F, Space, J, K, UnInit };
public enum BeatType { Hit, Held };

public class Onload : MonoBehaviour {

    /* MEMBER VARIABLES */
    //hit intervals, in milliseconds - may need to be tweaked later when playtested
    public const int INTERVAL_GREAT = 10;
    public const int INTERVAL_GOOD = 20;
    public const int INTERVAL_BAD = 30;

    public const int LOOKAHEAD_INTERVAL = 1000;

    //score trackers
    private int score;
    private int totalGreats;
    private int totalGoods;
    private int totalBads;
    private int totalMisses;

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

    // Use this for initialization
    void Start () {
        //member variable initialization
        //upcomingBeats = map of beats by their timing given by beatmap file
        //value of map is a List of the beats in order to recognize two beats at once
        score = totalGreats = totalGoods = totalBads = totalMisses = 0;
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

        string filePath = System.IO.Path.GetFullPath("Test.btmp");

        using(var reader = new StreamReader(filePath))
        {
            /** REMEMBER TO REMOVE CONSOLE.WRITELINE'S AFTER TESTING **/

            var firstLine = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                // If the firstLine has already been read, start processing values
                if(firstLine == 1){
            
                    // ** Beat Timestamp ** 
                    int beat_timestamp = -1;
                    if (Int32.TryParse(values[0], out beat_timestamp))
                        Console.WriteLine(beat_timestamp);
                    else
                        Console.WriteLine("beat_timestamp could not be parsed.");

                    // char laneType = values[1];
                    // ** Beat Lane **     
                    Lane beat_lane = Lane.values[1];

                    // ** Beat Type ** 
                    int beat_type = -1;
                    if (Int32.TryParse(values[2], out beat_type))
                        Console.WriteLine(beat_type);
                    else
                        Console.WriteLine("beat_type could not be parsed.");

                    // ** Beat Duration ** 
                    int beat_duration = 1;
                    if(values.Length > 3) {
                        beat_duration = values[3];

                        if (Int32.TryParse(values[0], out beat_timestamp))
                            Console.WriteLine(beat_timestamp);
                        else
                            Console.WriteLine("beat_duration could not be parsed.");
                    }

                    var newBeat = new BeatInfo(beat_timestamp, beat_lane, beat_type, beat_duration);

                    //the set of beats for each time stamp
                    List<BeatInfo> beatSet = new List<BeatInfo>();
                    if(upcomingBeats.ContainsKey(beat_timestamp)){
                        
                        if (upcomingBeats.TryGetValue(beat_timestamp, out beatSet))
                        {
                            beatSet.Add(newBeat);
                            upcomingBeats[beat_timestamp] = beatSet;
                            Console.WriteLine("two notes");

                            // Maybe all of this (within TryGetValue if statement)
                            // can be shortened down to just: 
                            // upcomingBeats[beat_timestamp].Add(newBeat);
                        }
                        else
                        {
                            Console.WriteLine("Value is not found.");
                        }
                    }
                    else {
                        
                        beatSet.Add(newBeat);
                        upcomingBeats.Add(beat_timestamp, beatSet);
                    }
                }
                else { firstLine = 1; }
            }

        }

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
