using System;
using UnityEngine;

namespace InputSystem.MobileInput
{
    public class InputMobileHandler : MonoBehaviour, IInput
    {
        public float RotationValue { get; private set; }
        public event Action RotatePressed;
        public event Action RotateDepressed;

        [SerializeField] private Joystick _joystick;

        private void Update()
        {
            float horizontalValue = _joystick.Horizontal;
            
            if (Mathf.Abs(horizontalValue) > 0)
            {
                RotationValue = horizontalValue;
                RotatePressed?.Invoke();
            }
            else
            {
                RotationValue = 0f;
                RotateDepressed?.Invoke();
            }
        }
    }
}