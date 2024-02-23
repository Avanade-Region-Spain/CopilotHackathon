# GitHub Copilot Hackaton

Demo project for running labs to evaluate Copilot viability

- [Goal](#goal)
- [Pre-requisites](#pre-requisites)
- [Work with Github Codespaces](#work-with-github-codespaces)
- [Work locally](#work-locally)
- [Instructions](#instructions)

## Goal

The goal of a GitHub Copilot Hackaton is to learn how to use it, using a set of [exercises (labs)](#labs-instructions) that consist of building a web server using Nodejs with different functionalities, a .NET Web API or a Java Rest API (either Spring Boot or Quarkus).

We have also set two exercises for data engineers and data scientists based on python.

For those who are already familiar with GitHub Copilot, we have also defined a series of [challenges](#challenges-instructions) to test your skills. In this case, you will find an introduction and short guidance to help you solve the challenge, but you will have to do most of the work on your own (with the help of Copilot, of course).

GitHub Copilot is an AI-powered code assistant that helps developers write better code faster. It uses machine learning models trained on billions of lines of code to suggest whole lines or entire functions based on the context of what you’re working on. By using Copilot, you can learn how to write better code and improve your productivity.

Remember:

- As you type GitHub Copilot will make suggestions, you can accept them by pressing Tab.
- If nothing shows up after Copilot write some lines, press enter and wait a couple of seconds.
- Press **Ctrl + Enter**, to see more suggestions.
- Use Copilot chat to support your learning and development.
- Press **Ctrl + i** to start Copilot chat inline within your code. 

## Pre-requisites

**GitHub Copilot access**

If you still do not have an active Copilot license, a 30 day trial can be requested here: https://github.com/github-copilot/signup.

### Work with GitHub Codespaces

Environment is already configured to work with Github Codespaces, you can find the configuration files in the .devcontainer folder.

To start programming just start a new codespace and you are ready to go, don't need to install anything.

### Work locally

**VisualStudio Code**

https://code.visualstudio.com/

**Install Docker**

https://docs.docker.com/engine/install/

**For Nodejs**

- [Install Node and npm](https://docs.npmjs.com/downloading-and-installing-node-js-and-npm)
- Install mocha: 

Run:

``` bash
 npm install --global mocha
 npm install axios
```

**For .NET**

[Install .Net](https://dotnet.microsoft.com/download)

**For Java**

- [Install Java](https://learn.microsoft.com/en-us/java/openjdk/install)
- [Install Maven](https://maven.apache.org/install.html)

**For Python**
- [Install Python](https://www.python.org/downloads/)

## Labs instructions

- [Node Server](./exercisefiles/node/README.md)
- [.NET Web API](./exercisefiles/dotnet/README.md)
- [Java Spring Boot](./exercisefiles/springboot/README.md)
- [Java Quarkus](./exercisefiles/quarkus/README.md)
- [Python Data Engineer](./exercisefiles/dataengineer/README.md)
- [Python Data Scientist](./exercisefiles/datascientist/README.md)

## Challenges instructions

- [Develop a shop cart](./challenges/eshop/eshop.md) 
- [Develop a memory game](./challenges/memorygame/memorygame.md)
- [Develop a chat based on websockets](./challenges/chatwebsockets/chatwebsockets.md)
- [Behavior Driven Development (BDD) challenge](./challenges/bdd/README.md)
- [Analysis cryptocurrency market](./challenges/cryptoanalisis/crypto.md)

## Solution example End2End guidelines

The Avanade team has wanted to build a complete solution so that you can go through all the steps of it and assess the skills or shortcomings of Copilot, for this we have created a group of components that together form a complete functional solution.

To build a functional solution you can follow the next steps:

### [Application](./completesolution/bdd/dotnet/README.md) <- NEED TO BE CREATED WHEN A FULL VISUAL STUDIO SOLUTION MADE

This is a very simple .NET application that has an authors controller and a books controller. The authors controller has CRUD operations and the books controller has read and write operations. The application has an in-memory database that is initialized with test data. The application has a set of unit tests that cover 100% of the code.

You can follow the [PROMPTS.md](./completesolution/bdd/PROMPTS.md) file to see the steps that Copilot has followed to create the solution tests in Gherkin.

### [Infrastructure](./completesolution/infrastructure/main.tf)

This is a base infrastructure for the application, it has a resource group, a storage account and a container registry. The infrastructure is defined in Terraform and it is deployed in Azure.

You can follow the [PROMPTS.md](./completesolution/infrastructure/PROMPTS.md) file to see the steps that Copilot has followed to transform the original Terraform code into a best practice module structure.

### Deploy

To make the components work together you need a pipeline to build the solution, deploy the infrastructure and deploy the application.

You can see the [PROMPTS.md](./completesolution/pipelines/PROMPTS.md) file to see the steps that Copilot has followed to create the pipeline. This is a pipeline that deploys the application and the infrastructure. The pipeline is defined in Azure DevOps and it is triggered by a commit in the main branch. The pipeline has a set of tasks that download the application, build it, publish it and deploy it. The pipeline also has a set of tasks that deploy the infrastructure.

### [Refactor code example](./completesolution/refactor_code/PROMPTS.md)

Here you can see the steps we have been guiding Copilot to take any code, in this case in .Net, and apply some SOLID principles and good practices to achieve an improved and cleaner code.

### [Transform code example](./completesolution/transform_code/PROMPTS.md)

In this other example, we can see how we have used Copilot to completely transform a code written in .Net into other languages such as Java or Python.
