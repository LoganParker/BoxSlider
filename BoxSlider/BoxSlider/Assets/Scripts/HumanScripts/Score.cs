using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.MLAgents;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score Instance;
    private StatsRecorder statsRecorder;
    private int highScore = 0;
    public Text scoreText;

    void Awake()
    {
        Instance = this;
        statsRecorder = Academy.Instance.StatsRecorder;
    }
    
    void Update()
    {
        //scoreText.text = Mathf.FloorToInt(Time.timeSinceLevelLoad).ToString();
    }
    public void AddScore(int score)
    {
        if(score>highScore)
        {
            highScore = score;
            scoreText.text = score.ToString();
            statsRecorder.Add("High Score",highScore,StatAggregationMethod.MostRecent);
        }
    }

}
