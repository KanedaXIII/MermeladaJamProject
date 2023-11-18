using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public SongManager songManager;
    void Awake()
    {

        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        songManager.StartSong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
