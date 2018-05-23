using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamegeOnTouch : MonoBehaviour {

    public LayerMask targetLayer;
    [SerializeField] int damageVolume;
    [SerializeField] bool isSelfHarm;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (((1 << col.gameObject.layer) & targetLayer) != 0)
        {
            Health hp = col.gameObject.GetComponent<Health>();
            hp.causeDamgage(damageVolume);

            if(isSelfHarm)
            {
                Health selfhp = GetComponent<Health>();
                selfhp.causeDamgage(damageVolume);
            }
        }
        return;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (((1 << col.gameObject.layer) & targetLayer) != 0)
        {
            Health hp = col.gameObject.GetComponent<Health>();
            hp.causeDamgage(damageVolume);

            if (isSelfHarm)
            {
                Health selfhp = GetComponent<Health>();
                selfhp.causeDamgage(damageVolume);
            }
        }
        return;
    }
}
