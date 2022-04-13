using System;
using TMPro;
using UnityEngine;

namespace GameSystem
{
    public class DistanceCounterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentScore;
        [SerializeField] private string _format;

        private DistanceCounter _distanceCounter;

        private void Awake()
        {
            _distanceCounter = FindObjectOfType<DistanceCounter>();
        }

        private void OnEnable()
        {
            _distanceCounter.DistanceCounted += OnDistanceCounted;
        }
        
        private void OnDisable()
        {
            _distanceCounter.DistanceCounted -= OnDistanceCounted;
        }
        
        private void OnDistanceCounted(float distance)
        {
            _currentScore.text = _format +  Mathf.Floor(distance).ToString();
        }
        
    }
}