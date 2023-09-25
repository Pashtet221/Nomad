using UnityEngine;
using TMPro;

public class GameSharedUI : MonoBehaviour
{
	#region Singleton class: GameSharedUI

	public static GameSharedUI Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
		}
	}

	#endregion

	[SerializeField] TMP_Text[] scoreUIText;
	[SerializeField] TMP_Text floorUIText;

	void Start ()
	{
		UpdateScoreUIText ();
	}

	public void UpdateScoreUIText ()
	{
		for(int i = 0; i < scoreUIText.Length; i++)
		{
			SetScoreText (scoreUIText[i], ScoreManager.Instance.GetCurrentScore());
		}
		
		SetFloorText (floorUIText, ScoreManager.Instance.GetFloor());
	}

	void SetScoreText (TMP_Text textMesh, int value)
	{
		textMesh.text = value.ToString ();
	}

	void SetFloorText (TMP_Text textMesh, int value)
	{
		textMesh.text = value.ToString ();
	}
}