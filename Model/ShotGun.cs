namespace Geekbrains
{
    public sealed class ShotGun : Weapon
    {
        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            Instantiate(Ammunition, Barrel.position, Barrel.rotation);
            Clip.CountAmmunition--;
            _isReady = false;
            Invoke(nameof(ReadyShoot), _rechergeTime);
        }
    }
}