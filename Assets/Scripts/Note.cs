using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [HideInInspector]
    public float startpos, endpos, actionPos;
    public float delay = 1;
    public float duration = 2;
    float startTime = 0;
    [HideInInspector]
    public bool active = false;
    [HideInInspector]
    public Row ownRow = null;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Lerp(startpos, endpos, (Time.time - startTime) / duration);
        transform.position = pos;
        if (transform.position.y <= endpos)
        {
            Debug.Log("miss note");
            //Destroy(gameObject);//Convertir en pool
            SimplePool.Despawn(gameObject);
        }
        else
        {
            if (transform.position.y < actionPos + delay && transform.position.y > actionPos - delay)
            {
                active = true;
            }
            else
            {
                active = false;
            }
        }

    }
    public void activateNote()
    {
        if (active)
        {
            Debug.Log("got it!!");
            // efecto guay
            //Destroy(gameObject);
            SimplePool.Despawn(gameObject);
        }
    }
    private void OnDestroy()
    {
        ownRow.notes.Remove(this);
    }
}
