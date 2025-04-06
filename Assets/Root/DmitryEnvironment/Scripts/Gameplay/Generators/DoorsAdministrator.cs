using Root.Rak.Tests;
using UnityEngine;

namespace Root.Rak.Gameplay.Generators
{
    public class DoorsAdministrator : MonoBehaviour
    {
        private DoorStatus _status;

        [SerializeField] private TestDoor _doorRight;
        [SerializeField] private TestDoor _doorLeft;

        public void Awake() 
            => _status = DoorStatus.FULL;

        private void OnEnable()
        {
            _doorLeft.DestroyEvent += (() =>
            {
                if (_status == DoorStatus.FULL)
                    _status = DoorStatus.RIGHT;
                else
                    _status = DoorStatus.EMPTY;
            });

            _doorRight.DestroyEvent += (() =>
            {
                if (_status == DoorStatus.FULL)
                    _status = DoorStatus.LEFT;
                else
                    _status = DoorStatus.EMPTY;
            });

            _doorLeft.BuildedEvent += (() =>
            {
                if (_status == DoorStatus.EMPTY)
                    _status = DoorStatus.LEFT;
                else
                    _status = DoorStatus.FULL;
            });

            _doorRight.BuildedEvent += (() =>
            {
                if (_status == DoorStatus.EMPTY)
                    _status = DoorStatus.RIGHT;
                else
                    _status = DoorStatus.FULL;
            });
        }

        public DoorStatus GetDoorStatus()
            => _status;
    }
}