using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TS.PageSlider.Demo
{
    public class BackgroundManager : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer backgroundRenderer;
        [SerializeField] private Sprite[] backgroundSprites;

        private void Start()
        {
            int selectedBackgroundIndex = PlayerPrefs.GetInt("SelectedBackgroundIndex", 0);
            SetActiveBackground(selectedBackgroundIndex);
        }

        public void SetActiveBackground(int backgroundIndex)
        {
            if (backgroundIndex >= 0 && backgroundIndex < backgroundSprites.Length)
            {
                backgroundRenderer.sprite = backgroundSprites[backgroundIndex];
            }
        }
    }
}
