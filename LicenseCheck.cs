// You can use the following function to chekc your own license from a URL 
// This function is complete, you can use it your program - Knowledge of C#  and NinjaScript is required
    public class  FcTrident : Indicator
    {
    
    public static int zLicence_check ;
		private string zLicense_message ="";
		private int Getlicense()
		{
			

			  
			 // call only once
			 if (zLicence_check  > 0 )
				 return zLicence_check;
			 // zLicence_check = 9;			 
			  string url = "https://your_URL/getmid.php?machid=" + Cbi.License.MachineId ; 
			  string trading_account = "";			   
			 
				
		         try
		         {
					
					// Print("2"+trading_account);
					 
 	 
					{
					 
		             using (WebClient client = new WebClient())
		             {
		                 string myString = client.DownloadString(url);
						   
						 // is this license registered?
						if  (		myString.Length > 0)
						{ // good response
						 string lastupd = myString.Substring( 2,myString.Length-2);
						 string lifetime = myString.Substring( 0,1);
						// check for non-existing machine_id 
							if (lifetime == "9")
							{ // Mach ID not found
								zLicence_check = 9;							
								zLicense_message = "OFL-0002 - Visit https://optimumfinance.cc/nt8 for a license; Machine ID: "  + Cbi.License.MachineId ;
								Log(zLicense_message, LogLevel.Information);								
							}
							else
							{ // it is found // check expiry date
						
										 // check life time license.
									  if (lifetime == "1")  // it is a lifetime licences
									  {
										   zLicence_check = 1;
											zLicense_message = "OFL-0003: Visit https://optimumfinance.cc/nt8 - Lifetime license for Machine ID:"  + Cbi.License.MachineId;
											Log(zLicense_message, LogLevel.Information);										  
									  }
									  else
									  {
										DateTime zdateTime = DateTime.Parse(lastupd);
										 zdateTime = zdateTime.AddDays(35);
										 DateTimeOffset ExpiryDt = new DateTimeOffset(zdateTime);
										 
										 long ExpzdateTime = ExpiryDt.ToUnixTimeMilliseconds();
										 
										 
										  DateTimeOffset CurrDateTime = new DateTimeOffset(DateTime.Now);
										  long unixtimenow = CurrDateTime.ToUnixTimeMilliseconds();
										 // has license expired?
										  
										if (unixtimenow < ExpzdateTime)	
										{ // license has not expired
											 zLicence_check = 1 ;
											zLicense_message = "OFL-0004: Visit https://optimumfinance.cc/nt8 - license for Machine ID:"  + Cbi.License.MachineId + " will expire on " + zdateTime;
											Log(zLicense_message, LogLevel.Information);												
											
										}	
										else
										{
											 zLicence_check= 9;
											zLicense_message = "OFL-0009: Visit https://optimumfinance.cc/nt8 - license for Machine ID:"  + Cbi.License.MachineId + " has expired on: " + zdateTime + ". Please renew!";
											Log(zLicense_message, LogLevel.Information);												
										}
										
									  }
							} // else of found mach id 
						   }
						} // using
					} // SIM check
										
		         } // Try
		         catch (Exception ex)
		         {
		              Log("OFL-0000: Error: " + ex.Message, LogLevel.Information);
					 Log("OFL-0001: https://optimumfinance.cc/nt8 : Granted temporary License to Machine ID" + Cbi.License.MachineId , LogLevel.Information);
					  zLicence_check = 1;
		         }
			
			
			return zLicence_check;
		}
		// Call using 
        protected override void OnBarUpdate()
        {
    			 if (Getlicense() == 9)
				 return;
