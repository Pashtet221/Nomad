using UnityEngine;
using UnityEngine.UI;

public class SceneControlButton : MonoBehaviour
{
	enum TargetScene
	{
		Next,
		Previous,
		MainMenu,
		Levels,
		Records,
		Shop,
		ExitApplication,
		TermsOfUs
	}

	[SerializeField] TargetScene targetScene;
	Button button;

	void Start ()
	{
		button = GetComponent<Button> ();

		button.onClick.RemoveAllListeners ();
		switch (targetScene) {
			case TargetScene.MainMenu:
				button.onClick.AddListener (() => SceneController.LoadMainScene ());
				break;

			case TargetScene.Next:
				button.onClick.AddListener (() => SceneController.LoadNextScene ());
				break;

			case TargetScene.Previous:
				button.onClick.AddListener (() => SceneController.LoadPreviousScene ());
				break;


			case TargetScene.Levels:
				button.onClick.AddListener (() => SceneController.LoadAnyScene("Levels"));
				break;
			case TargetScene.Records:
				button.onClick.AddListener (() => SceneController.LoadAnyScene("LeaderBoard"));
				break;
			case TargetScene.Shop:
				button.onClick.AddListener (() => SceneController.LoadAnyScene("Shop"));
				break;
			case TargetScene.TermsOfUs:
				button.onClick.AddListener (() => SceneController.LoadAnyScene("TermsOfUs"));
				break;
			case TargetScene.ExitApplication:
				button.onClick.AddListener (() => SceneController.Exit());
				break;
		}
	
	}
}