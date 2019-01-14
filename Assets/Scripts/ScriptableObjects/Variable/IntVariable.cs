using UnityEngine;

namespace SpaceRoguelike
{
    [CreateAssetMenu (menuName = "Variable/Int")]
    public class IntVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public int Value;

        public void SetValue(int value)
        {
            Value = value;
        }

        public void SetValue(IntVariable value)
        {
            Value = value.Value;
        }

        public void AddAmount(int amount)
        {
            Value += amount;
        }

        public void AddAmount(IntVariable amount)
        {
            Value += amount.Value;
        }

        public void MultiplyAmount(int amount)
        {
            Value *= amount;
        }

        public void MultiplyAmount(IntVariable amount)
        {
            Value *= amount.Value;
        }
    }
}