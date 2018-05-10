using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Test Class for Audio file: TestA
 * Returns Hard-coded beatmap for TestA
 */
public class TestA {

    public void LoadUpcomingBeats(SortedDictionary<int, List<BeatInfo>> upcomingBeats)
    {
        List<BeatInfo> listToInsert = new List<BeatInfo>();
        listToInsert.Add(new BeatInfo(Lane.D, BeatType.Hit, 510));
        listToInsert.Add(new BeatInfo(Lane.K, BeatType.Hit, 510));
        List<BeatInfo> listToInsert2 = new List<BeatInfo>();
        listToInsert.Add(new BeatInfo(Lane.F, BeatType.Hit, 1195));
        List<BeatInfo> listToInsert3 = new List<BeatInfo>();
        listToInsert.Add(new BeatInfo(Lane.J, BeatType.Held, 1820, 1000));
        upcomingBeats.Add(510, listToInsert);
        upcomingBeats.Add(1195, listToInsert2);
        upcomingBeats.Add(1820, listToInsert3);
    }
}
