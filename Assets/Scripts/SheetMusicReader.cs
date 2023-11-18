using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetMusicReader : MonoBehaviour
{
    public TextAsset sheetMusicData;
    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        string[] data = sheetMusicData.text.Split(new string[] { ";","\n" },System.StringSplitOptions.None);

        int tableSize = data.Length/3 - 1;

        for(int i = 0; i < tableSize; i++)
        {
            Debug.Log(data[3 *(i+1)]);
            Debug.Log(data[3 * (i + 1) + 1]);
            Debug.Log(data[3 * (i + 1) + 2]);
        }
    }
}
