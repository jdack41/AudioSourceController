using UnityEngine;
using static AudioSourceController.Logic.Inputter.IInputter;

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

        public (Trigger start, Trigger end) GetEffect1Triggers()
        {
            return (this.Effect1Trigger, this.Effect1TriggerEnd);
        }

        public bool Effect2Trigger()
        {
            return Input.GetKey(KeyCode.S);
        }

        public bool Effect2TriggerEnd()
        {
            return Input.GetKeyUp(KeyCode.S);
        }

        public bool Effect1SetTrigger()
        {
            return Input.GetKeyDown(KeyCode.I);
        }

        public bool MusicLoadingPanelTrigger()
        {
            return Input.GetKeyDown(KeyCode.Tab);
        }

        public bool SelectorChangeTrigger()
        {
            return Input.GetKeyDown(KeyCode.C);
        }

        public bool MusicPlayTrigger()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
}