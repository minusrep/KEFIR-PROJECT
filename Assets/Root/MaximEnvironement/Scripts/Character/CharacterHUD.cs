using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Root.MaximEnvironment
{
    public class CharacterHUD : MonoBehaviour
    {
        [SerializeField] private CharacterInteraction _characterInteraction;
        
        [SerializeField] private CharacterInventory _characterInventory;

        [SerializeField] private CharacterHealth _characterHealth;

        [SerializeField] private TextMeshProUGUI _currentInteractionText;

        [SerializeField] private UIKeyCode A;

        [SerializeField] private UIKeyCode D;

        [SerializeField] private UIKeyCode W;

        [SerializeField] private UIKeyCode S;

        [SerializeField] private List<TextMeshProUGUI> _inventory;

        [SerializeField] private Image _healthBar;


         private void Update()
        {
            UpdateHealthBar();
            
            UpdateCurrentInteractableText();

            UpdateInventoryView();

            //UpdateWASD();
        }

        private void UpdateHealthBar() 
            => _healthBar.fillAmount = _characterHealth.CurrentHealth / _characterHealth.MaxHealth;

        private void UpdateWASD()
        {
            A.Active = Input.GetKey(KeyCode.A);
            
            D.Active = Input.GetKey(KeyCode.D);
            
            W.Active = Input.GetKey(KeyCode.W);
            
            S.Active = Input.GetKey(KeyCode.S);
        }

        private void UpdateInventoryView()
        {
            _inventory.ForEach(a => a.text = string.Empty);

            for (int i = 0; i < _characterInventory.Items.Count; i++)
            {
                var item = _characterInventory.Items[i];
                var view = _inventory[i];

                if (item == null) break;

                view.text = item.Description;
            }
        }
        
        private void UpdateCurrentInteractableText() 
            => _currentInteractionText.text = _characterInteraction.CurrentInteractiveObject ? _characterInteraction.CurrentInteractiveObject.Description : String.Empty;
    }
}