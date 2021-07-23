using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//목표: 최고점수를 불러와서 bestScore 변수에 할당.
//1.저장된 점수를 불러와서 bestScore에 할당.
//2.bestScore 값을 UI에 표시.
public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;
    private int currentScore;

    public Text bestScoreUI;
    private int bestScore;

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            currentScoreUI.text = "현재점수: " + currentScore;

            if (currentScore > bestScore)
            {
                bestScore++;
                bestScoreUI.text = "최고점수: " + bestScore;
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }
    //싱글톤 객체
    public static ScoreManager Instance = null;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고점수: " + bestScore;
    }
   
    
}
