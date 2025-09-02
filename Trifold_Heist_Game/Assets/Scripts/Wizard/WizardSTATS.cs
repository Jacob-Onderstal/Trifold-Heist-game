using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSTATS : CharacterSTAST
{
    /*[SerializeField] private PlayerHUD hud;

    private void Start()
    {
        hud = GetComponent<PlayerHUD>();
    }*/

    public override void CheckHealth()
    {
        base.CheckHealth();
        //hud.UpdateHealth(health, MAXhealth);
    }
}
