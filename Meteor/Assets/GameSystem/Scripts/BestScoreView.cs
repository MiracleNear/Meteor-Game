using TMPro;
using UnityEngine;

namespace GameSystem
{
    [RequireComponent(typeof(TMP_Text))]
    public class BestScoreView : MonoBehaviour
    {
        private TMP_Text _score;
        
        [SerializeField] private string _formatNewBestScore, _formatLastBestScore;

        private void Awake()
        {
            _score = GetComponent<TMP_Text>();
        }

        public void SetNewBestScore(float newScore)
        {
            _score.text = _formatNewBestScore + Mathf.Floor(newScore).ToString();
        }

        public void SetLastBestScore(float lastScore)
        {
            _score.text = _formatLastBestScore + Mathf.Floor(lastScore).ToString();
        }
    }
}