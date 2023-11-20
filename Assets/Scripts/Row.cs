using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    public Transform start, end,actionzone;
    [HideInInspector]
    public List<Note> notes = new List<Note>();
    public GameObject notePrefab;
    public GameObject particlePrefab;
    private GameObject[] particles = new GameObject[0];
    public bool activeActionZone()
    {
        bool point=false;
        for (int i=0;i<notes.Count;i++) {

            if (notes[i].active)
            {
                point = true;
                //GameObject confetti= SimplePool.Spawn(particlePrefab, actionzone.position, actionzone.rotation);
                //confetti.GetComponent<UnpoolConfetti>().show=true;
            }
        }
        return point;
    }
    public void spawnNote(float duration)
    {
        GameObject go = SimplePool.Spawn(notePrefab, transform.position, transform.rotation,transform);
        //GameObject go = Instantiate(notePrefab, transform);
        Note note = go.GetComponent<Note>();
        note.startpos = start.position.y;
        note.endpos = end.position.y;
        note.actionPos=actionzone.position.y;
        note.duration= duration;
        notes.Add(note);
        note.ownRow = this;
    }
}
