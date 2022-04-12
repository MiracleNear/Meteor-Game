using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameSystem
{
    public class PauseHandler : MonoBehaviour
    {
        private List<IPauseHandler> _handlersOnTheObjects;

        private void Awake()
        {
            _handlersOnTheObjects = GetComponents<IPauseHandler>().ToList();
            
            Handle(ProjectContext.Instance.PauseManager.Register, _handlersOnTheObjects);
        }

        
        private void OnDestroy()
        {
            Handle(ProjectContext.Instance.PauseManager.UnRegister, _handlersOnTheObjects);
        }
        
        private void Handle(Action<IPauseHandler> action, List<IPauseHandler> handlers)
        {
            foreach (IPauseHandler handler in handlers)
            {
                action?.Invoke(handler);
            }
        }
    }
}