using UnityEngine;


namespace Geekbrains
{
    public sealed class Pellet : Fraction
    {
        private Rigidbody _rigidbody;

        protected override void Awake()
        {
            base.Awake();

            transform.localPosition = new Vector3(Random.Range(-0.4f, 0.4f), Random.Range(-0.4f, 0.4f), 0);

            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddForce(transform.forward * _currentWeapon.Force, ForceMode.Impulse);
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
