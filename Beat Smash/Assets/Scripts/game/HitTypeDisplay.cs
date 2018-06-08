using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HitTypeDisplay : MonoBehaviour
{
    private Sprite sprite;
    private Sprite[] allHitTypes;
    public SpriteRenderer spriteRend;

    public float angleRot = 5;
    private bool isShaking;

    private Quaternion startRotation;

    public void SetSprite(HitType ht)
    {
        switch (ht)
        {
            case HitType.Great:
                sprite = allHitTypes.Single(s => s.name == "HitType_Great");
                isShaking = false;
                break;
            case HitType.Good:
                sprite = allHitTypes.Single(s => s.name == "HitType_Good");
                isShaking = false;
                break;
            case HitType.Bad:
                sprite = allHitTypes.Single(s => s.name == "HitType_Bad");
                isShaking = false;
                break;
            case HitType.Miss:
                sprite = allHitTypes.Single(s => s.name == "HitType_Miss");
                isShaking = true;
                break;
            default:
                sprite = null;
                break;
        }

        if (sprite != null)
        {
            spriteRend.sprite = sprite;
            gameObject.SetActive(true);
            Fade();
        }
    }

    public void Shake()
    {
        Quaternion temp = transform.rotation;
        temp = startRotation * Quaternion.AngleAxis(UnityEngine.Random.Range(-angleRot, angleRot), new Vector3(0f, 0f, 1f));
        transform.rotation = temp;
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
        isShaking = false;
        startRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
		if (isShaking)
        {
            Shake();
        } else
        {
            transform.rotation = startRotation;
        }
	}
}
