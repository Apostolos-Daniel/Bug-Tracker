# Bug-Tracker
A bug tracker built using Blazor server side framework. 

# Architecture

The solution's basic pillars is the web front end (Blazor server side), and the backend API (.NET Core Web API). 

The data is persisted using a leight-weight NoSQL database called `LiteDB`. 

## Web front end

The Blazor front end is component based. It contains 4 core components:

- BugList
- BugCreator
- UserList
- UserCreator

The components have access to their respective CRUD methods, which interact with the persistent infrastructure layer (LitDB in this case), 
via an API. 

## Testing

No testing has been done within the solution. Integration tests and unit tests could be added to the solution at all layers (front end, API, 
data access). Postman tests have been used while building the API. 

# Functionality

The solution can currently:

- display a list of users and a list of bugs
- display and edit individual users and bugs
- assign bugs to users (via the bug edit)

Currently the solution is very validation light. For example, the bug assignment has no link to the user itself. This can be added next. 

