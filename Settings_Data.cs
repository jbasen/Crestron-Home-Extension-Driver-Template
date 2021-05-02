using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Extension_Template
{
	public class Settings_Data
	{
		#region Declarations
		public bool Checkbox_Setting;
		public int Text_Entry_Setting;
		#endregion Declarations

		//****************************************************************************************
		// 
		//  Settings_Data	-   Constructor
		// 
		//****************************************************************************************
		public Settings_Data()
		{
			Checkbox_Setting = false;
			Text_Entry_Setting = 0;
		}
		//****************************************************************************************
		// 
		//  Save	-   
		// 
		//****************************************************************************************
		public void Save(bool Checkbox_Setting, int Text_Entry_Setting)
		{
			this.Checkbox_Setting = Checkbox_Setting;
			this.Text_Entry_Setting = Text_Entry_Setting;
		}
	}
}
