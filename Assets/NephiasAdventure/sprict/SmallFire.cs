using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFire : MonoBehaviour {

    Rigidbody2D thisRigidbody2D;
    Health thisHealth;
    Vector3 homing;

    Player _pl;

	// Use this for initialization
	void Start () {
        thisHealth = GetComponent<Health>();
        thisRigidbody2D = GetComponent<Rigidbody2D>();
        _pl = GameManager.Instance.pl;
	}
	
	// Update is called once per frame
	void Update () {
		if(thisHealth.HP <= 0)
        {
            Destroy(gameObject);
        }

        homing = _pl.transform.position - this.transform.position;
        homing.Normalize();

        thisRigidbody2D.velocity = homing * 3;

    }
}
