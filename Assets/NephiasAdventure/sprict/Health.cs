using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] int _hp; 
    public int HP { get { return _hp; } }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void causeDamgage(int hurt)
    {
        _hp -= hurt;
        return;
    }



}
