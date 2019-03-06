using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(GameObject.Find("GameManager") == false)
        {
            DontDestroyOnLoad(this.gameObject);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void Test()
    {
        SceneManager.LoadScene("Select");
    }
}
