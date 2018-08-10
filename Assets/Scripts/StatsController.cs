using UnityEngine;

namespace Assets.Scripts {
    [System.Serializable]
    public class StatsController : CachedMonoBehaviour {
        private const int MaxHp = 100;
        public int CurrentHp { get; protected set; }
        [SerializeField]
        public Stat Damage;
        // for the future
        [SerializeField]
        public Stat Armor;

        // event for changing HealthUI slider
        public event System.Action<int, int> OnHealthChanged;

        protected virtual void Start() {
            CurrentHp = MaxHp;
        }

        protected void HealthRegeneration(int healthPerTime) {
            if (CurrentHp < 100) {
                if (CurrentHp >= 100) {
                    CurrentHp = 100;
                    return;
                }
                CurrentHp += healthPerTime;
            }

            if (OnHealthChanged != null)
                OnHealthChanged(MaxHp, CurrentHp);
        }

        public void TakeDamage(int damage) {
            damage -= Armor.Value;
            damage = Mathf.Clamp(damage, 0, int.MaxValue);
            CurrentHp -= damage;
            Debug.Log(transform.name + " takes " + damage + " damage");
            if (OnHealthChanged != null)
                OnHealthChanged(MaxHp, CurrentHp);
            if (CurrentHp > 0)
                return;
            //die anim
            Debug.Log(transform.name + " died");
            CachedGameController.Points += 10;
            CurrentHp = 100;
            gameObject.SetActive(false);

        }
    }
}
