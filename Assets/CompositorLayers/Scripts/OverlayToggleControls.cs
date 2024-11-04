// Copyright (c) Meta Platforms, Inc. and affiliates.

using UnityEngine;

namespace CompositorLayers
{
    [RequireComponent(typeof(OVROverlay))]
    public class OverlayToggleControls : MonoBehaviour
    {
        private OVROverlay m_assocOverlay;

        private void Awake()
        {
            m_assocOverlay = GetComponent<OVROverlay>();
        }

        public void SetBicubicFiltering(bool val)
        {
            m_assocOverlay.useBicubicFiltering = val;
        }

        public void SetSharpen(bool val)
        {
            m_assocOverlay.useEfficientSharpen = val;
        }

        public void SetSupersample(bool val)
        {
            m_assocOverlay.useEfficientSupersample = val;
        }
    }
}
