
<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/luizfelipers19/musicAPI/">
    ![music-954-675557](https://user-images.githubusercontent.com/26651389/113584397-3a2b9300-9601-11eb-8229-8e221a1e75b8.png)
  </a>

  <h3 align="center">MusicAPI</h3>

  <p align="center">
    An API to create and fetch data from your favorite songs!
    <br />
    <a href="https://github.com/luizfelipers19/musicAPI/"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://musicrestfulapi.azurewebsites.net/">Live API root</a>
    ·
    <a href="https://github.com/luizfelipers19/musicAPI/issues">Report Bug</a>
    ·
    <a href="https://github.com/luizfelipers19/musicAPI/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

![image](https://user-images.githubusercontent.com/26651389/113584075-d3a67500-9600-11eb-9654-24a454fdd31c.png)


This project was built as a second step towards learning and demistifying how the Backend works behind the curtains in a RESTful architecture. This API only accepts GET and POST requests and has no authentication, so everyone that comes across this, can simply test it's usability and get a better understanding of the RESTful infrastructure.
Well, as I said, the API only accepts GET and POST methods, so it's just a CR of a CRUD application. The reason: I don't want people deleting and updating the data that's already been added.

Here's why:
* RESTful API's are everywhere. Learning how they work will mostly help you to get a better grip on modern architectures
* Applications nowadays are split up in 2 or more sides, but mainly into the FrontEnd side and the Backend side. With this repo you can get a first step in understanding the Backend side by making simple requests to the API.
* The API was deployed to Microsoft Azure servers, and will be available to everyone to send requests.

#### My only request to everyone that finds this is to not bomb the API with requests!! This was built with love and it shouldn't be taken away.


### Built With

This project was built using the following technologies
* [C# language](https://docs.microsoft.com/pt-br/dotnet/csharp/)
* [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)




<!-- GETTING STARTED -->
## Getting Started

To run this application, follow the steps listed below:

### Prerequisites

You firstly need to have Visual Studio with .NET 5.0 framework installed in your machine.


### Installation
If you want to reproduce this application, learn how it was coded and take it further for yourself, you can follow the steps below to reach your goals. I won't teach how to make the integration with Microsoft Azure at this point, but maybe in one of my next projects.

1. Clone the repo
   ```sh
   git clone https://github.com/luizfelipers19/musicAPI.git
   ```
3. Install all these dependencies and packages through NuGet Package Manager

![image](https://user-images.githubusercontent.com/26651389/113583001-752cc700-95ff-11eb-8106-a8970bd10aaf.png)
   
4. Create the localDB by typing the commands:

- Add-Migration InitialMigration

- Update-Database


5. Compile and try running the application via IIS Express.


<!-- USAGE EXAMPLES -->
## Usage

This section introduces the application usage steps. For this, I'm using Swagger documentation printscreens. To use the application, you don't need to install it, because it runs inside Microsoft Azure servers and it's currently online.

As I've already mentioned. This application only accepts GET(read methods) and POST(create methods) Methods.

### Project structure
This project is organized in 3 Model Classes: Artists, Albums and Classes. 



<!-- ROADMAP -->
## Roadmap

I'll probably leave this as it is: a free and open-source application that users can send requests to the API and see it's functionality. In the future, I'll make other projects that implements JWT authentication and also includes both PUT and DELETE http methods.



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact

Luiz Felipe - luizfelipers19@gmail.com

Project Link: [https://github.com/luizfelipers19/musicAPI/](https://github.com/luizfelipers19/musicAPI/)

## Drop a Star for future projects
