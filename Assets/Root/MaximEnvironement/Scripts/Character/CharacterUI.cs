using System.Collections.Generic;
using Root.MaximEnvironement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Root.MaximEnvironment
{
    public class CharacterUI : MonoBehaviour
    {
        public GameLoop GameLoop;
        
        private CharacterInventory _characterInventory;
        
        private CharacterInteraction _characterInteraction;
        
        private CharacterHealth _characterHealth;

        private CharacterProvider _characterProvider;
        
        
        [SerializeField] private TextMeshProUGUI _interactiveObjectStatus;

        [SerializeField] private Image _healthBar;

        [SerializeField] private List<Image> _itemsIcons;

        [SerializeField] private Sprite _defaultIcon;
        
        [SerializeField] private TextMeshProUGUI _ammo;

        [SerializeField] private TextMeshProUGUI _moneyAmount;

        [SerializeField] private TextMeshProUGUI _clocks;
        
        
        private void Start()
        {
            _characterHealth = GetComponent<CharacterHealth>();
            
             _characterInteraction = GetComponent<CharacterInteraction>();
             
             _characterInventory = GetComponent<CharacterInventory>();
             
             _characterProvider = GetComponent<CharacterProvider>();
        }
        
        private void Update()
        {
             UpdateInteractiveObjectStatus();
            
             UpdateHealthBar();
             
             UpdateInventory();

             UpdateAmmo();

             UpdateMoneyAmount();

             UpdateClocks();
        }

        private void UpdateClocks()
        {
            int total = (int) GameLoop.AllTime;
            
            int hours =  total / 60;
            
            int minutes = total % 60;
            
            _clocks.text = $"{hours.ToString("00")}:{minutes.ToString("00")}";
        }

        private void UpdateMoneyAmount() 
            => _moneyAmount.text = CharacterStats.MoneyAmount.ToString("$0.00");

        private void UpdateAmmo() 
            => _ammo.text = _characterProvider.CurrentAmmo.ToString("00");

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