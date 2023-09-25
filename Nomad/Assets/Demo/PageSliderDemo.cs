using System;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.Popup;

namespace TS.PageSlider.Demo
{
    public class PageSliderDemo : MonoBehaviour
    {
        #region Variables

        [Header("References")]
        [SerializeField] private PageSlider _slider;
        [SerializeField] private SliderPage _pagePrefab;

        [Header("Configuration")]
        [SerializeField] private SliderItem[] _items;

        #endregion

        private void Start()
        {
            int selectedBackgroundIndex = PlayerPrefs.GetInt("SelectedBackgroundIndex", 0);

            for (int i = 0; i < _items.Length; i++)
            {
                var page = Instantiate(_pagePrefab);
                page.Text = _items[i].Text;
                page.Image = _items[i].Image;

                bool isBackgroundPurchased = PlayerPrefs.GetInt($"BackgroundPurchased_{i}", 0) == 1;

                if (i == selectedBackgroundIndex)
                {
                    page.SetBuyButtonText("Фон применен");
                }
                else if (isBackgroundPurchased)
                {
                    page.SetBuyButtonText($"Применить фон\n({_items[i].Cost} монет)");
                }
                else
                {
                    page.SetBuyButtonText($"Купить фон\n({_items[i].Cost} монет)");
                }

                int currentIndex = i; // Capture the current index for the lambda function

                // Inside the OnBuyButtonClicked lambda function
page.OnBuyButtonClicked(() =>
{
    if (currentIndex == selectedBackgroundIndex)
    {
        Debug.Log($"Фон уже применен: {_items[currentIndex].Text}");
    }
    else if (isBackgroundPurchased)
    {
        PlayerPrefs.SetInt("SelectedBackgroundIndex", currentIndex);
        ApplyBackground(currentIndex);
        Debug.Log($"Применен фон: {_items[currentIndex].Text}");
    }
    else
    {
        if (GameData.Coins >= _items[currentIndex].Cost)
        {
            GameData.Coins -= _items[currentIndex].Cost;
            _items[currentIndex].IsBought = true;
            PlayerPrefs.SetInt($"BackgroundPurchased_{currentIndex}", 1); // Save the purchase state

            page.SetBuyButtonText("Фон применен");
            CoinsSharedUI.Instance.UpdateCoinsUIText();
            Debug.Log($"Куплен фон: {_items[currentIndex].Text}");
        }
        else
        {
            Debug.Log("Недостаточно монет для покупки фона.");
            Popup.Show ("Нет монет", "У вас недостаточно монет для покупки фона", "Понятно") ;
        }
    }
});


                _slider.AddPage((RectTransform)page.transform);
            }

            if (selectedBackgroundIndex < _items.Length)
            {
                ApplyBackground(selectedBackgroundIndex);
            }
        }

        private void ApplyBackground(int index)
        {
            Debug.Log($"Applying background: {_items[index].Text}");
            // Apply the background logic here using _items[index].Image or similar
        }
    }

    [Serializable]
    public class SliderItem
    {
        [SerializeField] private string _text;
        [SerializeField] private Sprite _image;
        [SerializeField] private bool _isBought;
        [SerializeField] private int _cost;

        public string Text { get { return _text; } }
        public Sprite Image { get { return _image; } }
        public bool IsBought
        {
            get { return _isBought; }
            set { _isBought = value; }
        }
        public int Cost { get { return _cost; } }
    }
}
