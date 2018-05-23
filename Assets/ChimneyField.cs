using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyField : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "smoke")
        {
            Rigidbody2D smokeRig = collision.gameObject.GetComponent<Rigidbody2D>();
             smokeRig.velocity = new Vector2(0, 1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "smoke")
        {
            Rigidbody2D smokeRig = collision.gameObject.GetComponent<Rigidbody2D>();
            smokeRig.velocity = new Vector2(0, 0);
        }
    }
}
