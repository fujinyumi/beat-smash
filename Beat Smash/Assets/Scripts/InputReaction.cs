using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* please initialize inputKey in Unity before use. */
public class InputReaction : MonoBehaviour {

    public string inputKey;
    private bool isActive;

	// Use this for initialization
	void Start () {
        isActive = false;

        //set name of this game object
        gameObject.name = inputKey;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(inputKey))
        {
            transform.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 255);
            isActive = true;
        }
        if (Input.GetKeyUp(inputKey))
        {
            transform.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            isActive = false;
        }
    }
}
