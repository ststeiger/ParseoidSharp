Welcome to libParseoid!
===================

### Table of contents


**What is libParseoid ?**

> libParseoid is a library & console program to convert MediaWiki-Markup (wikipedia) into HTML. 
> libParseoid uses parsoid, the official markup converter by wikipedia. 
> libParseoid uses Microsoft.AspNetCore.NodeServices to achieve this. 


#### Releases
You can download the latest-release >here<, or see a list of any other releases >here<


#### Quick-start guide
To see how to get the release running, please follow the Quick-Start-Guide >HERE<


Building
-------------

> 1. Install nodeJS (used version v8.6.0)
> 2. git clone https://github.com/ststeiger/ParseoidSharp
> 3. npm install -g npm
> 4. cd \visual studio 2017\Projects\WikiRenderer\WikiRenderer
> 5. npm install 

You can build libParsoidSharp using Visual Studio 2017 Community on Windows (free), 
or using JetBrains Rider on Linux/Mac/Windows. 

You can also build libParsoidSharp without IDE, using the .NET-Core command-line tools. <br />
To do so, open a command prompt, and go the the directory where the file WikiRenderer.sln is in.
Then do the following:

**Build for Windows x86-64:**
> dotnet restore -r win-x64<br />
> dotnet build -r win-x64<br />
> dotnet publish -f netcoreapp2.0 -c Release -r win-x64<br />

**Build for Windows x86-32:**
> dotnet restore -r win-x86<br />
> dotnet build -r win-x86<br />
> dotnet publish -f netcoreapp2.0 -c Release -r win-x86<br />

**Build for Linux x86-64:**
> dotnet restore -r linux-x64<br />
> dotnet build -r linux-x64<br />
> dotnet publish -f netcoreapp2.0 -c Release -r linux-x64<br />


**Build for Linux ARM-32 (Raspberry PI/Chromebook/Android):**
> dotnet restore -r linux-arm<br />
> dotnet build -r linux-arm<br />
> dotnet publish -f netcoreapp2.0 -c Release -r linux-arm<br />


**Build for Linux x86-32:**
> **not supported by framework**


Technical Details
-------------

**libParseoid works with the following technologies:**
> 
> - Microsoft ASP.NET-**CORE** 2.0 with C#
> - NetStandard-2.0
> - NodeJS (used version v8.6.0)


Further information:
https://medium.com/the-node-js-collection/why-the-hell-would-you-use-node-js-4b053b94ab8e


### Build Status


Bellow, you see the current build-status of the master-branch:

| Item     | Code-Coverage | Build-Status   |
| :------- | ------------: | :------------: |
| Windows  | 100%          |  ![Continuous Integration Status](https://travis-ci.org/ststeiger/RubyService.svg?branch=master)        |
| Linux    | 100%          |  ![Continuous Integration Status](https://travis-ci.org/ststeiger/RubyService.svg?branch=master)        |
| Mac      | 100%          |  ![Continuous Integration Status](https://travis-ci.org/ststeiger/RubyService.svg?branch=master)        |



### Support libParseoid

[![](https://cdn.monetizejs.com/resources/button-32.png)](https://monetizejs.com/authorize?client_id=ESTHdCYOi18iLhhO&summary=true)
