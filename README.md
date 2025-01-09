# BidWheels API

This project is a .NET 8 application deployed on AWS Elastic Beanstalk. It includes a React frontend for user login functionality.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [Deployment](#deployment)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [AWS CLI](https://aws.amazon.com/cli/)
- [Elastic Beanstalk CLI](https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/eb-cli3-install.html)

## Installation

1. Clone the repository:

    ```sh
    git clone https://github.com/yourusername/bidwheels-api.git
    cd bidwheels-api
    ```

2. Install backend dependencies:

    ```sh
    dotnet restore
    ```

3. Install frontend dependencies:

    ```sh
    cd src/components
    npm install
    ```

## Running the Application

1. Start the backend:

    ```sh
    dotnet run --project src/Services/bid-wheels.Services.api
    ```

2. Start the frontend:

    ```sh
    cd src/components
    npm start
    ```

## Deployment

1. Ensure you have configured AWS CLI with your credentials:

    ```sh
    aws configure
    ```

2. Initialize Elastic Beanstalk application:

    ```sh
    eb init -p ".NET 8 running on 64bit Amazon Linux 2023/3.2.2" bidwheels-api --region us-east-1
    ```

3. Create an environment and deploy:

    ```sh
    eb create Bidwheels-api-env
    eb deploy
    ```
