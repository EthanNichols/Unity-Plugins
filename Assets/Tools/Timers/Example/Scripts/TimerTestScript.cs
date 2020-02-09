using UnityEngine;

public class TimerTestScript : MonoBehaviour
{
		/// <summary>
		/// Simple timer
		/// </summary>
		public Timer timer;
		/// <summary>
		/// Countdown timer
		/// </summary>
		public CountdownTimer countdownTimer;
		/// <summary>
		/// Stopwatch timer
		/// </summary>
		public Stopwatch stopwatch;

		/// <summary>
		/// Simple timer controller
		/// </summary>
		public TimerController normalTimerController;
		/// <summary>
		/// Countdown timer controller
		/// </summary>
		public TimerController countdownTimerController;
		/// <summary>
		/// Stopwatch timer controller
		/// </summary>
		public TimerController stopwatchController;


		void Start()
    {
				// Set the timer that each TimerController controlls
				normalTimerController.SetTimer(timer);
				countdownTimerController.SetTimer(countdownTimer);
				stopwatchController.SetTimer(stopwatch);

				// Add the timer update event to update the display of the timer
				timer.timerUpdateEvent += normalTimerController.UpdateDisplay;
				countdownTimer.timerUpdateEvent += countdownTimerController.UpdateDisplay;
				stopwatch.timerUpdateEvent += stopwatchController.UpdateDisplay;

				// Set the starting time for the displays
				normalTimerController.UpdateDisplay();
				countdownTimerController.UpdateDisplay();
				stopwatchController.UpdateDisplay();

				// Add the reset function to the timer finish event
				countdownTimer.timerFinishedEvent += ResetCountdownTimer;

				// Initialize each timer so they are started by default
				timer.Init();
				countdownTimer.Init();
				stopwatch.Init();
    }


		/// <summary>
		/// Reset and start the countdown timer when it finishes
		/// </summary>
		private void ResetCountdownTimer()
		{
				countdownTimer.Reset();
				countdownTimer.Start();
		}
}
