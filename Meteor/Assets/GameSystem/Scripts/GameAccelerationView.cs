using TMPro;
using UnityEngine;

namespace GameSystem
{
    [RequireComponent(typeof(TMP_Text))]
    public class GameAccelerationView : MonoBehaviour
    {
        private TMP_Text _gameAcceleration;

        private const string _format = "0.00";

        private void Awake()
        {
            _gameAcceleration = GetComponent<TMP_Text>();
        }

        public void SetAccelerationValue(float value)
        {
            _gameAcceleration.text = "x" + value.ToString(_format);
        }
        
    }
}
