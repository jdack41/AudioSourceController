using UnityEngine;

namespace AudioSourceController.Logic.Inputter
{
    public class KeyBoardInputter : IInputter
    {
        public bool Effect1Trigger()
        {
            return Input.GetKey(KeyCode.A);
        }

        public bool Effect1TriggerEnd()
        {
            return Input.GetKeyUp(KeyCode.A);
        }

        public bool Effect2Trigger()
        {
            return Input.GetKey(KeyCode.S);
        }

        public bool Effect2TriggerEnd()
        {
            return Input.GetKeyUp(KeyCode.S);
        }
    }
}