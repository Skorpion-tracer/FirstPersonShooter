using UnityEngine;


namespace Geekbrains
{
    public sealed class InputController : BaseController, IExecute
    {
        private KeyCode _activeFlashLight = KeyCode.T;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _reloadClip = KeyCode.R;
        private KeyCode _firstWeapon = KeyCode.Alpha1;
        private KeyCode _secondWeapon = KeyCode.Alpha2;
        private int _mouseButton = (int)MouseButton.LeftButton;
        private int _currentWeapon;

        private int CurrentWeapon
        {
            get => _currentWeapon;
            set {
                _currentWeapon = value;

                if (value >= ServiceLocator.Resolve<Inventory>().Weapons.Length)
                {
                    _currentWeapon = ServiceLocator.Resolve<Inventory>().Weapons.Length - 1;
                }

                if (value < 0) _currentWeapon = 0;
            }
        }

        public InputController()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Execute()
        {
            if (!IsActive) return;
            if (Input.GetKeyDown(_activeFlashLight))
            {
                ServiceLocator.Resolve<FlashLightController>().Switch();
            }

            #region Выбор оружия по колесику мыши

            var scrollWeapon = Input.GetAxis("Mouse ScrollWheel");
            if (scrollWeapon > 0)
            {
                CurrentWeapon++;
                SelectWeapon(CurrentWeapon);
            }
            else if (scrollWeapon < 0)
            {
                CurrentWeapon--;
                SelectWeapon(CurrentWeapon);
            }

            #endregion

            if (Input.GetKeyDown(_firstWeapon))
            {
                SelectWeapon(0);
            }

            if (Input.GetKeyDown(_secondWeapon))
            {
                SelectWeapon(1);
            }

            if (Input.GetMouseButton(_mouseButton))
            {
                if (ServiceLocator.Resolve<WeaponController>().IsActive)
                {
                    ServiceLocator.Resolve<WeaponController>().Fire();
                }
            }

            if (Input.GetKeyDown(_cancel))
            {
                ServiceLocator.Resolve<WeaponController>().Off();
            }

            if (Input.GetKeyDown(_reloadClip))
            {
                ServiceLocator.Resolve<WeaponController>().ReloadClip();
            }
        }

        /// <summary>
        /// Выбор оружия
        /// </summary>
        /// <param name="i">Номер оружия</param>
        private void SelectWeapon(int i)
        {
            ServiceLocator.Resolve<WeaponController>().Off();
            var tempWeapon = ServiceLocator.Resolve<Inventory>().Weapons[i]; //todo инкапсулировать
            if (tempWeapon != null)
            {
                ServiceLocator.Resolve<WeaponController>().On(tempWeapon);
            }
        }
    }
}
