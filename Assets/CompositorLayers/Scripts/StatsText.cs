// Copyright (c) Meta Platforms, Inc. and affiliates.

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CompositorLayers
{
    public class StatsText : MonoBehaviour
    {
        [Tooltip("{0} is FPS. {1} is scene name."), Multiline(8)]
        public string TextFormat;
        private TMP_Text m_assocText;
        private float m_aveFrameTime = -1;

        private void Start()
        {
            m_assocText = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            m_aveFrameTime = m_aveFrameTime <= 0 ? Time.unscaledDeltaTime : 0.9f * m_aveFrameTime + 0.1f * Time.unscaledDeltaTime;

            m_assocText.text = string.Format(TextFormat, (1f / m_aveFrameTime).ToString("F1"), SceneManager.GetActiveScene().name);
        }
    }
}
