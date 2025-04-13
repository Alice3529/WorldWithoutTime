#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public static class ForceStartFromFirstScene
{
    static ForceStartFromFirstScene()
    {
        EditorApplication.playModeStateChanged += LoadFirstSceneOnPlay;
    }

    private static void LoadFirstSceneOnPlay(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            string firstScenePath = EditorBuildSettings.scenes[0].path;
            if (EditorSceneManager.GetActiveScene().path != firstScenePath)
            {
                // Prompt save changes to the current scene if needed
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    EditorSceneManager.OpenScene(firstScenePath);
                }
                else
                {
                    EditorApplication.isPlaying = false; // Cancel play
                }
            }
        }
    }
}
#endif
