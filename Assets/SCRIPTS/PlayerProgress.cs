using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour {
    
    #region Instance
    PlayerProgress progress;
    private void Awake()
    {
        progress = this;
    }
    #endregion

    public static float XP;

    public static float HP;
	public static float MaxHP;

    public static float Mana;
	public static float MaxMana;

	public static float Attack;

    public static float manaRecovery;

    public static float healthRecovery;

    public static float Defense;

    public static float Velocity;
    
}
