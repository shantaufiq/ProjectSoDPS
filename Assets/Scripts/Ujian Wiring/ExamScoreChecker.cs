using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InstalasiIoT
{
    public class ExamScoreChecker : MonoBehaviour
    {
        [SerializeField] private Slider scoreSlider;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private int totalQuest;

        public int totalScore = 0;

        [Header("Score Limit Threshold")]
        [SerializeField] private int scoreA;
        [SerializeField] private int scoreB;
        [SerializeField] private int scoreC;
        [SerializeField] private int scoreD;

        public void AddScore()
        {
            totalScore++;
        }

        public void RemoveScore()
        {
            totalScore--;
            if (totalScore < 0)
            {
                totalScore = 0;
            }
        }

        // Implement this method to submit the score
        public void Submit()
        {
            scoreSlider.gameObject.SetActive(true);
            if (totalScore == scoreA)
            {
                scoreText.text = "A";
                float sliderValue = (float)totalScore / totalQuest;
                scoreSlider.value = sliderValue;
            }
            else if (totalScore >= scoreB)
            {
                scoreText.text = "B";
                float sliderValue = (float)totalScore / totalQuest;
                scoreSlider.value = sliderValue;
            }
            else if (totalScore >= scoreC)
            {
                scoreText.text = "C";
                float sliderValue = (float)totalScore / totalQuest;
                scoreSlider.value = sliderValue;
            }
            else if (totalScore >= 0)
            {
                scoreText.text = "D";
                float sliderValue = (float)totalScore / totalQuest;
                scoreSlider.value = sliderValue;
            }
        
        }
    }
}
