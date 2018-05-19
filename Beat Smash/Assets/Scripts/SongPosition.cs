using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* also handles playing of the audio file */
public class SongPosition : MonoBehaviour {

    public static SongPosition instance = null;

    public const float TIME_BEFORE_AUDIO_START = 3;

    /* Reference if dspTime ends up too be too coarse-grained
     * https://www.reddit.com/r/gamedev/comments/13y26t/how_do_rhythm_games_stay_in_sync_with_the_music/c78aawd/?st=jgsnel9i&sh=fd38a50e
     */
    //current song position (relative to song) in milliseconds (?)
    private float currentSongPosition;
    private float initialDspTime;

    public float songLength; 

    //audio that is playing
    AudioSource myAudio;

    /* look into easing/smoothing later... */
    //where the game thought it was last we checked (relative to song)
    /* private float lastReportedSongPosition;
    //ABSOLUTE time at the last frame
    private float lastFramePosition; */

    /* GETTERS */
    public float getSongPos() { return currentSongPosition; }
    public float getAudioLength() { return songLength;  }
    public AudioSource getAudio() { return myAudio;  }

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
        currentSongPosition = 0;
        //lastReportedSongPosition = 0;
        //lastFramePosition = Time.time;

        myAudio = GetComponent<AudioSource>();

        initialDspTime = (float)AudioSettings.dspTime;

        //play audio with delay
        myAudio.PlayDelayed(TIME_BEFORE_AUDIO_START);

        songLength = myAudio.clip.length*1000;
    }
	
	// Update is called once per frame
	void Update () {
        //convert to milliseconds
        currentSongPosition = (float)(AudioSettings.dspTime - initialDspTime) * 1000 - TIME_BEFORE_AUDIO_START*1000;
	}
}
