# CyzaTest
Solution for the test proposed by Cyza Inc.

## Technologies used:
- Front End
  - AngularJS 1.5
  - Angular Material
  - Yeoman (for angular scaffolding and tooling)
  - Bower
  - npm
  
- Back End
  - ASP.NET Web Api 2
  - Entity Framework
  - Identity Framework


## Environment used:
- Visual Studio Community 2015
- Sql Server Express 2014 (connection string on WebApi points to this schema).

## Instructions
### WebApi
It is necessary to generate the database from the Entity Model located on WebApi/Models to your Sql Server Express 2014 instance.
If you want to use other SQL Server instance, don't forget to edit the connection strings to match such instance.

To run the project set the Web Api as the startup project.


### FrontEnd
For the front end, Angular's Yeoman generator was used, it includes many utilities to improve the workflow on a AngularJS project.
This generator uses npm dependencies and bower dependencies, so, access the root of the FrontEnd project on your terminal and run. 
To use yeoman run the following command:

    npm install -g grunt-cli bower yo generator-karma generator-angular
    npm install
    bower install
    
And all the required dependencies will be installed, the Yeoman Angular project includes utilities for development environments.

To run the project use:

    grunt serve
