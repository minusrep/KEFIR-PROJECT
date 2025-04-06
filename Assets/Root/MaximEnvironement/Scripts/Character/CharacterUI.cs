using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Root.MaximEnvironment
{
    public class CharacterUI : MonoBehaviour
    {
        private CharacterInventory _characterInventory;
        
        private CharacterInteraction _characterInteraction;
        
        private CharacterHealth _characterHealth;
        
        [SerializeField] private TextMeshProUGUI _interactiveObjectStatus;

        [SerializeField] private Image _healthBar;

        [SerializeField] private List<Image> _itemsIcons;

        [SerializeField] private Sprite _defaultIcon;
        
        private void Start()
        {
            _characterHealth = GetComponent<CharacterHealth>();
            
             _characterInteraction = GetComponent<CharacterInteraction>();
             
             _characterInventory = GetComponent<CharacterInventory>();
        }

        private void Update()
        {
             UpdateInteractiveObjectStatus();
            
             UpdateHealthBar();
             
             UpdateInventory();
        }

        private void UpdateInventory()
        {
            _itemsIcons.ForEach(a => a.color = new Color(1f, 1f, 1f, 0f));

            for (int i = 0; i < _characterInventory.InventoryItems.Count; i++)
            {
                _itemsIcons[i].sprite = _characterInventory.InventoryItems[i].ItemIcon;
                
                _itemsIcons[i].color = new Color(1f, 1f, 1f, 1f);
            }
        }
        
        private void UpdateInteractiveObjectStatus() 
            => _interactiveObjectStatus.text = _characterInteraction.CurrentInteractiveObject ? _characterInteraction.CurrentInteractiveObject.Descirption : string.Empty;

        private void UpdateHealthBar() 
            => _healthBar.fillAmount = _characterHealth.CurrentHealth / _characterHealth.MaxHealth;
    }
}