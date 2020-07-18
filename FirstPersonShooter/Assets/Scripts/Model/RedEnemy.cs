using System;
using UnityEngine;


namespace Geekbrains
{
    public sealed class RedEnemy : Enemy, ICollision, ISelectedObj
    {
        public event Action OnPointChange;

        public override void OnCollision(InfoCollision info)
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
                }
                Destroy(gameObject, _timeToDestroy);

                OnPointChange?.Invoke();
                _isDead = true;
            }
        }

        public string GetMessage()
        {
            return gameObject.name + " / " + Hp.ToString();
        }
    }
}
