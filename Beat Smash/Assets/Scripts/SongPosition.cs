using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* also handles playing of the audio file */
public class SongPosition : MonoBehaviour {

    public const float TIME_BEFORE_AUDIO_START = 3;

    /* Reference if dspTime ends up too be too coarse-grained
     * https://www.reddit.com/r/gamedev/comments/13y26t/how_do_rhythm_games_stay_in_sync_with_the_music/c78aawd/?st=jgsnel9i&sh=fd38a50e
     */
    //current song position (relative to song) in milliseconds (?)
    private float currentSongPosition;
    private float initialDspTime;

    //audio that is playing
    AudioSource myAudio;

    /* look into easing/smoothing later... */
    //where the game thought it was last we checked (relative to song)
    /* private float lastReportedSongPosition;
    //ABSOLUTE time at the last frame
    private float lastFramePosition; */

    /* GETTERS */
    public float getSongPos() { return currentSongPosition; }
    public AudioSource getAudio() { return myAudio;  }

    // Use this for initialization
    void Start () {
        currentSongPosition = 0;
        //lastReportedSongPosition = 0;
        //lastFramePosition = Time.time;

        myAudio = GetComponent<AudioSource>();

        initialDspTime = (float)AudioSettings.dspTime;

        //play audio with delay
        myAudio.PlayDelayed(TIME_BEFORE_AUDIO_START);
    }
	
	// Update is called once per frame
	void Update () {
        //convert to milliseconds
        currentSongPosition = (float)(AudioSettings.dspTime - initialDspTime) * 1000;
	}
}
