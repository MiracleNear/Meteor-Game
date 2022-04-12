using TMPro;
using UnityEngine;

namespace GameSystem
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textMeshPro;
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetWordSpacing(float distance)
        {
            _textMeshPro.wordSpacing = distance;
        }

        public void SetCharacterSpacing(float distance)
        {
            _textMeshPro.characterSpacing = distance;
        }
    }
}
