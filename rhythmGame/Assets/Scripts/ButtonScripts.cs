using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public void TimingStart()
    {
        startButton.SetActive(false);
        note.StartMusic();
        sg.BGMStart();
        //レーンをアクティブ化
        //該当の譜面をサーチ
        //ゲームスタート
    }
    public void GameStart()
    {
        GameObject.Find("SceneManager").GetComponent<SceneManage>().ChangeScene();
    }
    public void Test()
    {
        GameObject.Find("SceneManager").GetComponent<SceneManage>().Test();
    }
}
