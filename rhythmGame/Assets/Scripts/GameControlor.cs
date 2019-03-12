using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameControlor : MonoBehaviour {

    [SerializeField] UIManager _UIManager;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clips;
    public GameObject[] notes;
    private float[] _timing;
    private int[] _lineNum;
    private int combo = 0;

    public string filePass;
    private int _SpawndNotesCount = 0;
    public int _LineCheckNoteCount = 0;
    
    private float _startTime = 0;

    public float timeOffset = -1;

    private bool _isPlaying = false;
    public GameObject startButton;

    float timing;
    public int highSpeed;

    void Start()
    {
        InstanceTiming(highSpeed);
        _timing = new float[1024];
        _lineNum = new int[1024];
        LoadCSV();
        StartGame();
    }

    void Update()
    {
        if (_isPlaying)
        {
            CheckNextNotes();
            CheckKey();
        }

    }

    public void StartGame()
    {
        //startButton.SetActive(false);
        _startTime = Time.time;
        audioSource.Play();
        _isPlaying = true;
    }

    void CheckNextNotes()
    {
        while (_timing[_SpawndNotesCount] + timeOffset < GetMusicTime() && _timing[_SpawndNotesCount] != 0)
        {
            SpawnNotes(_lineNum[_SpawndNotesCount]);
            _SpawndNotesCount++;
        }
    }
    private void CheckKey()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (CheckNoteTiming(0))
            {
                Debug.Log("line0 == true");
                Destroy(GameObject.Find("Note(Clone)" + 0));
                _LineCheckNoteCount++; _UIManager.ComboCount(combo);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (CheckNoteTiming(1))
            {
                Debug.Log("line1 == true"); Destroy(GameObject.Find("Note(Clone)" + 1)); _UIManager.ComboCount(combo);
                _LineCheckNoteCount++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckNoteTiming(2))
            {
                Debug.Log("line2 == true"); Destroy(GameObject.Find("Note(Clone)" + 2)); _LineCheckNoteCount++; _UIManager.ComboCount(combo);
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (CheckNoteTiming(3))
            {
                _LineCheckNoteCount++;
                Debug.Log("line3 == true"); Destroy(GameObject.Find("Note(Clone)" +3)); _UIManager.ComboCount(combo);
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (CheckNoteTiming(4))
            {
                Debug.Log("line4 == true"); Destroy(GameObject.Find("Note(Clone)" + 4)); _LineCheckNoteCount++;_UIManager.ComboCount(combo);

            }
        }
    }
    bool CheckNoteTiming(int num)
    {
        if(_timing[_LineCheckNoteCount] + timeOffset < GetMusicTime() + 1 && _timing[_LineCheckNoteCount] + timeOffset < GetMusicTime() - 1 && _lineNum[_LineCheckNoteCount] == num)
        {
            combo++;
            return true;
        }
        return false;
    }

    void ComboCount()
    {

    }

    void SpawnNotes(int num)
    {
        Instantiate(notes[num],new Vector3(-4.0f + (2.0f * num), 9.0f, 0), Quaternion.identity).name += num;
    }

    void LoadCSV()
    {

        TextAsset csv = Resources.Load(filePass) as TextAsset;
        Debug.Log(csv.text);
        StringReader reader = new StringReader(csv.text);

        int i = 0;
        while (reader.Peek() > -1)
        {
            
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (int j = 0; j < values.Length; j++)
            {
                _timing[i] = float.Parse(values[0]) + timing;
                _lineNum[i] = int.Parse(values[1]);
            }
            i++;
        }
    }

    private void InstanceTiming(int hs)
    {
        //hs10 = timing-0.4f
        //hs5 = timing-1.5f
        switch (hs)
        {
            case 5:
                timing = -1.5f;
                break;
            case 6:
                timing = -1.05f;
                break;
            case 7:
                timing = -0.8f;
                break;
            case 8:
                timing = -0.65f;
                break;
            case 9:
                timing = -0.5f;
                break;
            case 10:
                timing = -0.4f;
                break;
        }
    }

    float GetMusicTime()
    {
        return Time.time - _startTime;
    }
}
