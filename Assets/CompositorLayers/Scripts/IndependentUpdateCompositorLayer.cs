// Copyright (c) Meta Platforms, Inc. and affiliates.

using System.Collections;
using UnityEngine;

// This code is based off of https://developer.oculus.com/blog/tech-note-animated-loading-screen/

namespace CompositorLayers
{
    public class IndependentUpdateCompositorLayer : MonoBehaviour
    {
        private OVROverlay m_assocOverlay;

        private void Awake()
        {
            m_assocOverlay = GetComponent<OVROverlay>();

            Debug.Assert(m_assocOverlay
                && m_assocOverlay.isExternalSurface
                && m_assocOverlay.externalSurfaceHeight > 0
                && m_assocOverlay.externalSurfaceHeight > 0);
        }

        private IEnumerator Start()
        {
            var i = 0;
            while (m_assocOverlay.externalSurfaceObject == System.IntPtr.Zero)
            {
                Debug.Log("Frame " + i);
                yield return null;
            }

            var loadingScreenClassJNI = AndroidJNI.FindClass("com/UnityCompositorLayers/LoadingScreen");
            var startUpdatingLoadingScreenMethodID = AndroidJNI.GetStaticMethodID(loadingScreenClassJNI, "startUpdatingLoadingScreen", "(Landroid/view/Surface;II)V");
            Debug.Log("Creating overlay for " + m_assocOverlay.externalSurfaceObject + " (" + m_assocOverlay.externalSurfaceWidth + "x" + m_assocOverlay.externalSurfaceHeight + ")");
            AndroidJNI.CallStaticVoidMethod(loadingScreenClassJNI, startUpdatingLoadingScreenMethodID,
            new jvalue[] {
            new() { l = m_assocOverlay.externalSurfaceObject },
            new() { i = m_assocOverlay.externalSurfaceWidth },
            new() { i = m_assocOverlay.externalSurfaceHeight }
            });
            AndroidJNI.DeleteLocalRef(loadingScreenClassJNI);
        }

        private void OnDisable()
        {
            var loadingScreenClassJNI = AndroidJNI.FindClass("com/UnityCompositorLayers/LoadingScreen");
            var stopUpdatingLoadingScreenMethodID = AndroidJNI.GetStaticMethodID(loadingScreenClassJNI, "stopUpdatingLoadingScreen", "()V");
            AndroidJNI.CallStaticVoidMethod(loadingScreenClassJNI, stopUpdatingLoadingScreenMethodID, new jvalue[0]);
            AndroidJNI.DeleteLocalRef(loadingScreenClassJNI);
        }
    }
}
