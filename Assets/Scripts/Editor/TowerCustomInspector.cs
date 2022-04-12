
using Stayhome.Config;
using UnityEditor;

namespace Stayhome.Editor
{
    [CustomEditor(typeof(Tower))]
    [CanEditMultipleObjects]
    public class TowerCustomInspector : UnityEditor.Editor
    {
        private SerializedProperty levelTowerIconProperty;
        private SerializedProperty typeProperty;
        private TowerType selectedType;
        private SerializedProperty selectedTypeProperty;

        void OnEnable()
        {
            typeProperty = serializedObject.FindProperty(nameof(Tower.data))
                .FindPropertyRelative(nameof(Tower.Data.type));
            levelTowerIconProperty = serializedObject.FindProperty(nameof(Tower.levelTowerIcon));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(levelTowerIconProperty);
            EditorGUILayout.PropertyField(typeProperty);

            TowerType type = (TowerType)typeProperty.intValue;

            if (type != selectedType)
            {
                selectedTypeProperty = serializedObject
                    .FindProperty(nameof(Tower.data))
                    .FindPropertyRelative(TypeToPropertyName(type));
                selectedType = type;
            }

            if (selectedTypeProperty != null)
            {
                EditorGUILayout.PropertyField(selectedTypeProperty);
            }

            serializedObject.ApplyModifiedProperties();
        }

        private static string TypeToPropertyName(TowerType type)
        {
            string propertyName = type.ToString();

            return propertyName.Substring(0, 1).ToLower() + propertyName.Substring(1);
        }
    }
}
