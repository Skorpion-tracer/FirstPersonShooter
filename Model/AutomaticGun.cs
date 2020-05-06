namespace Geekbrains
{
	public sealed class AutomaticGun : Weapon
	{
		public override void Fire()
		{
			if (!_isReady) return;
			if (Clip.CountAmmunition <= 0) return;
			var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
			temAmmunition.AddForce(_barrel.forward * Force);
			Clip.CountAmmunition--;
			_isReady = false;
			Invoke(nameof(ReadyShoot), _rechergeTime);
		}
	}
}