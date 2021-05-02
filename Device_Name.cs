using System;
using Crestron.RAD.Common.Interfaces;
using Crestron.RAD.Common.Interfaces.ExtensionDevice;
using Crestron.RAD.DeviceTypes.ExtensionDevice;
using Crestron.RAD.Common.Attributes.Programming;
using Crestron.RAD.Common.Enums;


namespace Home_Extension_Template
{

	public class Device_Name : AExtensionDevice, ICloudConnected
	{
		#region Declarations
		public Device_Name_Transport Transport;
		public Device_Name_Protocol Protocol;
		public string Device_ID;
		public int Counter = 1;

		//Settings
		public Settings_Data Settings;
		private const string Filename = "Template_Settings_Data";
		#endregion Declarations

		#region Property keys
		private const string Display_Text_Key = "DisplayText";
		private const string Checkbox_Value_Key = "CheckboxValue";
		private const string Text_Entry_Value_Key = "TextEntryValue";
		#endregion Property keys

		#region UI properties
		private PropertyValue<string> Display_Text_Property;
		private PropertyValue<bool> Checkbox_Value_Property;
		private PropertyValue<int> Text_Entry_Value_Property;
		#endregion UI properties

		#region Events
		[ProgrammableEvent]
		public event EventHandler Event_ID;
		#endregion Events

		#region Delegates
		public delegate void UI_Update_Delegate();
		#endregion Delegates

		//****************************************************************************************
		// 
		//  Device_Name	-   Constructor
		// 
		//****************************************************************************************
		public Device_Name()
		{
			#region Debug Message
			Log("Device_Name - Constructor - Start");
			#endregion Debug Message

			#region Debug Message
			Log("Device_Name - Constructor - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  Initialize	-  ICloudConnected Interface
		// 
		//****************************************************************************************
		public void Initialize()
		{
			EnableLogging = true;

			#region Debug Message
			Log("Device_Name - Initialize - Start");
			#endregion Debug Message

			#region Setup Delegates
			UI_Update_Delegate del = new UI_Update_Delegate(Update_UI);
			#endregion Setup Delegates

			#region Setup UI
			Create_Device_Definition();
			#endregion Setup UI

			#region Setup Transport
			try
			{
				Transport = new Device_Name_Transport(this)
				{
					EnableLogging = InternalEnableLogging,
					CustomLogger = InternalCustomLogger,
					EnableRxDebug = InternalEnableRxDebug,
					EnableTxDebug = InternalEnableTxDebug
				};
				ConnectionTransport = Transport;
			}
			catch (Exception e)
			{
				string err = "Device_Name - Initialize - Error Setting Up Transport: " + e;
				#region Debug Message
				Log(err);
				#endregion Debug Message
				Crestron.SimplSharp.ErrorLog.Error(err + "\n");
			}
			#endregion Setup Transport

			#region Setup Protocol
			try
			{
				Protocol = new Device_Name_Protocol(Transport, Id)
				{
					EnableLogging = InternalEnableLogging,
					CustomLogger = InternalCustomLogger,
					UI_Update = del
				};

				DeviceProtocol = Protocol;
				DeviceProtocol.Initialize(DriverData);
			}
			catch (Exception e)
			{
				string err = "Device_Name - Initialize - Error Setting Up Protocol: " + e;
				#region Debug Message
				Log(err);
				#endregion Debug Message
				Crestron.SimplSharp.ErrorLog.Error(err + "\n");
			}
			#endregion Setup Protocol

			#region Debug Message
			Log("Device_Name - Initialize - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  Create_Device_Definition	-   
		// 
		//****************************************************************************************
		private void Create_Device_Definition()
		{
			#region Debug Message
			Log("Device_Name - Create_Device_Definition - Start");
			#endregion Debug Message

			Display_Text_Property = CreateProperty<string>(new PropertyDefinition(Display_Text_Key, null, DevicePropertyType.String));
			Checkbox_Value_Property = CreateProperty<bool>(new PropertyDefinition(Checkbox_Value_Key, null, DevicePropertyType.Boolean));
			Text_Entry_Value_Property = CreateProperty<int>(new PropertyDefinition(Text_Entry_Value_Key, null, DevicePropertyType.Int32));

			#region Debug Message
			Log("Device_Name - Create_Device_Definition - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  Update_UI	-   
		// 
		//****************************************************************************************
		public void Update_UI()
		{
			#region Debug Message
			Log("Device_Name - Update_UI - Start");
			#endregion Debug Message

			Display_Text_Property.Value = Counter.ToString();

			Commit();

			#region Debug Message
			Log("Device_Name - Update_UI - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  Trigger_Event	-   
		// 
		//****************************************************************************************
		public void Trigger_Event()
		{
			#region Debug Message
			Log("Device_Name - Trigger_Event - Start");
			#endregion Debug Message

			var Event = Event_ID;
			Event?.Invoke(this, new EventArgs());

			#region Debug Message
			Log("Device_Name - Trigger_Event - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  Sequence_Triggered_Method	-   
		// 
		//****************************************************************************************
		[ProgrammableOperation("^SequenceTriggeredMethodLabel")]
		public void Sequence_Triggered_Method()
		{
			#region Debug Message
			Log("Device_Name - Sequence_Triggered_Method - Start");
			#endregion Debug Message

			#region Debug Message
			Log("Device_Name - Sequence_Triggered_Method - Finish");
			#endregion Debug Message
		}

		#region Overrides
		//****************************************************************************************
		// 
		//  Dispose	-   
		// 
		//****************************************************************************************
		public override void Dispose()
		{
			#region Debug Message
			Log("Device_Name - Dispose - Start");
			#endregion Debug Message

			base.Dispose();

			#region Debug Message
			Log("Device_Name - Dispose - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  DoCommand	-   
		// 
		//****************************************************************************************
		protected override IOperationResult DoCommand(string command, string[] parameters)
		{
			#region Debug Message
			Log("Device_Name - DoCommand - Start");
			#endregion Debug Message

			switch (command)
			{
				case "ShowSettings":
					//Load Boolean Values
					Checkbox_Value_Property.Value = Settings.Checkbox_Setting;
					//Load String Values
					Text_Entry_Value_Property.Value = Settings.Text_Entry_Setting;
					break;

				case "SaveSettings":
					Settings.Save(Checkbox_Value_Property.Value, Text_Entry_Value_Property.Value);
					//Make Settings Persistant
					SaveSetting(Filename, Settings);
					break;
			}
			
			Commit();

			#region Debug Message
			Log("Device_Name - DoCommand - Finish");
			#endregion Debug Message

			return new OperationResult(OperationResultCode.Success);
		}

		//****************************************************************************************
		// 
		//  SetDriverPropertyValue	-   
		// 
		//****************************************************************************************
		protected override IOperationResult SetDriverPropertyValue<T>(string propertyKey, T value)
		{
			#region Debug Message
			Log("Device_Name - SetDriverPropertyValue 1 - Start");
			#endregion Debug Message

			switch (propertyKey)
			{
				case "CheckboxValue":
					Checkbox_Value_Property.Value = value.Equals(true);
					#region Debug Message
					Log("Device_Name - SetDriverPropertyValue 1 - CheckboxValue= " + Checkbox_Value_Property.Value);
					#endregion Debug Message
					break;

				case "TextEntryValue":
					var TextEntryValue = value as int?;
					if (TextEntryValue != null)
					{
						Text_Entry_Value_Property.Value = (int)TextEntryValue;
					}
					else
					{
						#region Debug Message
						Log("Device_Name - SetDriverPropertyValue 1 - Couldn't Convert value to int");
						#endregion Debug Message
					}
					#region Debug Message
					Log("Device_Name - SetDriverPropertyValue 1 - TextEntryValue = " + Text_Entry_Value_Property.Value);
					#endregion Debug Message
					break;

				default:
					#region Debug Message
					Log("Device_Name - SetDriverPropertyValue 1 - Unhandled PropertyKey = " + propertyKey);
					#endregion Debug Message
					break;
			}

			Commit();

			#region Debug Message
			Log("Device_Name - SetDriverPropertyValue 1 - Finish");
			#endregion Debug Message

			return new OperationResult(OperationResultCode.Success);
		}

		//****************************************************************************************
		// 
		//  SetDriverPropertyValue	-   
		// 
		//****************************************************************************************
		protected override IOperationResult SetDriverPropertyValue<T>(string objectId, string propertyKey, T value)
		{
			#region Debug Message
			Log("Device_Name - SetDriverPropertyValue 2 - Start");
			#endregion Debug Message

			Commit();

			#region Debug Message
			Log("Device_Name - SetDriverPropertyValue 2 - Finish");
			#endregion Debug Message

			return new OperationResult(OperationResultCode.Success);
		}

		//****************************************************************************************
		// 
		//  Connect	-   
		// 
		//****************************************************************************************
		public override void Connect()
		{
			#region Debug Message
			Log("Device_Name - Connect - Start");
			#endregion Debug Message

			if (Protocol == null)
			{
				#region Debug Message
				Log("Device_Name - Connect - Protocol was null when Connect was called");
				#endregion Debug Message
			}
			else
			{
				#region Load Persistant Settings
				var temp = GetSetting(Filename);
				if (temp != null)
				{
					Settings = (Settings_Data)temp;
				}
				else
				{
					//No Persistant Notifications - Create From Scratch and Save for Next Time
					Settings = new Settings_Data();
					SaveSetting(Filename, Settings);
				}
				#endregion Load Persistant Notifications

				base.Connect();

				// Set Connected flag to true
				Connected = true;

				Protocol.Start();
			}

			#region Debug Message
			Log("Device_Name - Connect - Finish");
			#endregion Debug Message
		}

		//****************************************************************************************
		// 
		//  Disconnect	-   
		// 
		//****************************************************************************************
		public override void Disconnect()
		{
			#region Debug Message
			Log("Device_Name - Disconnect - Start");
			#endregion Debug Message

			if (Protocol == null)
			{
				#region Debug Message
				Log("Device_Name - DisconnectProtocol was null when Disconnect was called");
				#endregion Debug Message
			}
			else
			{
				Protocol.Stop();

				base.Disconnect();

				// Set Connected flag to false
				Connected = false;
			}

			#region Debug Message
			Log("Device_Name - Disconnect - Finish");
			#endregion Debug Message
		}
		#endregion Overrides
	}
}
