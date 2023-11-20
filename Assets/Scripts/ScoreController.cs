using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class ScoreController : MonoBehaviour
{
    [HideInInspector]
    public int score=0;
    public float updateVelocity = 1;
    private float currentScore;
    public TextMeshProUGUI ScoreText;
    private float startTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore != score)
        {
            Debug.Log(" PRE_Worksssssss SCOREEEEEE");
            float time = (Time.time - startTime) * updateVelocity;
            currentScore = (int)Mathf.Lerp(currentScore,score,time);
            if (time>=1)
            {
                Debug.Log("Worksssssss SCOREEEEEE");
                currentScore = score;
                
            }
            ScoreText.text = currentScore.ToString();
        }
    }
    public void SetScore(int nextScore)
    {
        score = nextScore;
        startTime = Time.time;
    }

    public void AddScore(int nScore) 
    {
        int newScore = nScore + score;
        SetScore(newScore);
    }
}
