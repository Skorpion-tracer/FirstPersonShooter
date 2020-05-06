using UnityEngine;

namespace Geekbrains
{
	public sealed class UiInterface
	{
		private FlashLightUi _flashLightUi;

		public FlashLightUi LightUi
		{
			get
			{
				if (!_flashLightUi)
                    _flashLightUi = Object.FindObjectOfType<FlashLightUi>();
				return _flashLightUi;
			}
		}

        private WeaponUiText _weaponUiText;

        public WeaponUiText WeaponUiText
        {
            get {
                if (!_weaponUiText)
                    _weaponUiText = Object.FindObjectOfType<WeaponUiText>();
                return _weaponUiText;
            }
        }

        private SelectionObjMessageUi _selectionObjMessageUi;

		public SelectionObjMessageUi SelectionObjMessageUi
		{
			get
			{
				if (!_selectionObjMessageUi)
					_selectionObjMessageUi = Object.FindObjectOfType<SelectionObjMessageUi>();
				return _selectionObjMessageUi;
			}
		}
	}
}