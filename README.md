# NumberConverter
A fully tested library to convert numbers to words. 

# Software Requirement
You need to have Visual Studio 2015 or later installed on your machine.

# Running Application
Set Web.UI as the startup project from Solution Explorer and run the Web Application after building the solution.

# Technical Description
The code is implemented in the service 'NumberToWordsConverter.cs'. Unit tests for this service are written using Nunit and Bddfy. 
You can simply run the unit tests and a report file will be generated in the NumberConverter\NumberConverter.Tests\bin\Debug directory named BDDfy.html
You can open this file to view report of all executed tests 

# Restful API
We can create a Web API wrapper around the service to expose restful API for clients. Normally in a project we have a UI project which is ASP.net MVC in this case and a WebAPI project (not included in the solution) for exposing restful endpoints. 
