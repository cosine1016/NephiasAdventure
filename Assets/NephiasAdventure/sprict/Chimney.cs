using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chimney : MonoBehaviour {

    [SerializeField] GameObject preSmoke;
    int  smokeCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(smokeCount <= 0)
        {
            Vector3 pos = transform.position;
            Instantiate(preSmoke, new Vector3(pos.x, pos.y + 0.5f, pos.z), transform.rotation);
            smokeCount = 10;
        }

        smokeCount--;
	}
}
