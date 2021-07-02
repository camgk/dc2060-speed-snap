using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Scoreboard : MonoBehaviour
{
    
    public Text[] scoresText_10Pairs;
    public Text[] dateText_10Pairs;
    public Text[] scoresText_15Pairs;
    public Text[] dateText_15Pairs;
    public Text[] scoresText_20Pairs;
    public Text[] dateText_20Pairs;

    
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreBoard();
    }

    public void UpdateScoreBoard() {
        Config.UpdateScoreList();

        DisplayPairScoreData(Config.ScoreTimeList10Pairs, Config.PairNumberList10Pairs, scoresText_10Pairs, dateText_10Pairs);
        DisplayPairScoreData(Config.ScoreTimeList15Pairs, Config.PairNumberList15Pairs, scoresText_15Pairs, dateText_15Pairs);
        DisplayPairScoreData(Config.ScoreTimeList20Pairs, Config.PairNumberList20Pairs, scoresText_20Pairs, dateText_20Pairs);
    }

    private void DisplayPairScoreData(float[] scoreTimeList, string[] pairNumberList, Text[] scoreText, Text[] dataText) {
        for(var index = 0; index < 3; index++) {
            if(scoreTimeList[index] > 0) {
                var dataTime = Regex.Split(pairNumberList[index], "T");
                
                var minutes = Mathf.Floor(scoreTimeList[index] / 60);
                float seconds = Mathf.RoundToInt(scoreTimeList[index] % 60);

                scoreText[index].text = minutes.ToString("00") + ":" + seconds.ToString("00");

                dataText[index].text = dataTime[0] + " " + dataTime[1];
            }
            else {
                scoreText[index].text = " ";
                dataText[index].text = " ";
            }
        }
    }


}
