using System;

namespace InputSystem
{
    public interface IInput
    {
        public float RotationValue { get; }
        public event Action RotatePressed;
        public event Action RotateDepressed;
    }
}