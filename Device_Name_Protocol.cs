using System;
using Crestron.RAD.Common.BasicDriver;

namespace Home_Extension_Template
{
	public class Device_Name_Protocol : ABaseDriverProtocol, IDisposable
	{
		#region Declarations
		private readonly Device_Name Device;
		public Device_Name.UI_Update_Delegate UI_Update;
		#endregion Declarations

		//****************************************************************************************
		// 
		//  Device_Name_Protocol	-	Constructor
		// 
		//****************************************************************************************
		public Device_Name_Protocol(Device_Name_Transport transport, byte id) : base(transport, id)
		{
			#region Debug Message
			Log("Device_Name_Protocol - Constructor - Start");
			#endregion Debug Message

			Transport = transport;
			Device = transport.Device;

			#region Debug Message
			Log("Device_Name_Protocol - Constructor - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  Start	-	
		// 
		//****************************************************************************************
		public void Start()
		{
			#region Debug Message
			Log("Device_Name_Protocol - Start - Start");
			#endregion Debug Message

			PollingInterval = 60000;//60 seconds in ms
			EnableAutoPolling = true;

			#region Debug Message
			Log("Device_Name_Protocol - Start - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  Stop	-	
		// 
		//****************************************************************************************
		public void Stop()
		{
			#region Debug Message
			Log("Device_Name_Protocol - Stop - Start");
			#endregion Debug Message

			EnableAutoPolling = false;

			#region Debug Message
			Log("Device_Name_Protocol - Stop - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  Poll	-	Built in Polling Routing
		// 
		//****************************************************************************************
		protected override void Poll()
		{
			#region Debug Message
			Log("Device_Name_Protocol - Poll - Start");
			#endregion Debug Message

			//TODO Do the work to get data from your device/cloud service

			#region Test Code
			// Increment the counter so there is something to watch in the UI
			// When the counter gets to 10 trigger an event
			Device.Counter++;
			if (Device.Counter >= 11)
			{ 
				Device.Counter = 1;
			}
			else if (Device.Counter == 10)
			{
				Device.Trigger_Event();
			}

			#region Debug Message
			Log("Device_Name_Protocol - Poll Counter = " + Device.Counter.ToString());
			#endregion Debug Message
			#endregion Test Code

			//Update your UI with the information
			UI_Update();

			#region Debug Message
			Log("Device_Name_Protocol - Poll - Finish");
			#endregion Debug Message
		}

		#region Overrides
		//****************************************************************************************
		// 
		//  ConnectionChangedEvent	-	
		// 
		//****************************************************************************************
		protected override void ConnectionChangedEvent(bool connection)
		{
			#region Debug Message
			Log("Device_Name_Protocol - ConnectionChangedEvent - Start");
			#endregion Debug Message

			#region Debug Message
			Log("Device_Name_Protocol - ConnectionChangedEvent - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  ChooseDeconstructMethod	-	
		// 
		//****************************************************************************************
		protected override void ChooseDeconstructMethod(ValidatedRxData validatedData)
		{
			#region Debug Message
			Log("Device_Name_Protocol - ChooseDeconstructMethod - Start");
			#endregion Debug Message

			#region Debug Message
			Log("Device_Name_Protocol - ChooseDeconstructMethod - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  SetUserAttribute	-	
		// 
		//****************************************************************************************
		public override void SetUserAttribute(string attributeId, string attributeValue)
		{
			#region Debug Message
			Log("Device_Name_Protocol - SetUserAttribute - Start");
			#endregion Debug Message

			if (string.IsNullOrEmpty(attributeValue))
			{
				Log("Device_Name_Protocol - SetUserAttribute - User attribute value was null or empty");
			}
			else
			{
				switch (attributeId)
				{
					case "DeviceID":
						Device.Device_ID = attributeValue;
						#region Debug Message
						Log("Device_Name_Protocol - SetUserAttribute - Device ID has been set:" + attributeValue);
						#endregion Debug Message
						break;
				}
			}

			#region Debug Message
			Log("Device_Name_Protocol - SetUserAttribute - Finish");
			#endregion Debug Message
		}
		#endregion Overrides

	}
}
