using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBreak : MonoBehaviour {

    [SerializeField] GameObject ic;

    Player _pl;
    Suck _suck;

	// Use this for initialization
	void Start () {
        _pl = GameManager.Instance.pl;
        _suck = ic.GetComponent<Suck>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!_suck.canSuck) return;

        if (collision.gameObject.tag == "smoke")
        {
            Destroy(collision.gameObject);
            _pl.smokeAdd();
        }
    }
}
