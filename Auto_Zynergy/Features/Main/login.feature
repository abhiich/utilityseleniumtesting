Feature: LoginWithTwoFactor into Zynergy

Login into Zynergy Application

@Login
Scenario: Login with Two Factor Authentication into Zynergy
	* I am on the microsoft login page
	* I enter my email address
	* I enter the OTP
	* I should be logged into Zynergy
	
