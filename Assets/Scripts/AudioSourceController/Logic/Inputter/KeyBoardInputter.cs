using UnityEngine;

namespace AudioSourceController.Logic.Inputter
{
    public class KeyBoardInputter : IInputter
    {
        public bool Effect1KeyDown()
        {
            return Input.GetKey(KeyCode.A);
        }

        public bool Effect1KeyUp()
        {
            return Input.GetKeyUp(KeyCode.A);
        }
    }
}