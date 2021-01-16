﻿using Plugins.ParallaxCowProductions.ParallaxScroller.Scripts.Background;
using UnityEditor;
using UnityEngine;

namespace Plugins.ParallaxCowProductions.ParallaxScroller.Scripts.Editor {
    [CustomEditor(typeof(BackgroundManager))]
    public class BackgroundManagerEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            var backgroundManager = (BackgroundManager) target;
            if (GUILayout.Button("Add background layer")) backgroundManager.InstantiateGameObject();
        }
    }
}