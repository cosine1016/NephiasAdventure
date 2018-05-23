using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager> {

    public Player pl;

    protected override void Awake()
    {
        base.Awake();
        pl = FindObjectOfType<Player>();
    }

    // Use this for initialization
    void Start () {
        SceneManager.sceneLoaded += OnSceneLoad;
	}

    void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        pl = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update () {
		
	}

}
