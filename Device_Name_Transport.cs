using Crestron.RAD.Common.Transports;

namespace Home_Extension_Template
{
	public class Device_Name_Transport : ATransportDriver
	{
		#region Declarations
		public Device_Name Device;
		#endregion Declarations

		//****************************************************************************************
		// 
		//  Device_Name_Transport	-	Constructor
		// 
		//****************************************************************************************
		public Device_Name_Transport(Device_Name Device)
		{
			#region Debug Message
			Log("Device_Name_Transport - Constructor - Start");
			#endregion Debug Message

			IsEthernetTransport = true;
			IsConnected = true;
			this.Device = Device;

			#region Debug Message
			Log("Device_Name_Transport - Constructor - Finish");
			#endregion Debug Message
		}

		#region Overrides
		//****************************************************************************************
		// 
		//  Start	-	
		// 
		//****************************************************************************************
		public override void Start()
		{
			#region Debug Message
			Log("Device_Name_Transport - Start - Start");
			#endregion Debug Message

			#region Debug Message
			Log("Device_Name_Transport - Start - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  Stop	-	
		// 
		//****************************************************************************************
		public override void Stop()
		{
			#region Debug Message
			Log("Device_Name_Transport - Stop - Start");
			#endregion Debug Message

			#region Debug Message
			Log("Device_Name_Transport - Stop - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  SendMethod	-	
		// 
		//****************************************************************************************
		public override void SendMethod(string message, object[] parameters)
		{
			#region Debug Message
			Log("Device_Name_Transport - SendMethod - Start");
			#endregion Debug Message

			#region Debug Message
			Log("Device_Name_Transport - SendMethod - Finish");
			#endregion Debug Message
		}
		#endregion Overrides
	}
}