using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteControlor : MonoBehaviour {
    UIManager _UIManager;
    GameControlor controlor;
    int hs;
    public float timing;
	// Use this for initialization
	void Start () {
        controlor = GameObject.Find("GameControlor").GetComponent<GameControlor>();
        _UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        hs = controlor.highSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.down * hs * Time.deltaTime;
        
        if(transform.position.y <= -5.0f)
        {
            Debug.Log(false);
            controlor._LineCheckNoteCount++;
            controlor.combo = 0;
            _UIManager.ComboCount(controlor.combo);
            Destroy(this.gameObject);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
    }
    private void OnTriggerExit(Collider other)
    {
    }
}
