using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOutput : MonoBehaviour {

    [SerializeField] Sprite[] numberImage;
    [SerializeField] Sprite Non;
    [SerializeField] int digit;
    
    SpriteRenderer thisSpriteRenderer;
    Player _pl;

	// Use this for initialization
	void Start () {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        _pl = GameManager.Instance.pl;
	}
	
	// Update is called once per frame
	void Update () {
        int smokeValue = _pl.smokeValue();
        if (digit == 1)
        {
            thisSpriteRenderer.sprite = numberImage[smokeValue % 10];
        }
        else if (digit == 2)
        {
            if(smokeValue == 100)
            {
                thisSpriteRenderer.sprite = numberImage[0];
            }
            else
            {
                thisSpriteRenderer.sprite = numberImage[smokeValue / 10];
            }
        }
        else
        {
            if(smokeValue == 100)
            {
                thisSpriteRenderer.sprite = numberImage[1];
            }
            else
            {
                thisSpriteRenderer.sprite = Non;
            }

        }
	}
}
