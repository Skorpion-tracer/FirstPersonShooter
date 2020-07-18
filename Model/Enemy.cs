using UnityEngine;


namespace Geekbrains
{
    public abstract class Enemy : MonoBehaviour, ICollision
    {		
        public float Hp = 100;

        protected bool _isDead;
        [SerializeField] protected float _timeToDestroy = 10.0f;

        public abstract void OnCollision(InfoCollision info);
    }
}
