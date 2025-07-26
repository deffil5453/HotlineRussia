using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadScripts : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Level_Scene");
    }
}
