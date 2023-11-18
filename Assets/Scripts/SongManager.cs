using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public float noteDuration = 2;
    Queue<float>[] rowQueue = { new Queue<float>(), new Queue<float>(), new Queue<float>() };

    float[] nextNoteR = { -1, -1, -1 };


    public Row[] rows = new Row[3];

    public SheetMusicReader songMusicReader;

    float startTime = 0;
    bool started = false;
    //struct NoteInfo//por coordinar con Samu
    //{
    //    public int row;
    //    public char type;
    //    public float time;
    //    public NoteInfo(int row,float time, char type)
    //    {
    //        this.row = row;
    //        this.time = time;
    //        this.type = type;
    //    }
    //}
    void Awake()
    {
        //Carga de prueba
        //rowQueue[0].Enqueue(2.5f);
        //rowQueue[0].Enqueue(5);
        //rowQueue[0].Enqueue(7);
        //rowQueue[0].Enqueue(12);
        //rowQueue[0].Enqueue(16.5f);
        //rowQueue[0].Enqueue(20);
        //rowQueue[0].Enqueue(25);
        //rowQueue[0].Enqueue(26);
        //rowQueue[0].Enqueue(30);
        //songMusicReader.ReadCSV();
        for (int i = 0; i < songMusicReader.DataSong.Length; i++)
        {
            NoteInfo noteInfo = songMusicReader.DataSong[i];
            rowQueue[noteInfo.row].Enqueue(noteInfo.time);
        }
        Debug.Log("song load");

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
                        nextNoteR[i] = rowQueue[i].Dequeue()-noteDuration;
                        rows[i].spawnNote(noteDuration);
                        Debug.Log("nextNote: " + nextNoteR[i]);
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
        Debug.Log("StartSong!!");
        started = true;
        startTime = Time.time;
        for (int i = 0; i < nextNoteR.Length; i++)
        {
            if (rowQueue[i].Count > 0)
            {
                nextNoteR[i] = rowQueue[i].Dequeue()-noteDuration;
                Debug.Log("nextNote: " + nextNoteR[i]);
            }
            else
            {
                nextNoteR[i] = Time.time - 1;
            }
        }
    }
    public bool ActivateRow(int num) {//Usame Samu!!
        return rows[num].activeActionZone();
    
    }
}
