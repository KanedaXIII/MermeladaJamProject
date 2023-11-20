using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongManager : MonoBehaviour
{
    public float noteDuration = 2;
    Queue<NoteInfo>[] rowQueue = { new Queue<NoteInfo>(), new Queue<NoteInfo>(), new Queue<NoteInfo>() };

    float[] nextNoteR = { -1, -1, -1 };


    public Row[] rows = new Row[3];

    public SheetMusicReader songMusicReader;

    public Row _currentRow;

    float startTime = 0;
    bool started = false;

    public AudioSource song;
    [SerializeField]
    private float _delaySong=1.5f;

    void Awake()
    {
        _currentRow = rows[0];
        _currentRow.actionzone.gameObject.GetComponent<Image>().color = Color.red;
    }
    void Start()
    {
       

        //fin carga de prueba
        for (int i = 0; i < nextNoteR.Length; i++)
        {
            nextNoteR[i] = startTime - 1;//para que no spawneen nada hasta tener un valor valido
        }
    }

    void Update()
    {
        if (started)
        {
            
            for (int i = 0; i < nextNoteR.Length; i++)
            {

                if (nextNoteR[i] < Time.time)
                {
                    if (rowQueue[i].Count > 0)
                    {
                        nextNoteR[i] = rowQueue[i].Dequeue().time-noteDuration;
                        rows[i].spawnNote(noteDuration);
                        //Debug.Log("nextNote: " + nextNoteR[i]);
                    }
                    else
                    {
                        nextNoteR[i] = Time.time - 1;
                    }
                }
            }
           

        }
    }
    public void StartSong()
    {
        rowQueue = songMusicReader.ReadCSV();
        Debug.Log("Song load");
        Debug.Log("StartSong!!");
        
        started = true;
        startTime = Time.time;
        for (int i = 0; i < nextNoteR.Length; i++)
        {
            if (rowQueue[i].Count > 0)
            {
                nextNoteR[i] = rowQueue[i].Dequeue().time -noteDuration;
                Debug.Log("nextNote: " + nextNoteR[i]);
            }
            else
            {
                nextNoteR[i] = Time.time - 1;
                Debug.Log("VOID LIST");
            }
        }
    }
    public bool ActivateRow() {//Usame Samu!!
        return _currentRow.activeActionZone();
    }
    public void SetCurrentActionZone(int selectRow)
    {
        _currentRow.actionzone.gameObject.GetComponent<Image>().color = Color.grey;
        _currentRow = rows[selectRow];
       _currentRow.actionzone.gameObject.GetComponent<Image>().color = Color.red;
    }
}
