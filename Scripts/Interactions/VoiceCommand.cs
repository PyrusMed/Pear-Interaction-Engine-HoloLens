using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pear.InteractionEngine.Interactions
{
	/// <summary>
	/// Maps a voice command to an event function
	/// </summary>
	public class VoiceCommand : MonoBehaviour
	{
		[Tooltip("Command that fires voice event")]
		public string Command;

		[Tooltip("Event(s) fired when voice command called")]
		public UnityEvent Events;

		private void Start()
		{
			// When the user says the command execute the action(s)
			VoiceCommandManager.Instance.ListenForCommand(Command, (ka) => Events.Invoke());
		}
	}
}
