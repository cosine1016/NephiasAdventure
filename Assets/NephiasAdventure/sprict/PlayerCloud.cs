using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloud : MonoBehaviour {

    BoxCollider2D colliderPass;
    Health thisHealth;

    // Use this for initialization
    void Start () {
        colliderPass = GetComponent<BoxCollider2D>();
        thisHealth = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("down"))
        {
            StartCoroutine("GetOffCloud");
        }
        if(thisHealth.HP <= 0)
        {
            Destroy(gameObject);
        }
	}

    IEnumerator GetOffCloud()
    {
        colliderPass.enabled = false;
        yield return new WaitForSeconds(.3f);
        colliderPass.enabled = true;
        yield break; 
    }
}
