# FlightSchedulingV1.0

# Deployed in Amazon AWS
- Application is deployed in Amazon AWS
- URL: http://13.59.69.242/

# Scope of Work:
1. Airport authorities should able to view all the available gates and scheduled flights
2. Re-scheduling of flights
   - Reschedule on same day
   - Reschedule to next day if slots are not available for same day
3. Operators should able to add new flights.
4. Flight cancellation

# Use Case - Flight Scheduling:
1. Flight Scheduling & Re-Scheduling Use Case

![alt text](https://github.com/duvurih/FlightSchedulingV1.0/blob/master/FlightScheduling/FlightSchedulingProject/Content/images/Flight%20Scheduling%20UseCase1.png)

2. Flight Status View Use Case

![alt text](https://github.com/duvurih/FlightSchedulingV1.0/blob/master/FlightScheduling/FlightSchedulingProject/Content/images/View%20Flights%20UseCase2.png)

# Technology Stack:
1. Microsoft ASP.NET MVC 5.0
2. Microsoft .NET Framework 4.5
3. Microsoft Web API 2.0
4. AngularJS (Reference of HotTowel AngularJS)
5. Bootstrap
6. Unit Test Framework
7. Windsor Castle for Dependency Injection

# Design Concepts:
1. Responsive Design
2. Repository Pattern
3. Unit Test Coverage

# Project Setup:
1. Web  Project
   - Bootstrap with ASP.NET MVC
   - Bundling & Minification using BundleConfig for all CSS and JavaScript files
   - AngularJS Setup
      - common: common functioanlity like logging, spinner
      - services: generic data service, directives
      - config file in the app folder
      - layout: setup layout files
      - features: add folder for each feature
2. Infrastructure Project
   - Data Initialization: for initializing data
   - Repositories: for actions related to Gates and Flights
3. Core Project
   - Model: All application specific models
   - Interfaces: All application specific interfaces

# Flight Scheduling v1.0 - Dashboard View
![alt text](https://github.com/duvurih/FlightSchedulingV1.0/blob/master/FlightScheduling/FlightSchedulingProject/Content/images/FlightSchedulingDashboard.jpg)
