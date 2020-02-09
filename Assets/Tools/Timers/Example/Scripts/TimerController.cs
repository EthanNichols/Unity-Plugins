using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// DEMO CLASS
/// UI controller for timers.
/// </summary>
public class TimerController : MonoBehaviour
{
		/// <summary>
		/// Start button that starts a timer
		/// </summary>
		public Button startButton;
		/// <summary>
		/// Reset button that resets a timer's time
		/// </summary>
		public Button resetButton;
		/// <summary>
		/// Pause button that pauses a timer
		/// </summary>
		public Button pauseButton;
		/// <summary>
		/// Stop button that stops a timer
		/// </summary>
		public Button stopButton;
		/// <summary>
		/// Create <see cref="TimerSplit"/> button for the <see cref="Stopwatch"/>
		/// This doesn't need to be set for any other timer type controller
		/// </summary>
		public Button splitButton;

		/// <summary>
		/// Text that displays the current time of the timer
		/// </summary>
		public TextMeshProUGUI timerDisplay;
		/// <summary>
		/// Test that displays the last split that was created by the <see cref="Stopwatch"/>
		/// This doesn't need to be set for any other timer type controller
		/// </summary>
		public TextMeshProUGUI splitInformation;
		/// <summary>
		/// Reference to the timer object
		/// </summary>
		private Timer timer = null;

		/// <summary>
		/// Reference to the stopwatch timer, since the <see cref="splitButton"/>
		/// needs to reference a unique function to the <see cref="Stopwatch"/>
		/// </summary>
		private Stopwatch stopwatchTimer;
		/// <summary>
		/// Reference to the last split that was created by the <see cref="stopwatchTimer"/>
		/// </summary>
		private TimerSplit lastSplit;


		/// <summary>
		/// Set the timer that this timerController controlls
		/// </summary>
		public void SetTimer(Timer timer)
		{
				this.timer = timer;

				startButton.onClick.AddListener(timer.Start);
				resetButton.onClick.AddListener(timer.Reset);
				pauseButton.onClick.AddListener(timer.Pause);
				stopButton.onClick.AddListener(timer.Stop);

				if (splitButton != null)
				{
						stopwatchTimer = (Stopwatch)timer;
						splitButton.onClick.AddListener(CreateSplit);
				}
		}


		/// <summary>
		/// Create a split (specific to the <see cref="Stopwatch"/> timer
		/// </summary>
		private void CreateSplit()
		{
				TimerSplit? newSplit = stopwatchTimer.CreateSplit();

				if (newSplit.HasValue && splitInformation != null)
				{
						lastSplit = newSplit.Value;
						splitInformation.text = "";

						splitInformation.text += "Split Time: " + lastSplit.splitTime.val.ToString(@"dd\.hh\:mm\:ss\.ffff") + "\n";
						splitInformation.text += "Split Start: " + lastSplit.splitStart.val.ToString(@"dd\.hh\:mm\:ss\.ffff") + "\n";
						splitInformation.text += "Split Finish: " + lastSplit.splitFinish.val.ToString(@"dd\.hh\:mm\:ss\.ffff") + "\n";
				}
		}


		/// <summary>
		/// Called from the timer update events
		/// Updates that time that is being displayed on the UI text
		/// </summary>
		public void UpdateDisplay()
		{
				timerDisplay.text = timer.CurrentTime.ToString(@"dd\.hh\:mm\:ss\.ffff");
		}
}
