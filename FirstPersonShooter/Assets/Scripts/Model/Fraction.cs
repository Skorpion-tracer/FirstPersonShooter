using UnityEngine;


namespace Geekbrains
{
    public class Fraction : Ammunition
    {
        protected Weapon _currentWeapon;

        protected override void Awake()
        {
            base.Awake();

            _currentWeapon = Object.FindObjectOfType<Weapon>();
        }        
    }
}
