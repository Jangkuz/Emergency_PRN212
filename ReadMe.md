#PRN212_Emergency_Assignment_1
# Emergency
# Emergency_PRN212


PRN212 Assignment 01
Building a Hotel Management System with Windows Presentation Foundation (WPF) and LINQ

1. Introduction
Hotel Management System (HMS) can help you streamline and automate various aspects of managing a hotel. It can help you keep track of room reservations, bills, guest information, and financial transactions. The HMS can also help you manage housekeeping and maintenance tasks, as well as track inventory and purchase orders. Building an HMS can also help you improve customer satisfaction by providing them with a user-friendly interface to book rooms and manage their stays. Here are some key components and functions of a Hotel Management System
    • Online Booking and Reservation: The system allows customers to make bookings and reservations online through a user-friendly interface. It provides real-time availability of vehicles, rental rates, and booking confirmations.
    • Room Management: Room management in a hotel management system refers to the process of efficiently and effectively managing the rooms and their occupants in a hotel. 
		- RoomInformation (RoomID (int) 
		- RoomNumber (string, 50)
		- RoomDescription (string, 220)
		- RoomMaxCapacity (int)
		- RoomStatus (1 Active, 2 Deleted)
		- RoomPricePerDate (decimal)
		- RoomTypeID (int, get from RoomType Collection))
			- RoomType (RoomTypeID, RoomTypeName (string, 50), TypeDescription (string, 250), TypenNote (string, 250))
    • Customer Management: The system maintains a database of customer information, including contact details, identification documents, and room booking history. It enables easy retrieval of customer records, communication, and personalized service. 
		- Customer (CustomerID (int)
		- CustomerFullName (string, 50)
		- Telephone (string, 12)
		- EmailAddress (string, 50)
		- CustomerBirthday(date)
		- CustomerStatus (1 Active, 2 Deleted)
		- Password (string, 50))
Imagine you're a developer of a FU Mini Hotel Management System named FUMiniHotelSystem. To implement a part of this system your tasks include: 
    • Manage customer information. 
    • Manage room information. 
    • Manage online/offline booking transaction.
The application has a default account (admin account) whose email is “admin@FUMiniHotelSystem.com” and password is “@@abc123@@” that stored in the appsettings.json.
This assignment explores creating an application using Windows Presentation Foundation with .NET Core, and C#. An "in-memory database" will be created to persist the customer and room data, so a collection is called List will be used for reading and managing data.

2. Assignment Objectives
In this assignment, you will:
    • Use the Visual Studio.NET to create Windows Presentation Foundation (WPF) and Class Library (.dll) projects.
    • Create a List of persisting customers and room information
    • Using LINQ to Object to query data
    • Apply passing data in the WPF application.
    • Apply 3-Layers architecture to develop the application.
    • Apply MVVM (Model-View ViewModel) pattern in the application.
    • Apply Repository pattern and Singleton pattern in a project.
    • Add CRUD and searching actions to the application.
    • Apply to validate data type for all fields.
    • Run the project and test the WPF application actions.


3. Main Functions
    • Member (Admin/Customer) authentication by Email and Password. 
    • If the user is an “Admin” then his/her is allowed 
        ◦ Manage customer information. 
        ◦ Manage room information. 
        ◦ Create a report statistic by the period from StartDate to EndDate, and sort data in descending order.
    • If user is a “Customer”, this customer role is allowed to:
        ◦ Manage his/her the profile.
        ◦ View booking reservation history.
    • Note that: Customer management, Room: Read, Create, Update, Delete and Search actions. Creating and Updating actions must be performed by popup dialog. Delete action always combines with confirmation.


4. Note
    • You must use Visual Studio 2019 or above (.NET5/.NET6/.NET7/.NET8), MSSQL Server 2012 or above for your development tools.  
    • To do your program, you must use Windows Presentation Foundation. Note that you are not allow to connect direct to data source from WPF, every database connection must be used through Repository and Data Access Objects. 
    • Create Solution in Visual Studio named StudentName_ClassCode_A01.sln.  Inside your Solution, the Project WPF must be named: StudentNameWPF.
    • Set the default user interface for your project as Login window.


Data Source in this case is the Collection (In-Memory Database)
