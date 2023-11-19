using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour
{
    [SerializeField]
    public AudioSource song;
    [SerializeField]
    private float _delaySong = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        song.PlayDelayed(_delaySong);
    }
}
