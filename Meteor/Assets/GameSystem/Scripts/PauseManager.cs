using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class PauseManager : MonoBehaviour, IPauseHandler
    {
        private List<IPauseHandler> _handlers = new List<IPauseHandler>();

        public bool IsPaused { get; private set; }
        
        public void Register(IPauseHandler handler)
        {
            _handlers.Add(handler);
        }
        
        public void UnRegister(IPauseHandler handler)
        {
            _handlers.Remove(handler);
        }
        
        public void SetPaused(bool isPaused)
        {
            IsPaused = isPaused;

            foreach (IPauseHandler handler in _handlers)
            {
                handler.SetPaused(IsPaused);
            }
        }
    }
}