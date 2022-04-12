using System;
using UnityEngine;

namespace InputSystem.PCInput
{
    public class InputKeyboardHandler : MonoBehaviour, IInput
    {
        public float RotationValue { get; private set; }
        public event Action RotatePressed;
        public event Action RotateDepressed;

        private void Update()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                RotationValue = Input.GetAxis("Horizontal");
                RotatePressed?.Invoke();
            }
            else
            {
                RotationValue = 0F;
                RotateDepressed?.Invoke();
            }
        }
    }
}