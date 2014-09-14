AngularApiTalk
==============

This is the example code from the "AngularJS in the frontend" talk at Umbraco Dk Festival 2014. Purpose is to show how to serve data to Angular from Umbraco. @abjerner has made a NuGet package to handle the response-object. It is included in the example code. If you wan´t to start your own project, you can get it at https://www.nuget.org/packages/Skybrud.WebApi.Json/

Comments and questions are mostly welcome on twitter @pjengaard

You can find Filips Angular code here: https://github.com/filipbech/umbdkfest14-angular


This repository contains
===========

+ /web/ - Umbraco 7 installation
+ /code/ - Code-project handling all logic (most important code is in /code/Controllers/NewsApiController.cs)



Get it running
==============

+ Update Nugets
+ Attach IIS to /web/ folder or build and run the "web"-project from VS
+ Open url http://localhost/umbraco/api/newsapi/search/ or /umbraco/api/newsapi/getnews/1070



Links
=============

JSON View for Chrome: https://chrome.google.com/webstore/detail/jsonview/
NuGet package for handling response from WebApi: https://www.nuget.org/packages/Skybrud.WebApi.Json/

