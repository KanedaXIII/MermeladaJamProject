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
        StartCoroutine (StartWaitSong());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartWaitSong()
    {
        yield return new WaitForSeconds(2f);
        songManager.StartSong();
    }
}
