using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
	public string targetNextSceneName;
	public void OnClickChangeScene()
{
	SceneManager.LoadScene(targetNextSceneName); 
	}
}
