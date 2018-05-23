using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFire : MonoBehaviour {

    Health thisHealth;

	// Use this for initialization
	void Start () {
        thisHealth = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		if(thisHealth.HP <= 0)
        {
            Destroy(gameObject);
        }

    }
}
