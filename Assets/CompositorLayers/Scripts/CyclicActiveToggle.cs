// Copyright (c) Meta Platforms, Inc. and affiliates.

using UnityEngine;

// For the given list of GameObjects, will cycle through the list toggling each GameObject active,
// setting all others inactive. Loops back to index 0 when finished.

namespace CompositorLayers
{
    public class CyclicActiveToggle : MonoBehaviour
    {
        public float TimePerActiveState;
        public GameObject[] ToToggle;

        private void Start()
        {
            Update();
        }

        private void Update()
        {
            var currentIndex = (int)(Time.time / TimePerActiveState) % ToToggle.Length;
            for (var i = 0; i < ToToggle.Length; ++i)
                ToToggle[i].SetActive(i == currentIndex);
        }
    }
}
