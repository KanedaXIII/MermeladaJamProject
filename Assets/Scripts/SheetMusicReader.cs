using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetMusicReader : MonoBehaviour
{
    public TextAsset sheetMusicData;

    private NoteInfo[] _dataSongCurrent;

    public NoteInfo[] DataSong { get => _dataSongCurrent; set => _dataSongCurrent = value; }

    // Start is called before the first frame update
    void Awake()
    {
        ReadCSV();
    }

    public void ReadCSV()
    {
        string[] data = sheetMusicData.text.Split(new string[] {"\n" },System.StringSplitOptions.None);

        int tableSize = data.Length/3 - 1;
        NoteInfo[] _dataSong = new NoteInfo[tableSize];

        for (int i = 1; i < tableSize; i++)
        {
            string[] dataC = data[i].Split(new string[] {";"},System.StringSplitOptions.None);
            _dataSong[i] = new NoteInfo();
            Debug.Log(dataC[0]);
            _dataSong[i].row = int.Parse(dataC[0]);
            Debug.Log(dataC[1]);
            _dataSong[i].time = float.Parse(data[1]);
            _dataSong[i].type = char.Parse(data[2]);
           
        }
        _dataSongCurrent = _dataSong;
    }
}
