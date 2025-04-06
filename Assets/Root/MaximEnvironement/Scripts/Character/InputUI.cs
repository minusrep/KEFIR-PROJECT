using UnityEngine;

namespace Root.MaximEnvironment
{
    public class InputUI : MonoBehaviour
    {
        public KeyCodeUI W;
        public KeyCodeUI A;
        public KeyCodeUI S;
        public KeyCodeUI D;
        public KeyCodeUI F;
        public KeyCodeUI G;
        public KeyCodeUI R;

        private void Update()
        {
            W.Active = Input.GetKey(KeyCode.W);
            A.Active = Input.GetKey(KeyCode.A);
            S.Active = Input.GetKey(KeyCode.S);
            D.Active = Input.GetKey(KeyCode.D);
            F.Active = Input.GetKey(KeyCode.F);
            G.Active = Input.GetKey(KeyCode.G);
            R.Active = Input.GetKey(KeyCode.R);
        }
    }
}