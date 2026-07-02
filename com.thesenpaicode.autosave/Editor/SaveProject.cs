namespace AutoSave.Editor
{
    using UnityEditor;
    using UnityEditor.SceneManagement;
    using UnityEngine;

    [InitializeOnLoad]
    public static class SaveProject
    {
        private static bool pendingNotification = false;

        static SaveProject()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            switch (state)
            {
                case PlayModeStateChange.ExitingEditMode:
                    Save();
                    break;

                case PlayModeStateChange.EnteredPlayMode:
                    EditorApplication.delayCall += ShowNotification;
                    break;
            }
        }

        private static void Save()
        {
            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();

            pendingNotification = true;
        }

        private static void ShowNotification()
        {
            if (!pendingNotification)
                return;

            pendingNotification = false;

            if (SceneView.lastActiveSceneView != null)
            {
                SceneView.lastActiveSceneView.ShowNotification(
                    new GUIContent("Project Auto Saved"));
            }
        }
    }
}