using UnityEngine;

namespace Root.MaximEnvironment
{
    public class UIKeyCode : MonoBehaviour
    {
        public bool Active
        {
            get => _active;

            set
            {
                _active = value;
                
                _activeVisual.SetActive(_active);
                
                _inactiveVisual.SetActive(!_active);
            }
        }

        private bool _active;
        
        [SerializeField] private GameObject _activeVisual;
        
        [SerializeField] private GameObject _inactiveVisual;
    }
}