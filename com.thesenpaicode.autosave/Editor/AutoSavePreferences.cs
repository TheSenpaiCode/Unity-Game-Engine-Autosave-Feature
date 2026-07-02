using UnityEditor;
using UnityEngine;

namespace AutoSave.Editor
{
    public class AutoSavePreferences : SettingsProvider
    {
        public AutoSavePreferences(string path, SettingsScope scope)
            : base(path, scope) { }

        [SettingsProvider]
        public static SettingsProvider CreateProvider()
        {
            return new AutoSavePreferences(
                "Preferences/Auto Save",
                SettingsScope.User);
        }

        public override void OnGUI(string searchContext)
        {
            GUILayout.Label("Auto Save", EditorStyles.boldLabel);

            AutoSaveSettings.Enabled =
                EditorGUILayout.Toggle(
                    "Enable Auto Save",
                    AutoSaveSettings.Enabled);

            AutoSaveSettings.SaveBeforePlay =
                EditorGUILayout.Toggle(
                    "Save Before Play",
                    AutoSaveSettings.SaveBeforePlay);

            AutoSaveSettings.ShowNotifications =
                EditorGUILayout.Toggle(
                    "Show Notifications",
                    AutoSaveSettings.ShowNotifications);

            GUILayout.Space(10);
        }
    }
}