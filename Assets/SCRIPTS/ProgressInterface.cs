using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressInterface : MonoBehaviour {

    [Header("Barras para Interface de Progressão")]
    public Slider barraXP;
    public Slider barraHP;
    public Slider barraMana;

    //Variáveis de Missões futuramente

    void Start()
    {
		PlayerProgress.MaxHP = 100f;
		PlayerProgress.MaxMana = 100f;
		PlayerProgress.manaRecovery = 1.5f;
		PlayerProgress.healthRecovery = 1f;
		PlayerProgress.Attack = 20f;
		PlayerProgress.Defense = 0f;

		barraHP.maxValue = PlayerProgress.MaxHP;
		barraMana.maxValue = PlayerProgress.MaxMana;

		PlayerProgress.HP = PlayerProgress.MaxHP;
		PlayerProgress.Mana = PlayerProgress.MaxMana;
    }


    void Update () {
        barraHP.value = PlayerProgress.HP;
        barraMana.value = PlayerProgress.Mana;
        barraXP.value = PlayerProgress.XP;

        PlayerProgress.HP = Mathf.Clamp(PlayerProgress.HP, barraHP.minValue, PlayerProgress.MaxHP);
		PlayerProgress.Mana = Mathf.Clamp(PlayerProgress.Mana, barraMana.minValue, PlayerProgress.MaxMana);
        PlayerProgress.XP= Mathf.Clamp(PlayerProgress.XP, barraXP.minValue, barraXP.maxValue);

        if (PlayerProgress.HP <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void SubtractHP(float damage)
    {
        PlayerProgress.HP -= damage;
    }

    /// <summary>
    /// Upgrades HP when with enough XP
    /// </summary>
	public void UpgradeHP(float amountSpent)
    {
		Debug.Log ("Up HP");

		if (PlayerProgress.XP >= barraXP.maxValue) {
			barraHP.maxValue += 20f;
			PlayerProgress.XP = 0f;
		}
    }
    /// <summary>
    /// Upgrades Mana when with enough XP
    /// </summary>
    public void UpgradeMana()
    {
		Debug.Log ("Up Mana");

		if (PlayerProgress.XP >= barraXP.maxValue) {
			barraMana.maxValue += 20f;
			PlayerProgress.XP = 0f;
			PlayerProgress.manaRecovery += 0.1f;
		}
    }
    /// <summary>
    /// Upgrades Attack when with enough XP
    /// </summary>
    public void UpgradeAttack()
    {
		Debug.Log ("Up Atk");

		if (PlayerProgress.XP >= barraXP.maxValue) {
			PlayerProgress.Attack += 20f;
			PlayerProgress.XP = 0f;
		}
    }
    /// <summary>
    /// Upgrades Defense when with enough XP
    /// </summary>
    public void UpgradeDefense()
    {
		Debug.Log ("Up Def");

		if (PlayerProgress.XP >= barraXP.maxValue) {
			PlayerProgress.Defense += 20f;
			PlayerProgress.XP = 0f;
		}
    }

}
