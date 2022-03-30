# challenge-Jobsity
Setup
=====
DB
	It works using Microsoft Sql LocalDb
	From Package manager console run: 
		Update-Database
	Or from dotnet Cli
		Dotnet ef database update

Frontend
	Install dependencies:
		npm install 
	Run Frontend
		ng serve -o

Mandatory Features
==========
● READY // Allow registered users to log in and talk with other users in a chatroom.
● READY // Allow users to post messages as commands into the chatroom with the following format /stock=stock_code
● Partial y compleated Bot included into the API /// Create a decoupled bot that will call an API using the stock_code as a parameter (https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv, here aapl.us is the stock_code)
● READY // The bot should parse the received CSV file and then it should send a message back into the chatroom using a message broker like RabbitMQ. The message will be a stock quote using the following format: “APPL.US quote is $93.42 per share”. The post owner will be the bot.
● READY // Have the chat messages ordered by their timestamps and show only the last 50 messages.
● Not yet // Unit test the functionality you prefer.

Bonus (Optional)
============
● Ready // Have more than one chatroom.
● I used Angular in  order to show interoperability between technologies // .NET identity for users authentication.
● Ready using patterns // Handle messages that are not understood or any exceptions raised within the bot.
● Not Yet // Build an installer.

