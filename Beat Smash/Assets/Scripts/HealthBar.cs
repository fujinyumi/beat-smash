using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private int level;

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
            level -= 10; 
        }
    }

    public void Hit()
    {
        if (level >= 95)
        {
            level = 100;
        } else
        {
            level += 5;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
