using UnityEngine.SceneManagement;

namespace MergeBlock
{
    public enum Scenes
    {
        StartUp,
        GamePlay,
    }
    public class SceneFlowManager : Singleton<SceneFlowManager>
    {
        public void LoadScene(Scenes sceneType, bool showLoadingScene = false)
        {
            SceneManager.LoadScene(sceneType.ToString());
        }
    }
}
