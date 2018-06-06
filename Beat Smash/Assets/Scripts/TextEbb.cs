using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEbb : MonoBehaviour {

    public int increaseInterval = 50;

    private bool isIntensifying = false;
    private int currentTick = 0;

    private Text myText;
    private Outline myOutline;

    public float startOpacity;

    // Use this for initialization
    void Start()
    {
        myText = GetComponent<Text>();
        myOutline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        //for performance reasons, only do this if there is any text
        if(myText.text != "") {
            if (currentTick > increaseInterval)
            {
                isIntensifying = isIntensifying ? false : true;
                currentTick = 0;
            }

            if (isIntensifying)
            {
                myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, myText.color.a + 1f/(float)increaseInterval);
                myOutline.effectColor = new Color(myOutline.effectColor.r, myOutline.effectColor.g, myOutline.effectColor.b, myOutline.effectColor.a + startOpacity / (float)increaseInterval);
            }
            else
            {
                myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, myText.color.a - 1f / (float)increaseInterval);
                myOutline.effectColor = new Color(myOutline.effectColor.r, myOutline.effectColor.g, myOutline.effectColor.b, myOutline.effectColor.a - startOpacity / (float)increaseInterval);

            }

            currentTick++;
        }//endif
    }
}
