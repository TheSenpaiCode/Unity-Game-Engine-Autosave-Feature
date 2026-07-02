using UnityEditor;

namespace AutoSave.Editor
{
    public static class AutoSaveSettings
    {
        public static bool Enabled
        {
            get => EditorPrefs.GetBool("AS_Enabled", true);
            set => EditorPrefs.SetBool("AS_Enabled", value);
        }

        public static bool SaveBeforePlay
        {
            get => EditorPrefs.GetBool("AS_SaveBeforePlay", true);
            set => EditorPrefs.SetBool("AS_SaveBeforePlay", value);
        }

        public static bool ShowNotifications
        {
            get => EditorPrefs.GetBool("AS_ShowNotification", true);
            set => EditorPrefs.SetBool("AS_ShowNotification", value);
        }
    }
}