using UnityEngine;

namespace Root.MaximEnvironment
{
    public interface IInteractableObject
    {
        string Description { get; }
        
        void Interact();

        void Select();
        
        void Unselect();
    }
}