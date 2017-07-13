using HoloToolkit.Unity.InputModule;
using Pear.InteractionEngine.Properties;
using UnityEngine.VR.WSA.Input;
using UnityEngine;
using Pear.InteractionEngine.Controllers;

namespace Pear.InteractionEngine.Events
{
    /// <summary>
    /// Selects an interactable object on tap
    /// </summary>
    public class Tap : ControllerBehavior<HoloLensController>, IEvent<GameObject>
    {
        // Used to recognize tap
        GestureRecognizer _recognizer;

		public Property<GameObject> Event { get; set; }

        private void Start()
        {
            _recognizer = new GestureRecognizer();
            _recognizer.TappedEvent += (source, tapCount, headRay) => Event.Value = GazeManager.Instance.HitObject;           

            _recognizer.StartCapturingGestures();
        }
    }
}