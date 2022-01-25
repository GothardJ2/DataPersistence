using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIController : MonoBehaviour {

	string playerName;
	
	public void SetPlayerName(string value) 
	{
		playerName = value;
		//Debug.Log ("playerName variable now holds: "+playerName);
	}

	public void StartNew()
    {
		UserNameEntered();
		SceneManager.LoadScene(1);
    }

	public void UserNameEntered()
	{
		GameManger.instance.userName = playerName;
	}

	public void ExitApp()
    {
		
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

		
	}

}
