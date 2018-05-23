using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegCollider : MonoBehaviour {

    Player _pl;
    // Use this for initialization
    void Start () {
        _pl = GameManager.Instance.pl;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _pl.CanNotJump();
        }
    }
}
