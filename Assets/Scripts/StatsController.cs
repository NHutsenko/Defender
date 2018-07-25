using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class StatsController : MonoBehaviour {

    private readonly int maxHP = 100;
    public int CurrentHP { get; private set; }
    [SerializeField]
    public Stat Damage;
    // for the future
    [SerializeField]
    public Stat Armor;

    // event for changing HealthUI slider
    public event System.Action<int, int> OnHealthChanged;

    private void Start() {
        CurrentHP = maxHP;
    }

    public void HPRegeneration(int rVal) {
        if(CurrentHP != maxHP)
            CurrentHP += rVal;
    }

    public void TakeDamage(int damage) {
        if (CurrentHP <= 0) {
            //die anim
            Debug.Log(transform.name + " died");
            CurrentHP = 100;
            gameObject.SetActive(false);
        }
        if (OnHealthChanged != null) {
            OnHealthChanged(maxHP, CurrentHP);
        }
        damage -= Armor.Value;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        CurrentHP -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");
    }
}
