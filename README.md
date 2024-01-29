# Example project structure

Toy project to demonstrate and try some ideas on how to structure the solution.

`Application` is the app itself. It contains an interface to talk to an outside
world (`Controller`s). It is also responsible for wiring everything together using
dependency service container.

`Application.Domain` is the core of the module. It should be platform independent 
and should encapsulate the business logic. The idea is to store the operations and
related files (requests and responses) as close as possible. `IRepository` provides
a way to query data through `IQuery` interface - the idea is to have small, requsable 
and well defined components. 
However, operations make heavy use of EFCore's principles (change tracking).

`Application.Persistence` is implements repositories and connects the application
to the Database of choice.


## Important notes

- when unit testing, use service-based test extensions rather than test-case-based
  - this allows for better reusability across the different operations
- `DbContext` should adhere to the Flyt rules (tenant based filtering)
  - make sure that we are using appropriate configurations
  - use `CustomerApplicationDbContext` as a base class!

