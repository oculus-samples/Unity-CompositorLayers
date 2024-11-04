// Copyright (c) Meta Platforms, Inc. and affiliates.

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CompositorLayers
{
    public class SettingsMenu : MonoBehaviour
    {
        public Button SceneButtonPrefab;
        public RectTransform SceneButtonsParent;

        public GameObject CanvasMeshObject;
        private GameObject m_canvasObject;

        private void Awake()
        {
            m_canvasObject = GetComponentInChildren<Canvas>().gameObject;
            SetIsDisplaying(false);
        }

        private void Start()
        {
            for (var i = SceneButtonsParent.childCount - 1; i >= 0; i--)
            {
                Destroy(SceneButtonsParent.GetChild(i).gameObject);
            }

            for (var i = 0; i < SceneManager.sceneCountInBuildSettings; ++i)
            {
                var button = Instantiate(SceneButtonPrefab, SceneButtonsParent);
                var scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                var sceneName = scenePath[(scenePath.LastIndexOf('/') + 1)..];
                sceneName = sceneName[..sceneName.IndexOf(".")];
                button.GetComponentInChildren<TMPro.TMP_Text>().text = sceneName;
                button.onClick.AddListener(delegate { SceneManager.LoadScene(scenePath); });
            }
        }

        private void Update()
        {
            if (OVRInput.GetDown(OVRInput.RawButton.Start))
                SetIsDisplaying(!GetIsDisplaying());
        }

        public bool GetIsDisplaying()
        {
            return m_canvasObject.activeSelf;
        }

        public void SetIsDisplaying(bool val)
        {
            m_canvasObject.SetActive(val);
            CanvasMeshObject.SetActive(val);

        }
    }
}
