using Pear.InteractionEngine.Properties;
using UnityEngine;
using UnityEngine.VR.WSA.Input;
using System.Collections.Generic;
using System.Linq;
using Pear.InteractionEngine.Controllers;
using Pear.InteractionEngine.Events;
using System;

namespace Pear.InteractionEngine.Interactions.Events
{
    /// <summary>
    /// Essentially we create and anaolog joystick when the user pinches, and dragging moves the joystick's analog value
    /// </summary>
    public class PinchAndDrag : ControllerBehavior<HoloLensController>, IEvent<Vector3>
    {
        // Used to listen for navigation gestures
        public GestureRecognizer NavigationRecognizer
        {
            get;
            private set;
        }

		public Property<Vector3> Event { get; set; }

        void Awake()
        {
            // Start listening for navigation events
            NavigationRecognizer = new GestureRecognizer();
            NavigationRecognizer.SetRecognizableGestures(
                    GestureSettings.NavigationX |
                    GestureSettings.NavigationY |
                    GestureSettings.NavigationZ
            );
            NavigationRecognizer.NavigationUpdatedEvent += OnNavigationUpdated;
            NavigationRecognizer.NavigationCanceledEvent += OnNavigationEnded;
            NavigationRecognizer.NavigationCompletedEvent += OnNavigationEnded;

            NavigationRecognizer.StartCapturingGestures();
        }

		/// <summary>
		/// Start listening for input when this control is enabled
		/// </summary>
		private void OnEnable()
		{
			NavigationRecognizer.StartCapturingGestures();
		}

		/// <summary>
		/// Stop listening for input when this control is disabled
		/// </summary>
		private void OnDisable()
		{
			NavigationRecognizer.StopCapturingGestures();
		}

		/// <summary>
		/// Update each property when the navigation event is updated
		/// </summary>
		/// <param name="source">Hand source</param>
		/// <param name="relativePosition">Position relative to when navigation started</param>
		/// <param name="ray"></param>
		private void OnNavigationUpdated(InteractionSourceKind source, Vector3 relativePosition, Ray ray)
        {
			// If the controller has an active object update its properties
			Event.Value = relativePosition;
        }

        /// <summary>
        /// Set all values to zero when navigation completes
        /// </summary>
        /// <param name="source"></param>
        /// <param name="relativePosition"></param>
        /// <param name="ray"></param>
        private void OnNavigationEnded(InteractionSourceKind source, Vector3 relativePosition, Ray ray)
        {
			Event.Value = Vector3.zero;
        }
    }
}