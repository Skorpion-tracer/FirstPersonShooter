using UnityEngine;


namespace Geekbrains
{
    public class Fraction : Ammunition
    {
        [SerializeField] protected int _minAngleRot = -6;
        [SerializeField] protected int _maxAngleRot = 6;

        protected Weapon _currentWeapon;

        protected override void Awake()
        {
            base.Awake();

            _currentWeapon = Object.FindObjectOfType<ShotGun>();
        }        
    }
}
