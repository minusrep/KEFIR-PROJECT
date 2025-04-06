using System.Collections;
using Root.MaximEnvironment;
using Root.Rak.Tests;

namespace Root.MaximEnvironement
{
    public class RepairableDoor : InteractiveObject
    {
        public TestDoor TestDoor;

        public DoorAnimator DoorAnimator;

        private string _initDescription;
        
        private void Start()
        {
            _initDescription = Descirption;
            
            TestDoor.Dead += DoorAnimator.DestroyDoor;
            
            TestDoor.BuildedEvent += DoorAnimator.RepairDoor;
        }

        private void Update() 
            => Descirption = TestDoor.IsLife ? string.Empty : _initDescription;

        public void Interact()
        {
            if (TestDoor.IsLife) return;
            
            TestDoor.Build();
        }
    }   
}
