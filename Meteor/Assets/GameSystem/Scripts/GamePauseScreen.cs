using TMPro;
using UnityEngine;

namespace GameSystem
{
    public class GamePauseScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _pauseInfo;
        
        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetAlpha(float alpha)
        {
            _pauseInfo.alpha = alpha;
        }
    }
}
