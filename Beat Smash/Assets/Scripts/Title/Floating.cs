using System.Collections;
using System.Collections.Generic;
using UnityEngine;

float originalY;

private float floatStrength;

public class Floating : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.originalY = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x,
            originalY + ((float)Math.Sin(Time.time) * floatStrength),
            transform.position.z);
    }
}
