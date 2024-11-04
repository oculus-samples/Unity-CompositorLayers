// Copyright (c) Meta Platforms, Inc. and affiliates.

using UnityEngine;

namespace CompositorLayers
{
    public class SiblingDeactivator : MonoBehaviour
    {
        public void OnToggle(bool toggle)
        {
            if (toggle) Perform();
        }

        public void Perform()
        {
            for (var i = 0; i < transform.parent.childCount; ++i)
            {
                var siblingTransform = transform.parent.GetChild(i);
                siblingTransform.gameObject.SetActive(transform == siblingTransform);
            }
        }
    }
}
