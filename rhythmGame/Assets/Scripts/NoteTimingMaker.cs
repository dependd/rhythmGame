using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTimingMaker : MonoBehaviour {

    
    private float _startTime = 0;
    [SerializeField]private CSVWriter _CSVWriter;

    private bool _isPlaying = false;

    void Start()
    {
    }

    void Update()
    {
        if (_isPlaying)
        {
            DetectKeys();
        }
    }

    public void StartMusic()
    {
        _startTime = Time.time;
        _isPlaying = true;
    }

    void DetectKeys()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            WriteNotesTiming(0);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            WriteNotesTiming(1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            WriteNotesTiming(2);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            WriteNotesTiming(3);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            WriteNotesTiming(4);
        }
    }

    void WriteNotesTiming(int num)
    {
        Debug.Log(GetTiming());
        _CSVWriter.WriteCSV(GetTiming().ToString() + "," + num.ToString());
    }

    float GetTiming()
    {
        return Time.time - _startTime;
    }
}
