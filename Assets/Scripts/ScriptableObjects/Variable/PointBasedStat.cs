using UnityEngine;

namespace SpaceRoguelike
{
    [CreateAssetMenu (menuName = "Variable/PointBasedStat")]
    public class PointBasedStat : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        [SerializeField]
        private bool isValueZero;
        [SerializeField]
        private bool isValueMax;
        [SerializeField]
        private FloatReference currentValue;
        [SerializeField]
        private FloatReference underflowValue;
        [SerializeField]
        private FloatReference overflowValue;
        [SerializeField]
        private StatCalculator maxValue;

        public StatCalculator MaxValue { get => maxValue; set => maxValue = value; }

        public FloatReference UnderflowValue
        {
            get
            {
                return underflowValue;
            }
        }

        public FloatReference OverflowValue
        {
            get
            {
                return overflowValue;
            }
        }

        public FloatReference CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                underflowValue = 0f;
                overflowValue = 0f;

                if (value < 0)
                {
                    underflowValue = 0f - value;
                    currentValue = 0f;
                }
                else if (value > maxValue.EffectiveStat)
                {
                    overflowValue = value - maxValue.EffectiveStat;
                    currentValue = maxValue.EffectiveStat;
                }
                else
                {
                    currentValue = value;
                }

                isValueZero = (currentValue == 0f);
                isValueMax = (currentValue == maxValue.EffectiveStat);

            }
        }

        public bool IsValueZero
        {
            get
            {

                return isValueZero;

            }
        }

        public bool IsValueMax
        {
            get
            {

                return isValueMax;

            }
        }
        
        public PointBasedStat(FloatReference current_value, FloatReference max_value)
        {

            maxValue = new StatCalculator(max_value);
            CurrentValue = current_value;

        }

    }
}