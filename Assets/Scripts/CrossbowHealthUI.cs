using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class CrossbowHealthUI : CachedMonoBehaviour
{

    [SerializeField]
    private Image _healthBar;
    [SerializeField]
    private Text _healthText;

	private void Start ()
	{
	    CachedStats.OnHealthChanged += OnHealthChanged;
	    _healthText.text = "100/100";
	    _healthBar.fillAmount = 1;
    }

    private void OnHealthChanged(int maxHealth, int currentHealth)
    {
        float healthPercent = currentHealth / (float) maxHealth;
        _healthText.text = String.Format("{0}/{1}", currentHealth, maxHealth);
        _healthBar.fillAmount = healthPercent;
    }
}
