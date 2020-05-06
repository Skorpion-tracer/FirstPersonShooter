using UnityEngine;


namespace Geekbrains
{
    public class Fraction : Ammunition
    {
        private Weapon _currentWeapon;

        protected override void Awake()
        {
            base.Awake();

            _currentWeapon = Object.FindObjectOfType<Weapon>();

            var obj = GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody el in obj)
            {
                el.AddForce(transform.forward * _currentWeapon.Force, ForceMode.Impulse);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            var tempObj = collision.gameObject.GetComponent<ISetDamage>();

            if (tempObj != null)
            {
                tempObj.SetDamage(new InfoCollision(_curDamage, Rigidbody.velocity));
                DestroyAmmunition();
            }

            DestroyAmmunition(_timeToDestruct);
        }
    }
}
