# PhoneBook Console Application

## To run create a .env file in the root directory and add the following properties
* CONNECTION_STRING=Connection string to your database
* TWILIO_ACCOUNT_SID=Twilio Account SID (Security Identifier)
* TWILIO_AUTH_TOKEN=This is your Twilio Auth Token
* TWILIO_PHONE_NUMBER=phone number that you've purchased or provisioned through Twilio
* Twilio_Recovery_Code=typically a recovery code for your Twilio account
* AppPassword=gmail app password(A 16 letter code given by gmail to authenticate you)
* EmailId= emailid to send mails from
* Name=Your Name

To create database locally run the below command in your NuGet Package Manager Console:
* dotnet ef database update

## Features
* This is an application where we record contacts with their phone numbers.
* Users should be able to Add, Delete, Update and Read from a database, using the console.
    ! [Screenshot] (/images/Menu.png)
* Entity Framework is used as an ORM
* The code validate e-mails and phone numbers and let the user know what formats are expected
* User can create categories of contacts (i.e. Family, Friends, Work, etc).
    ! [Screenshot] (/images/Validation.png)  
* Code-First Approach is used, which means EF will create the database schema for us.
* Microsoft SQL Server is used as the database.
* Functionality to allow users to add the contact's e-mail address and send an e-mail message from the app.
    ! [Screenshot] (/images/email.png)  
* The app also sends SMS to valid phone numbers using the twilio app.
    ! [Screenshot] (/images/sms.png)  
