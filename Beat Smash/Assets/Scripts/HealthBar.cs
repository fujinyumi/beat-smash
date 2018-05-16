using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private int level;
    public const int HEALTH_ADD_GREAT = 5;
    public const int HEALTH_ADD_GOOD = 2;
    public const int HEALTH_DEDUCT_MISS = 10;

    // Use this for initialization
    void Start () {
        level = 100;
	}
	
    public void Miss()
    {
        if (level <= 10)
        {
            //kill code
        } else
        {
            level -= HEALTH_DEDUCT_MISS; 
        }
    }

    // Hit must be called with an int argument
    // 0 for Great, 1 for Good
    // Bad does not change health bar
    public void Hit(int accurate)
    {
        int increment;
        if (accurate == 0) {
            increment = HEALTH_ADD_GREAT;
        } else {
            increment == HEALTH_ADD_GOOD;
        }
        if (level >= (100-increment)) {
            level = 100;
        } else {
            level += increment;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
