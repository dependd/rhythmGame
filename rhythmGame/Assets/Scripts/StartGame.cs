using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    [SerializeField]AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void BGMStart()
    {
        audioSource.clip = clips[0];
        audioSource.Play();
    }

}
