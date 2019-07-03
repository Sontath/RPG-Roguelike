using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LongShot))]
public class WizardClass : ClassBehavior
{
    [SerializeField]
    private LongShot LongShot; 

    public override void PrimaryAttack()
    {
        LongShot.Shoot();
    }

    public override void SecondaryAttack()
    {
        throw new System.NotImplementedException();
    }
}
