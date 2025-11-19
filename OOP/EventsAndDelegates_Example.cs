using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp
{
	// Events are a way for a class to notify other classes or objects when something happens. 
	// They follow the publisher-subscriber model, where:

	//    The publisher class defines an event.
	//    The subscribers (other classes or objects) handle that event by defining methods that should be executed when the event is triggered.



	// Event with a Custom Class 
	public class Alarm
	{
		public delegate void AlarmEventHandler(string name);
		public event AlarmEventHandler? AlarmTrigger;

		public void TriggerAlarm(string time)
		{
			Console.WriteLine("Alarm is ringing!");
			AlarmTrigger?.Invoke(time);
		}
	}

	public static class EventsAndDelegates_Example
	{
		// Defining and Using Events in C#
		// Declare a delegate type
		public delegate void NotifyEventHandler(string message);
		// Declare an event based on the delegate
		public static event NotifyEventHandler? NotifyEvent;			

  	static void DisplayMessage(string message) 
											=> Console.WriteLine($"Event Received: {message}");		

		public static void Events()
		{
			Console.WriteLine("----- Defining and Using Events in C# -----");			
			// Suscribe to the event
			NotifyEvent += DisplayMessage;

			// Trigger the event
			NotifyEvent?.Invoke("Hello Adonis Prometeo Eris Atenea");


			Console.WriteLine("----- Event with a Custom Class -----");
			Alarm myAlarm = new();

			// Subscribe to the event
			myAlarm.AlarmTrigger += DisplayMessage;

			// Trigger the alams event;
			myAlarm.TriggerAlarm("07:00 AM");
		}
	}
}

	// Why Use Events?
	// Decoupling: The event publisher doesn't need to know what happens when the event occurs.
	// Flexibility: Multiple subscribers can handle the event in different ways.
	// Extensibility: Other components can subscribe to the event without modifying existing code.