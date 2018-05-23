using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySmoke : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "smoke")
        {
            Destroy(col.gameObject);
        }
    }
}
