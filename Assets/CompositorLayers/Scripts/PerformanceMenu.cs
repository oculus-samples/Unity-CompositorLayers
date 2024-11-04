// Copyright (c) Meta Platforms, Inc. and affiliates.

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CompositorLayers
{
    public class PerformanceMenu : MonoBehaviour
    {
        public Slider NumCompositorLayersSlider;
        public Slider MaxTextureSizeSlider;
        public Transform CompositorLayersParent;
        public GameObject CompositorLayerPrefab;
        public BoxCollider CompositorLayerSpawnLoc;
        private int m_randomSeed;

        private void Start()
        {
            OnLayerCountChanged();
            m_randomSeed = (int)System.DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public void OnLayerCountChanged()
        {
            //create new objects as needed...
            for (var i = CompositorLayersParent.childCount; i < NumCompositorLayersSlider.value; ++i)
            {
                //always use the same random seed, so we can compare directly across instantiations
                Random.InitState(m_randomSeed * i);

                var newObject = Instantiate(CompositorLayerPrefab, CompositorLayersParent);
                newObject.transform.position = new Vector3(
                    Random.Range(CompositorLayerSpawnLoc.bounds.min.x, CompositorLayerSpawnLoc.bounds.max.x),
                    Random.Range(CompositorLayerSpawnLoc.bounds.min.y, CompositorLayerSpawnLoc.bounds.max.y),
                    Random.Range(CompositorLayerSpawnLoc.bounds.min.z, CompositorLayerSpawnLoc.bounds.max.z));

                UpdateSettings(newObject.GetComponent<OVROverlayCanvas>());
            }
            //delete existing objects as needed
            for (var i = CompositorLayersParent.childCount; i > NumCompositorLayersSlider.value; --i)
            {
                Destroy(CompositorLayersParent.GetChild(i - 1).gameObject);
            }
        }

        public void DestroyAndRecreateLayers()
        {
            for (var i = CompositorLayersParent.childCount; i > 0; --i)
                Destroy(CompositorLayersParent.GetChild(i - 1).gameObject);
            _ = StartCoroutine(WaitAndRecreateLayers());
        }

        private IEnumerator WaitAndRecreateLayers()
        {
            yield return new WaitForEndOfFrame();
            OnLayerCountChanged();
        }

        private void UpdateSettings(OVROverlayCanvas canvas)
        {
            canvas.maxTextureSize = (int)MaxTextureSizeSlider.value;
        }
    }
}
