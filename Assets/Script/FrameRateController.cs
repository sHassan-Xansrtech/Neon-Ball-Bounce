using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Script
{
    public class FrameRateController : MonoBehaviour
    {

        [SerializeField] private int targetFrameRate = 60;
        [SerializeField] private TMP_Text frameRateText;

        private void Start()
        {
            Application.targetFrameRate = targetFrameRate;
        }

        private void Update()
        {
            float currentFrameRate = 1f / Time.deltaTime;
            frameRateText.text = $"{currentFrameRate.ToString("F0")} FPS";
        }
    }
}