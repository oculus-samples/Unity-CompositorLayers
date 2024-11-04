// Copyright (c) Meta Platforms, Inc. and affiliates.

using UnityEngine;

namespace CompositorLayers
{
    [RequireComponent(typeof(OVROverlayMeshGenerator))]
    public class SetMeshGeneratorOverlayToParent : MonoBehaviour
    {
        private void Start()
        {
            var overlay = GetComponentInParent<OVROverlay>();
            GetComponent<OVROverlayMeshGenerator>().SetOverlay(overlay);
        }
    }
}
