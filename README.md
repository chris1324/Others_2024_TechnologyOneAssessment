# Technology One Assessment
## How To Build
1. Ensure that your machine has installed required dependencies and tools. Refer to "Prerequisites" section of [Get started with ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/tutorials/choose-web-ui?view=aspnetcore-6.0)
2. Clone the repository into your machine
3. Double click "TechOneAssessment.Web.sln" file. It should open the solution with Visual Studio.
4. Right click "TechOneAssessment.Web" and click on "Build". If it show Build succeeded then it is built succesfully.

## How To Host
1. Create a new App Service (Web App) in Azure
- Select "Code" for publish
- Select ".NET 6" for runtime stack
- Select "Windows" for Operating System
2. Right click "TechOneAssessment.Web" and click on "Publish".
3. Click "Add a publish profile"
4. Select "Azure" and next.
5. Select "Azure App Service (Windows)" and next.
6. Login and select the App Service you has created justnow and next.
7. The publish profile is created. Click "Publish" to publish.
8. The web is now accessible at your App Service Plan's Default domain.
9. This web can be hosted also in Linux operating system as it is written using .Net 6. 
10. It can also be containerized with Docker, but it will required to add a Dockerfile to build the docker image.

## How To Interact with It
1. The web can be access at "https://techoneaccessment.azurewebsites.net".
2. Enter a number
3. Click on "Convert" button
4. The result will show at the botton of your input