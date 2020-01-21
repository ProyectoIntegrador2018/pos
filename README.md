# POS-BP

This is the repository for the project of Team POS during the winter period of 2020.

The project aims to develop new functionality for a Point of Sale system (BluePOS), originally developed by software development firm Blue People.

## Table of contents

* [Client Details](#client-details)
* [Environment URLS](#environment-urls)
* [Da Team](#da-team)
* [Management tools](#management-tools)
* [Setup the project](#setup-the-project)
* [Running the stack for development](#running-the-stack-for-development)
* [Stop the project](#stop-the-project)


### Client Details

| Name               | Email             | Role |
| ------------------ | ----------------- | ---- |
| Aldo Lares | alares@bluepeople.com | Employee  |


### Environment URLS

* **Production** - [TBD](TBD)
* **Development** - [TBD](TBD)

### Da team

| Name           | Email             | Role        |
| -------------- | ----------------- | ----------- |
| Alan Velasco | A01113373@itesm.mx | Development |
| Juan Manuel Perez Font | A00819815@itesm.mx | Development |
| Eduardo Benitez | A01039203@itesm.mx | Development |

### Management tools

You should ask for access to this tools if you don't have it already:

* [Github repo](https://github.com/ProyectoIntegrador2018/pos)
* [Backlog](https://github.com/ProyectoIntegrador2018/pos/projects/1)
* [Heroku](https://crowdfront-staging.herokuapp.com/)
* [Documentation](https://drive.com)

## Development

The further sections are left as a guide to executing the dummy version of the project, as the development practices for the project have not been specified yet. The actual project is intended to run on a local machine in BluePeople's offices, inside their own code. Therefore, execution of this project acts as a dummy test of the components requested by BluePeople.

### Tech Stack

| Technology               | Version     | 
| ------------------ | ----------------- | 
| Vue.js | 2.6.11 |
| .NET Core | 3.1.0 |

### Setup the project

This project uses [Vue.js](https://vuejs.org/v2/guide/installation.html) and [.NET Core](https://dotnet.microsoft.com/download), so both should be installed in order to run it. After both are installed, you can proceed to clone the project:

```
git clone https://github.com/ProyectoIntegrador2018/pos.git
```

Since this project only connects to external APIs, there is no need for migrations or database setup, you are ready to go!

### Running the stack for Development

#### Running Vue.js

In your terminal, go to the vue.js project folder (`cd pos-dev/`) and install the required packages by running `npm install`, then fire up the development server with:

```bash
npm run serve
```

You should see the output stating the local and network urls of the development server, like so:

```
DONE  Compiled successfully in 444ms                                                                                           6:24:37 PM

Type checking in progress...

  App running at:
  - Local:   http://localhost:8080/ 
  - Network: http://192.168.15.3:8080/

  Note that the development build is not optimized.
  To create a production build, run npm run build.

No type errors found
Version: typescript 3.5.3
Time: 1427ms
```

#### Running .NET Core

In your terminal, go to the .NET project folder (`cd POS-netcore/POS/`) and execute the run dotnet command:

```bash
dotnet run
```

The output should show info relevant to the running server, as well as the url its listening on:

```
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /Users/apple/Projects/POS-core/POS-netcore/POS
```

### Stop the project

To stop the project, go into any of the currently running terminal windows and type `Ctrl-C`, both servers should stop running by typing this into each terminal window with the currently running projects.
