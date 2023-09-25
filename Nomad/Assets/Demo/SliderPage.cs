#region Includes
using System;

using TMPro;

using UnityEngine;
using UnityEngine.UI;
#endregion

namespace TS.PageSlider.Demo
{
    public class SliderPage : MonoBehaviour
    {
        #region Variables

        [Header("Children")]
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private Button _buyButton; // Add this field for the buy button

        public string Text
        {
            get { return _label.text; }
            set { _label.text = value; }
        }

        public Sprite Image
        {
            get { return _image.sprite; }
            set { _image.sprite = value; }
        }

        #endregion

        // Add a method to set the text of the buy button
        public void SetBuyButtonText(string buttonText)
        {
            _buyButton.GetComponentInChildren<Text>().text = buttonText;
        }

        // Add a method to handle the buy button click event
        public void OnBuyButtonClicked(Action onBuyClicked)
        {
            _buyButton.onClick.AddListener(() =>
            {
                if (onBuyClicked != null)
                {
                    onBuyClicked();
                }
            });
        }
    }
}
