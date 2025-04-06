using UnityEngine;
using UnityEngine.UI;

namespace Root.MaximEnvironment
{
    public class KeyCodeUI : MonoBehaviour
    {
        public bool Active
        {
            set
            {
                if (value) _icon.sprite = IconOff; 
                else _icon.sprite = IconOn;
            }
        }
        
        private Image _icon;

        [SerializeField] private Sprite IconOn;
        
        [SerializeField] private Sprite IconOff;

        private void Start() 
            => _icon = GetComponent<Image>();
    }
}