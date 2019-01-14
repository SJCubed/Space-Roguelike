using UnityEngine;

namespace SpaceRoguelike
{
    [CreateAssetMenu (menuName = "Variable/StatCalculator")]
    public class StatCalculator : ScriptableObject
    {
        [SerializeField]
        private FloatReference baseStat;
        [SerializeField]
        private FloatReference baseAdditive;
        [SerializeField]
        private FloatReference baseMultiplier;
        [SerializeField]
        private FloatReference totalAdditive;
        [SerializeField]
        private FloatReference totalMultiplier;
        [SerializeField]
        private FloatReference effectiveStat;

        public FloatReference BaseStat
        {
            get
            {
                return baseStat;
            }
            set
            {
                baseStat = value;
                CalculateEffectiveStat();
            }
        }

        public FloatReference BaseAdditive
        {
            get
            {
                return baseAdditive;
            }
            set
            {
                baseAdditive = value;
                CalculateEffectiveStat();
            }
        }

        public FloatReference BaseMultiplier
        {
            get
            {
                return baseMultiplier;
            }
            set
            {
                baseMultiplier = value;
                CalculateEffectiveStat();
            }
        }

        public FloatReference TotalAdditive
        {
            get
            {
                return totalAdditive;
            }
            set
            {
                totalAdditive = value;
                CalculateEffectiveStat();
            }
        }

        public FloatReference TotalMultiplier
        {
            get
            {
                return totalMultiplier;
            }
            set
            {
                totalMultiplier = value;
                CalculateEffectiveStat();
            }
        }

        public FloatReference EffectiveStat
        {
            get
            {
                return CalculateEffectiveStat();
            }
        }

        public FloatReference CalculateEffectiveStat()
        {
            return effectiveStat = (((baseStat + baseAdditive) * baseMultiplier) + totalAdditive) * totalMultiplier;
        }


        //Constructor with all values set
        public StatCalculator(FloatReference base_stat, FloatReference base_additive, FloatReference base_multiplier, FloatReference total_additive, FloatReference total_multiplier)
        {
            baseStat = base_stat;
            baseAdditive = base_additive;
            baseMultiplier = base_multiplier;
            totalAdditive = total_additive;
            totalMultiplier = total_multiplier;
            CalculateEffectiveStat();
        }

        //Constructor with just base value
        public StatCalculator(FloatReference base_stat)
        {
            baseStat = base_stat;
            baseAdditive = 0f;
            baseMultiplier = 1f;
            totalAdditive = 0f;
            totalMultiplier = 1f;
            CalculateEffectiveStat();
        }


        //Default Constructor
        public StatCalculator()
        {
            baseStat = 1f;
            baseAdditive = 0f;
            baseMultiplier = 1f;
            totalAdditive = 0f;
            totalMultiplier = 1f;
            CalculateEffectiveStat();
        }

    }

}