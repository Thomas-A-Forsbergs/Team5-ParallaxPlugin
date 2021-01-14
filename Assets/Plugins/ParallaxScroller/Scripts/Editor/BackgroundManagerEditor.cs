using UnityEditor;
using UnityEngine;
using Plugins.ParallaxScroller.Scripts.Background;

namespace Plugins.ParallaxScroller.Scripts.Editor {
    [CustomEditor(typeof(BackgroundManager))]
    public class BackgroundManagerEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            var backgroundManager = (BackgroundManager) target;
            if (GUILayout.Button("Add layer")) backgroundManager.InstantiateGameObject();
        }
    }
}