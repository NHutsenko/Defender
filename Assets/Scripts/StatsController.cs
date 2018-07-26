using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class StatsController : CatchedMonoBehaviour {
        private const int MaxHp = 100;
        public int CurrentHp { get; private set; }
        [SerializeField]
        public Stat Damage;
        // for the future
        [SerializeField]
        public Stat Armor;

        // event for changing HealthUI slider
        public event System.Action<int, int> OnHealthChanged;

        private void Start() {
            CurrentHp = MaxHp;
        }

        public void HPRegeneration(int rVal)
        {
            if (CurrentHp >= MaxHp) return;
            CurrentHp += rVal;
        }

        public void TakeDamage(int damage) {
            damage -= Armor.Value;
            damage = Mathf.Clamp(damage, 0, int.MaxValue);
            CurrentHp -= damage;
            Debug.Log(transform.name + " takes " + damage + " damage");
            if (OnHealthChanged != null)
                OnHealthChanged(MaxHp, CurrentHp);
            if (CurrentHp > 0) return;
            //die anim
            Debug.Log(transform.name + " died");
            CurrentHp = 100;
            gameObject.SetActive(false);

        }
    }
}
