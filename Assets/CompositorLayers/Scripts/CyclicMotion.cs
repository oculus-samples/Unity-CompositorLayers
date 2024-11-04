// Copyright (c) Meta Platforms, Inc. and affiliates.

using UnityEngine;

namespace CompositorLayers
{
    public class CyclicMotion : MonoBehaviour
    {
        public Vector3 TranslationDirection;
        [Tooltip("X-axis is time (seconds). Y-axis is distance along TranslationDirection (meters).")]
        public AnimationCurve TranslationCurve;

        public Vector3 RotationAxis;
        [Tooltip("Measured in degrees per second")]
        public float RotationSpeed;

        private Vector3 m_startingTranslation;

        private void Awake()
        {
            m_startingTranslation = transform.position;
        }

        private void Update()
        {
            transform.position = m_startingTranslation + TranslationDirection * TranslationCurve.Evaluate(Time.time);
            transform.rotation = transform.rotation * Quaternion.AngleAxis(Time.deltaTime, RotationAxis);
        }
    }
}
