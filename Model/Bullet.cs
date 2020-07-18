﻿using UnityEngine;

namespace Geekbrains
{
    public sealed class Bullet : Ammunition
    {
        private void OnCollisionEnter(Collision collision)
        {
            var tempObj = collision.gameObject.GetComponent<ICollision>();

            if (tempObj != null)
            {
                tempObj.OnCollision(new InfoCollision(_curDamage, collision.contacts[0], collision.transform,
                    Rigidbody.velocity));
            }

            DestroyAmmunition();
        }
    }
}
