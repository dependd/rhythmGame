using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteControlor : MonoBehaviour {
    
    GameControlor controlor;
    int hs;
	// Use this for initialization
	void Start () {
        controlor = GameObject.Find("GameControlor").GetComponent<GameControlor>();
        hs = controlor.highSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.down * hs * Time.deltaTime;
        if(transform.position.y <= -5.0f)
        {
            Debug.Log(false);
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
