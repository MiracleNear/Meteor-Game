using TMPro;
using UnityEngine;

namespace GameSystem
{
    public class GameStarterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _countDown;
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void UpdateCountDownCounter(string info)
        {
            _countDown.text = info;
        }

        public void SetAlpha(float alpha)
        {
            _countDown.alpha = alpha;
        }
    }
}