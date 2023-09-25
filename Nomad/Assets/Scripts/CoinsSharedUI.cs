using UnityEngine;
using TMPro;

public class CoinsSharedUI : MonoBehaviour
{
    public static CoinsSharedUI Instance;

    [SerializeField] TMP_Text coinsUIText;


	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
		}
	}

    void Start ()
	{
		UpdateCoinsUIText ();
	}

	public void UpdateCoinsUIText ()
	{
		SetCoinsText(coinsUIText, GameData.Coins);
	}

	void SetCoinsText (TMP_Text textMesh, int value)
	{
		textMesh.text = value.ToString ();
	}
}
