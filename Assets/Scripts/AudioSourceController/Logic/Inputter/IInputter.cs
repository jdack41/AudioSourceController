using UnityEngine;

namespace AudioSourceController.Logic.Inputter
{
    public interface IInputter
    {
        bool Effect1Trigger();
        bool Effect1TriggerEnd();
        bool Effect2Trigger();
        bool Effect2TriggerEnd();

        bool Effect1SetTrigger();

        delegate bool Trigger();
        (Trigger start, Trigger end) GetEffect1Triggers();
    }
}