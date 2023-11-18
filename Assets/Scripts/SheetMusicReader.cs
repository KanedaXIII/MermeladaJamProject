using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetMusicReader : MonoBehaviour
{
    public TextAsset sheetMusicData;

    [SerializeField]
    private int _nRows = 3;

    public Queue<NoteInfo>[] ReadCSV()
    {
        string[] data = sheetMusicData.text.Split(new string[] {"\n" },System.StringSplitOptions.None);
        Queue <NoteInfo>[]  queueRow= new Queue<NoteInfo>[_nRows];
        for(int i = 0; i < _nRows; i++)
        {
            queueRow[i] = new Queue<NoteInfo>();
        }
        for (int i = 1; i < data.Length; i++)
        {
            NoteInfo _dataSong = new NoteInfo();

            string[] dataC = data[i].Split(new string[] {";"},System.StringSplitOptions.None);
            _dataSong = new NoteInfo();
            _dataSong.row = int.Parse(dataC[0]);
            _dataSong.time = float.Parse(dataC[1].Trim());
            _dataSong.type = char.Parse(dataC[2].Trim());
            queueRow[_dataSong.row].Enqueue(_dataSong);
        }
       

        return queueRow;
    }
}
