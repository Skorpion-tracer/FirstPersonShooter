namespace Geekbrains
{
    public sealed class ShotGun : Weapon
    {
        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            Instantiate(Ammunition, _barrel.position, _barrel.rotation);
            Clip.CountAmmunition--;
            _isReady = false;
            Invoke(nameof(ReadyShoot), _rechergeTime);
        }
    }
}