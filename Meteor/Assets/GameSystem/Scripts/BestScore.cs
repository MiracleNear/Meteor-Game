using System;
using UnityEngine;

namespace GameSystem
{
    public class BestScore : MonoBehaviour
    {
        
        private BestScoreView _bestScoreView;
        private DistanceCounter _distanceCounter;
        private float _bestScore;
        private bool _isBestScoreBeaten;
        
        private void Awake()
        {
            _distanceCounter = FindObjectOfType<DistanceCounter>();
            _bestScoreView = FindObjectOfType<BestScoreView>();
        }

        private void Start()
        {
            _bestScore = PlayerPrefs.GetFloat("BestScore", 0f);

            _bestScoreView.SetLastBestScore(_bestScore);
        }

        private void OnEnable()
        {
            _distanceCounter.DistanceCounted += OnDistanceCounted;
        }

        private void OnDisable()
        {
            _distanceCounter.DistanceCounted -= OnDistanceCounted;
        }

        private void OnDestroy()
        {
            if (_isBestScoreBeaten)
            {
                PlayerPrefs.SetFloat("BestScore", _bestScore);
                PlayerPrefs.Save();
            }
        }

        private void OnDistanceCounted(float distance)
        {
            if (distance > _bestScore)
            {
                _bestScoreView.SetNewBestScore(distance);
                _bestScore = distance;
                _isBestScoreBeaten = true;
            }
        }
    }
}