using UnityEngine;


namespace Geekbrains
{
    public sealed class FlashLightController : BaseController, IExecute, IInitialization
    {
        private FlashLightModel _flashLightModel;
        private FlashLightUi _flashLightUi;

        public void Initialization()
        {
            _flashLightModel = Object.FindObjectOfType<FlashLightModel>();
            _flashLightUi = Object.FindObjectOfType<FlashLightUi>();
        }

        public override void On()
        {
            if(IsActive) return;
            if (_flashLightModel.BatteryChargeCurrent <= 0) return;
            base.On();
            _flashLightModel.Switch(FlashLightActiveType.On);
            _flashLightUi.SetActiveText(true);
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _flashLightModel.Switch(FlashLightActiveType.Off);
            _flashLightUi.SetActiveText(false);
        }

        public void Execute()
        {
            if(!IsActive)
            {
                _flashLightModel.RecoverBatteryCharge();
            }
            else
            {
                _flashLightModel.Rotation();
                if (_flashLightModel.EditBatteryCharge())
                {
                    _flashLightUi.Text = _flashLightModel.BatteryChargeCurrent;
                }
                else
                {
                    Off();
                }
            }

            _flashLightUi.SliderValue = _flashLightModel.BatteryChargeCurrent;
        }
    }
}
