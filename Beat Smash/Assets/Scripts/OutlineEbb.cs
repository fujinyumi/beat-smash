using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutlineEbb : MonoBehaviour
{

    public int increaseInterval = 50;

    private bool isIntensifying = true;
    private int currentTick = 0;

    private Text myText;
    private Outline myOutline;

    public float startOpacity;

    // Use this for initialization
    void Start()
    {
        myOutline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {

            if (currentTick > increaseInterval)
            {
                isIntensifying = isIntensifying ? false : true;
                currentTick = 0;
            }

            if (isIntensifying)
            {
                 myOutline.effectColor = new Color(myOutline.effectColor.r, myOutline.effectColor.g, myOutline.effectColor.b, myOutline.effectColor.a + startOpacity / (float)increaseInterval);
            }
            else
            {
                myOutline.effectColor = new Color(myOutline.effectColor.r, myOutline.effectColor.g, myOutline.effectColor.b, myOutline.effectColor.a - startOpacity / (float)increaseInterval);

            }

            currentTick++;
    }
}
