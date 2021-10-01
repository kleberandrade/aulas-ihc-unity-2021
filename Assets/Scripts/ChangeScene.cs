using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        ScreenManager.Instance.LoadLevel(sceneName);
    }

    public void LoadSceneWithLoading(string sceneName)
    {
        ScreenManager.Instance.LoadLevelLoading(sceneName);
    }

    public void Quit()
    {
        ScreenManager.Instance.LoadLevel("Quit");
    }
}
