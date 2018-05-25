using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private int level;
    public const int HEALTH_ADD_GREAT = 5;
    public const int HEALTH_ADD_GOOD = 2;
    public const int HEALTH_DEDUCT_BAD = 5;
    public const int HEALTH_DEDUCT_MISS = 10;

    public Slider healthSlider;

    private int great;
    private int good;
    private int bad;
    private int miss;

    private bool dead;

    // Use this for initialization
    void Start () {
        level = 100;
        healthSlider.value = level;
        great = good = bad = miss = 0;
        dead = false;
	}

    // Getters
    public int getGreat()
    {
        return great;
    }
    public int getGood()
    {
        return good;
    }
    public int getBad()
    {
        return bad;
    }
    public int getMiss()
    {
        return miss;
    }
    public bool isDead()
    {
        return dead;
    }

    // decHealth must be called with an int argument
    // 0 for Miss, 1 for Bad
    public void decHealth(int accurate)
    {
        int dec;
        if (accurate == 0)
        {
            miss++;
            dec = HEALTH_DEDUCT_MISS;
        }
        else
        {
            bad++;
            dec = HEALTH_DEDUCT_BAD;
        }
        if (level <= dec)
        {
            dead = true;
        } else
        {
            level -= dec;
            healthSlider.value = level;
        }
    }

    // incHealth must be called with an int argument
    // 0 for Great, 1 for Good
    public void incHealth(int accurate)
    {
        int inc;
        if (accurate == 0)
        {
            great++;
            inc = HEALTH_ADD_GREAT;
        } else
        {
            good++;
            inc = HEALTH_ADD_GOOD;
        }
        if (level >= (100-inc))
        {
            level = 100;
        } else
        {
            level += inc;
        }
        healthSlider.value = level;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
