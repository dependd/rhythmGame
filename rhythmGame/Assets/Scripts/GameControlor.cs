using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameControlor : MonoBehaviour {

    [SerializeField] UIManager _UIManager;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clips;
    [SerializeField] GameObject[] NoteLine;
    public int score;
    public GameObject[] notes;
    private float[] _timing;
    private int[] _lineNum;
    public int combo = 0;

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
        score = 0;
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
            if (NoteLine[0].transform.childCount == 0) return;
            if (CheckNoteTiming(0,NoteLine[0]))
            {
                Debug.Log("line0 == true");
                SuccessTap();
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log(GetMusicTime());
            if (NoteLine[1].transform.childCount == 0) return;
            if (CheckNoteTiming(1,NoteLine[1]))
            {
                Debug.Log("line1 == true");
                SuccessTap();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (NoteLine[2].transform.childCount == 0) return;
            if (CheckNoteTiming(2,NoteLine[2]))
            {
                Debug.Log("line2 == true");
                SuccessTap();
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            //Debug.Log(GetMusicTime());
            if (NoteLine[3].transform.childCount == 0) return;
            if (CheckNoteTiming(3,NoteLine[3]))
            {
                Debug.Log("line3 == true");
                SuccessTap();
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (NoteLine[4].transform.childCount == 0) return;
            if (CheckNoteTiming(4,NoteLine[4]))
            {
                Debug.Log("line4 == true");
                SuccessTap();
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            foreach(Object i in NoteLine[1].transform){
                Debug.Log(i);
            }
        }
    }
    void SuccessTap()
    {
        _LineCheckNoteCount++;
        _UIManager.ComboCount(combo);
        _UIManager.ScoreUp(score);
        Destroy(GameObject.Find("Note(Clone)" + _SpawndNotesCount));
    }


    bool CheckNoteTiming(int num,GameObject lineObj)
    {
        if(lineObj.GetComponentInChildren<NoteControlor>().timing + timeOffset < GetMusicTime() + 0.5f && lineObj.GetComponentInChildren<NoteControlor>().timing + timeOffset < GetMusicTime() - 0.5f && _lineNum[_LineCheckNoteCount] == num)
        {
            combo++;
            score += 3000;
            return true;
        }
        //if (_timing[_LineCheckNoteCount] + timeOffset < GetMusicTime() + 1 && _timing[_LineCheckNoteCount] + timeOffset < GetMusicTime() - 1 && _lineNum[_LineCheckNoteCount] == num)
        //{
        //    combo++;
        //    score += 3000;
        //    return true;
        //}
        return false;
    }

    void ComboCount()
    {

    }

    void SpawnNotes(int num)
    {
        var obj = Instantiate(notes[num],new Vector3(-4.0f + (2.0f * num), 9.0f, 0), Quaternion.identity);
        obj.name += _SpawndNotesCount;
        obj.transform.parent = NoteLine[num].transform;
        obj.GetComponent<NoteControlor>().timing = _timing[_SpawndNotesCount];
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
