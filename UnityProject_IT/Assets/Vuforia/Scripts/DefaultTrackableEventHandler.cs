/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        public GUIStyle myStyle;

        private TrackableBehaviour mTrackableBehaviour;
        private bool mShowGUIText = true;
        

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                mShowGUIText = false;
                OnTrackingFound();
            }
            else
            {
                mShowGUIText = true;
                OnTrackingLost();
             }
        }

        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            foreach (Renderer comp in rendererComponents)
            {
                comp.enabled = true;
            }

            foreach (Collider comp in colliderComponents)
            {
                comp.enabled = true;
            }
        }

        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            foreach (Renderer comp in rendererComponents)
            {
                comp.enabled = false;
            }

            foreach (Collider comp in colliderComponents)
            {
                comp.enabled = false;
            }
            GUI.TextArea(new Rect(0, 0, 600, 60), "Please put mobile camera on a marker", myStyle);
        }

        void OnGUI()
        {
            if (mShowGUIText)
            {
                // draw the GUI button
                GUI.TextArea(new Rect(0, 0, 600, 60), "Please put mobile camera on a marker", myStyle);
            }
        }
    }
}
