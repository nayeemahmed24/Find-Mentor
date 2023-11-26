# Rate-My-Mentor
A simple application using **.NET 6** to practice CQRS, MassTransit and Ocelot

## Overview
This a simple a project to practice and showcase different technologies using .NET.

Business Logic of the project revolves around a popular site https://ratemyteachers.com/. This helps students to suitable course and project supervisor based on the professor's review and rating.

## Technologies Used

- .NET 6
- Entity Framework Core (EF Core)
- Ocelot (Not Implemented yet)
- MediatR
- MassTransit
- RabbitMQ
- Other relevant technologies/frameworks/libraries used

## Architecture Diagram

![Design Document](https://github.com/nayeemahmed24/Find-Mentor/assets/42116405/20c88ed0-30e5-4a09-845b-f024e9118615)

## Design Approach
I tried to use CQRS. I used MediatR library and segregated commands and queries to make the codes maintainable. I used single database for both command and query. In future I can migrate this things into different service and can use different read replica for queries.
