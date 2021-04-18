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
        bool MusicLoadingPanelTrigger();
        bool SelectorChangeTrigger();
        bool MusicPlayTrigger();

        delegate bool Trigger();
        
        // TODO: その他Triggerもキー入れ替え対応のためdelegate経由に変更
        (Trigger start, Trigger end) GetEffect1Triggers();
    }
}