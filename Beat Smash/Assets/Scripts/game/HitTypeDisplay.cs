using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HitTypeDisplay : MonoBehaviour
{
    private Sprite sprite;
    private Sprite[] allHitTypes;
    public SpriteRenderer spriteRend;

    public void SetSprite(HitType ht)
    {
        switch (ht)
        {
            case HitType.Great:
                sprite = allHitTypes.Single(s => s.name == "HitType_Great");
                Debug.Log("Sprite set great");
                break;
            case HitType.Good:
                sprite = allHitTypes.Single(s => s.name == "HitType_Good");
                Debug.Log("Sprite set good");
                break;
            case HitType.Bad:
                sprite = allHitTypes.Single(s => s.name == "HitType_Bad");
                Debug.Log("Sprite set bad");
                break;
            case HitType.Miss:
                sprite = allHitTypes.Single(s => s.name == "HitType_Miss");
                Debug.Log("Sprite set miss");
                break;
            default:
                Debug.Log("Cannot find hit type");
                break;
        }
        spriteRend.sprite = sprite;
        gameObject.SetActive(true);
        Fade();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Fade()
    {
        Invoke("Disable", 1);
    }

    // Use this for initialization
    void Start () {
        //set sprite renderer
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        allHitTypes = Resources.LoadAll<Sprite>("Sprites/HitType");
        sprite = allHitTypes.Single(s => s.name == "HitType_Great");
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
