using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ebb : MonoBehaviour {

    private const int INCREASE_INTERVAL = 100;

    private bool isIntensifying = true;
    private int currentTick = 0;

    private Light myLight;

	// Use this for initialization
	void Start () {
        myLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentTick > INCREASE_INTERVAL) {
            isIntensifying = isIntensifying ? false : true;
            currentTick = 0;
        }

        if (isIntensifying)
        {
            myLight.intensity += 0.1f; 
        }
        else
        {
            myLight.intensity -= 0.1f;
        }

        currentTick++;
	}
}
