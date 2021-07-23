using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//��ǥ: �ְ������� �ҷ��ͼ� bestScore ������ �Ҵ�.
//1.����� ������ �ҷ��ͼ� bestScore�� �Ҵ�.
//2.bestScore ���� UI�� ǥ��.
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
            currentScoreUI.text = "��������: " + currentScore;

            if (currentScore > bestScore)
            {
                bestScore++;
                bestScoreUI.text = "�ְ�����: " + bestScore;
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }
    //�̱��� ��ü
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
        bestScoreUI.text = "�ְ�����: " + bestScore;
    }
   
    
}
