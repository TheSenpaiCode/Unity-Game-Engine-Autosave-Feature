namespace AutoSave.Editor
{
    using UnityEditor;
    using UnityEditor.SceneManagement;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    [InitializeOnLoad]
    public static class AutoSaveBeforePlay
    {
        static AutoSaveBeforePlay()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (!AutoSaveSettings.Enabled)
                return;

            if (state == PlayModeStateChange.ExitingEditMode)
            {
                SaveProject();
            }
        }

        private static void SaveProject()
        {
            bool hasDirtyScenes = false;

            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);

                if (scene.isDirty)
                {
                    hasDirtyScenes = true;
                    break;
                }
            }

            if (hasDirtyScenes)
            {
                EditorSceneManager.SaveOpenScenes();
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            if (SceneView.lastActiveSceneView != null)
            {
                SceneView.lastActiveSceneView.ShowNotification(
                    new GUIContent("Project Auto Saved"));
            }
        }
    }
}