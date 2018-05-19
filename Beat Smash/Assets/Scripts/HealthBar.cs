using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private int level;
    public const int HEALTH_ADD_GREAT = 5;
    public const int HEALTH_ADD_GOOD = 2;
    public const int HEALTH_DEDUCT_MISS = 10;

    public Slider healthSlider;

    // Use this for initialization
    void Start () {
        level = 100;
        healthSlider.value = level;
	}
	
    public void Miss()
    {
        if (level <= 10)
        {
            //kill code
        } else
        {
            level -= HEALTH_DEDUCT_MISS;
            healthSlider.value = level;
            Debug.Log("MISS Health slider value = " + level.ToString());
        }
    }

    // Hit must be called with an int argument
    // 0 for Great, 1 for Good
    // Bad does not change health bar
    public void Hit(int accurate)
    {
        int inc;
        if (accurate == 0) {
            inc = HEALTH_ADD_GREAT;
        } else {
            inc = HEALTH_ADD_GOOD;
        }
        if (level >= (100-inc)) {
            level = 100;
        } else {
            level += inc;
        }
        healthSlider.value = level;
        Debug.Log("Health slider value = " + level.ToString());
    }

	// Update is called once per frame
	void Update () {
		
	}
}
