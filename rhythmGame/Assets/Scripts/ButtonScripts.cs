using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScripts : MonoBehaviour {

    [SerializeField] GameObject startButton;
    [SerializeField] StartGame sg;
    [SerializeField] NoteTimingMaker note;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameStart()
    {
        startButton.SetActive(false);
        note.StartMusic();
        sg.BGMStart();
        //レーンをアクティブ化
        //該当の譜面をサーチ
        //ゲームスタート
    }
}
