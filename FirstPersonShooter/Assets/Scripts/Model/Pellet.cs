using UnityEngine;


namespace Geekbrains
{
    public sealed class Pellet : Fraction
    {
        private Rigidbody _rigidbody;

        protected override void Awake()
        {
            base.Awake();

            transform.localRotation = Quaternion.identity;
            transform.localRotation = Quaternion.Euler(_currentWeapon.Barrel.localRotation.x + Random.Range(_minAngleRot, _maxAngleRot),
                transform.localRotation.y + Random.Range(_minAngleRot, _maxAngleRot), transform.localRotation.z + Random.Range
                (_minAngleRot, _maxAngleRot));
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.AddForce(transform.forward * _currentWeapon.Force, ForceMode.Impulse);
            
        }

        private void OnCollisionEnter(Collision collision)
        {            
            var tempObj = collision.gameObject.GetComponent<ICollision>();

            if (tempObj != null)
            {
                tempObj.OnCollision(new InfoCollision(_curDamage, collision.contacts[0], collision.transform,
                    Rigidbody.velocity));
                Debug.Log(collision.gameObject.name);
                DestroyAmmunition();
            }
            
            DestroyAmmunition(_timeToDestruct);
        }
    }
}
