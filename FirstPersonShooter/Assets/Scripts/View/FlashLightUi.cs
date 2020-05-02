using UnityEngine;
using UnityEngine.UI;


namespace Geekbrains
{
    public sealed class FlashLightUi : MonoBehaviour
    {
        private Text _text;
        private Slider _slider;

        private void Awake()
        {
            _text = GetComponentInChildren<Text>();
            _slider = GetComponentInChildren<Slider>();
        }

        public float Text
        {
            set => _text.text = $"{value:0.0}";
        }

        public float SliderValue
        {
            set => _slider.value = value;
        }

        public void SetActiveText(bool value)
        {
            _text.gameObject.SetActive(value);
        }
    }
}
