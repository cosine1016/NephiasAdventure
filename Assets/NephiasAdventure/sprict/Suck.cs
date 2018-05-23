using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suck : MonoBehaviour {

    [SerializeField]GameObject sb;
    [SerializeField] float speed;
    public bool canSuck;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            canSuck = !canSuck;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!canSuck) return;

        if (collision.gameObject.tag == "smoke" )
        {
            Transform smokeTra = collision.gameObject.transform;
            Rigidbody2D smokeRig = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector3 sbPos = sb.transform.position;
            Vector3 smokePos = smokeTra.position;

            float rad = Mathf.Atan2(sbPos.y - smokePos.y, sbPos.x - smokePos.x);
            smokeRig.velocity = new Vector2(Mathf.Cos(rad) * speed, Mathf.Sin(rad) * speed);
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
