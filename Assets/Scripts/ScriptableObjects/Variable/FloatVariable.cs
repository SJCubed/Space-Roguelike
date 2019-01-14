using UnityEngine;

namespace SpaceRoguelike
{
    [CreateAssetMenu (menuName = "Variable/Float")]
    public class FloatVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public float Value;

        public void SetValue(float value)
        {
            Value = value;
        }

        public void SetValue(FloatVariable value)
        {
            Value = value.Value;
        }

        public void AddAmount(float amount)
        {
            Value += amount;
        }

        public void AddAmount(FloatVariable amount)
        {
            Value += amount.Value;
        }

        public void MultiplyAmount(float amount)
        {
            Value *= amount;
        }

        public void MultiplyAmount(FloatVariable amount)
        {
            Value *= amount.Value;
        }
    }
}