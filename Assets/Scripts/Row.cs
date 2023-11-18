using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    public Transform start, end,actionzone;
    [HideInInspector]
    public List<Note> notes = new List<Note>();
    public GameObject notePrefab;
    public bool activeActionZone()
    {
        bool point=false;
        for (int i=0;i<notes.Count;i++) {

            if (notes[i].active)
            {
                point = true;
            }
        }
        return point;
    }
    public void spawnNote(float duration)
    {
        GameObject go= Instantiate(notePrefab,transform);
        Note note = go.GetComponent<Note>();
        note.startpos = start.position.y;
        note.endpos = end.position.y;
        note.actionPos=actionzone.position.y;
        note.duration= duration;
        notes.Add(note);
        note.ownRow = this;
    }
}
