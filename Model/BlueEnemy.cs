using UnityEngine;


namespace Geekbrains
{
    public sealed class BlueEnemy : Enemy, ISetDamage, ISelectedObj
    {
        private Vector3 _direction;

        private void Start()
        {
            _direction = new Vector3(Random.Range(-10, 10), 
                                     Random.Range(2, 10), 
                                     Random.Range(-10, 10));
        }

        public override void SetDamage(InfoCollision info)
        {
            if (_isDead) return;
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                if (!TryGetComponent<Rigidbody>(out _))
                {
                    gameObject.AddComponent<Rigidbody>();
                    var rigidBody = gameObject.GetComponent<Rigidbody>();
                    rigidBody.AddForce(_direction, ForceMode.Impulse);
                }
                Destroy(gameObject, _timeToDestroy);

                _isDead = true;
            }
        }

        public string GetMessage()
        {
            return gameObject.name;
        }
    }
}
