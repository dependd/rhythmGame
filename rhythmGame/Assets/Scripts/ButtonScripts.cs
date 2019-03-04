using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScripts : MonoBehaviour {

    [SerializeField] GameObject startButton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameStart()
    {
        startButton.SetActive(false);
        //レーンをアクティブ化
        //該当の譜面をサーチ
        //ゲームスタート
    }
}
