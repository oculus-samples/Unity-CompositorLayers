// Copyright (c) Meta Platforms, Inc. and affiliates.

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace CompositorLayers
{
    public class IndependentUpdateMenu : MonoBehaviour
    {
        public Slider RenderScaleSlider;
        public Toggle DoExpensiveWorkToggle;
        private int m_expensiveWorkCounter = 0;

        private void Update()
        {
            UnityEngine.XR.XRSettings.eyeTextureResolutionScale = RenderScaleSlider.value;
            (GraphicsSettings.currentRenderPipeline as UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset).renderScale = RenderScaleSlider.value;

            if (DoExpensiveWorkToggle.isOn)
            {
                m_expensiveWorkCounter = 0;
                for (var i = 0; i < 90000000; ++i)
                    if (i % 2 == 0)
                        m_expensiveWorkCounter += i;
                    else
                        m_expensiveWorkCounter -= i;
            }
        }

        private void OnDisable()
        {
            UnityEngine.XR.XRSettings.eyeTextureResolutionScale = 1f;
            (GraphicsSettings.currentRenderPipeline as UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset).renderScale = 1f;
        }
    }
}
