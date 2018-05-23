using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {

    [SerializeField] GameObject preSmoke;
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    int cloudInterval;

    Rigidbody2D thisRigidbody2D;
    Health thisHealth;

    // Use this for initialization
    void Start () {
        thisRigidbody2D = GetComponent<Rigidbody2D>();
        thisHealth = GetComponent<Health>();
    }
	
	// Update is called once per frame
	void Update () {
        thisRigidbody2D.velocity = new Vector2(speedX, speedY);
        
        if(thisHealth.HP <= 0)
        {
            lampDeath();
        }

        if (cloudInterval <= 0)
        {
            Vector3 pos = transform.position;
            Instantiate(preSmoke, new Vector3(pos.x, pos.y + 0.5f, pos.z), transform.rotation);
            cloudInterval = 60;
        }
        cloudInterval--;
	}

    void lampDeath()
    {
        Destroy(gameObject);
    }
}
