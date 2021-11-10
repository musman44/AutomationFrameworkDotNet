## About Project

The purpose of this project is to Automate [http://adactinhotelapp.com/] website using .Net, Selenium, C# and Cucumber. Please see below for the Test Cases that are automated and instructions to run these test cases 


## Install

1.  Download and Install VS community edition, Android Studio, Appium Server

2.  Install all the required packages in VS 

3.  [OPTIONAL] Download and Install Vysor app (for mobile devices)

4.  Clone the repo from (https://github.com/musman44/AutomationFrameworkDotNet)

5.  Open project folder (AutomationFrameworkDotNet) in VS Code

6.  Build the project and run test cases 

## Run tests
 
	On VS Test explorer window, click any feature file and select scenario to run tests inside it 

8.  Following technologies are used in this project 

## Technology used:

 - Selenium
 - Cucumber
 - .Net framework
 - C# language
 - RestShar
 - Appium 
 - NUnit

9.  Following test cases are automated 

## Test Cases:
** Login/Search/Select/Book Hotel Test Case - Automate E2E functionality **  
** Steps Automated **

1. Open link [http://adactinhotelapp.com/]
2. Login to the website using user mentioned in app.config file 
3. Make sure that User is logged in successfully or throw Authentication failed message in case of invalid user 
4. On Search page, enter data for all required fields and hit search button 
5. Verify that search results are returned successfully
6. Select any row from the list on select page and hit continue button 
7. On Book Hotel page, enter user data for all required fields and hit Book now button 
8. Verify that hotel is booked successfully and order number is generated
