using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacking
{
    void HeroIsDealingDamage(Hero atacker, Hero Target);//helps to choose a method of dealing damage
    void HeroIsDealingDamage(Hero atacker, OnClickCatle Target);//helps to choose a method of dealing damage

}
