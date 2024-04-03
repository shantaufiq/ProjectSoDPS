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

        [Space(10)]
        [Header("Recap Info For Exam")]
        [SerializeField] private GameObject examRecapInfo;
        [Tooltip("If all quest is complete and user want to see feedback, exam recap will go to this position")]
        [SerializeField] private Transform positionToShow;
        [Tooltip("This is the position where recap info will be hide (since feedback of each exam is realtime, we cannot deactivate the GameObject)")]
        [SerializeField] private Transform hidePosition;

        [HideInInspector]
        public bool examSubmitted = false;

        private void Start()
        {
            HideRecapInfo();
        }

        public void AddScore()
        {
            if (examSubmitted) return;
            totalScore++;
        }

        public void RemoveScore()
        {
            if (examSubmitted) return;
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

            examSubmitted = true;
        
        }

        public void RestartLevel()
        {
            // Get the index of the current active scene
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Reload the current scene
            SceneManager.LoadSceneAsync(currentSceneIndex,LoadSceneMode.Single);
        }

        public void ShowRecapInfo()
        {
            examRecapInfo.transform.position = positionToShow.position;
        }

        public void HideRecapInfo()
        {
            examRecapInfo.transform.position = hidePosition.position;
        }
    }
}
