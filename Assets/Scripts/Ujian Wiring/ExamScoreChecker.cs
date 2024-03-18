using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace InstalasiIoT
{
    public class ExamScoreChecker : MonoBehaviour
    {
        [SerializeField] private Slider scoreSlider;
        [SerializeField] private GameObject scoreLayout;
        [SerializeField] private Image fillSliderImage;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI scoreInfo;
        [SerializeField] private int totalQuest;

        [HideInInspector]
        public int totalScore = 0;

        [Header("Score Limit Threshold")]
        [SerializeField] private int scoreA;
        [SerializeField] private int scoreB;
        [SerializeField] private int scoreC;
        [SerializeField] private int scoreD;

        [Header("UI Slider config")]
        [SerializeField] private Color fillColorA;
        [SerializeField] private Color fillColorB;
        [SerializeField] private Color fillColorC;
        [SerializeField] private Color fillColorD;
        [SerializeField] private Sprite starBorder;
        [SerializeField] private Sprite starFill;
        [SerializeField] private Image[] starUIImage;
        [SerializeField] private int totalStarA;
        [SerializeField] private int totalStarB;
        [SerializeField] private int totalStarC;
        [SerializeField] private int totalStarD;

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

        
        public void Submit()
        {
            var totalStar = 0;
            scoreLayout.SetActive(true);
            if (totalScore == scoreA)
            {
                scoreText.text = "A";
                float sliderValue = (float)totalScore / totalQuest;
                scoreSlider.value = sliderValue;
                totalStar = totalStarA;
                fillSliderImage.color = fillColorA;
                scoreInfo.text = "Sangat Baik";

            }
            else if (totalScore >= scoreB)
            {
                scoreText.text = "B";
                float sliderValue = (float)totalScore / totalQuest;
                scoreSlider.value = sliderValue;
                totalStar = totalStarB;
                fillSliderImage.color = fillColorB;
                scoreInfo.text = "Baik";
            }
            else if (totalScore >= scoreC)
            {
                scoreText.text = "C";
                float sliderValue = (float)totalScore / totalQuest;
                scoreSlider.value = sliderValue;
                totalStar = totalStarC;
                fillSliderImage.color = fillColorC;
                scoreInfo.text = "Cukup";
            }
            else if (totalScore >= 0)
            {
                scoreText.text = "D";
                float sliderValue = (float)totalScore / totalQuest;
                scoreSlider.value = sliderValue;
                totalStar = totalStarD;
                fillSliderImage.color = fillColorD;
                scoreInfo.text = "Gagal";
            }

            for (int i = 0; i < totalStar; i++)
            {
                starUIImage[i].sprite = starFill;
            }
        
        }

        public void RestartLevel()
        {
            // Get the index of the current active scene
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Reload the current scene
            SceneManager.LoadSceneAsync(currentSceneIndex,LoadSceneMode.Single);
        }
    }
}