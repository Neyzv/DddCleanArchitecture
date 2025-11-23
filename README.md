# DDDCleanArchitecture

This is a sample news letter project that aims to demonstrate how to properly create a project with a DDD clean architecture. It also contains a bunch of usefull utility classes for WPF app development.


## Why using DDD

Based on my experience, DDD is a pretty good kind of architecture to create scalable and easy to test apps.\
Its core principle is to clearly separate the business logic, application flow, the UI and the infrastructure to each others.

### Strong separation of concerns

Each layer has a well-defined responsability.\
\
Here are the differents layers with their responsability :
- **Domain** : Must contains the business rules and the interfaces that describes the application flow like repositories or services definitions. It should be pure with less dependencies as possible.
- **Application** : This is the layer that orchestrates the use cases. It should contains the implementations of the services and the features implementations such as Bluetooth handling for example.
- **Infrastructure** : Its goal is to manage persistent data, such as databases or external API's.
- **Presentation** : Should be your UI application.

### Framework independence

A project that use DDD principles can swap to any other framework or technologies with a minimal friction. Or also create another project which will provide the same functionalities with the same references.

### High testability

Because the Domain and the Application layers have no dependency to any UI framework they are extremely easy to test. You can test business rules without requiring a database, UI or file system.

### Better long term maintanability

As a project grows, codebase often become hard to maintains. With DDD and its logic separation, it's easier to extend or modify the system without breaking existing behavior.

### Project dependencies

In the DDD structure the project's dependencies are also very important. Like it was said before the Domain should always stay pure without any dependencies.\
\
Your dependencies should follow this schema :
```
Domain -> Nothing
Infrastructure -> Domain
Application -> Domain, Infrastructure
Presentation -> Application, Domain, Infrastructure
```

## About this project

In this project you can find an example of the usage of a DDD clean architecture which follows the previously mentioned principles. I also decided to use a source generator to avoid using reflection and an internationalisation project to store all my labels values in different languages (EN / FR). The presentation layer is a WPF app which use the MVVM pattern.


### Features

#### Internationalisation
You can find an `InternationalisationService` in `lib\DddCleanArchitecture.Application\Services\Internationalisation` folder to manage the language changes.

#### Specification pattern

The infrastructure layer use a SQLite database with EFCore and a generic repository. To perform queries in the repository I have choosed to implement a custom implementation (in my opinion easier to use) specification pattern.

#### Navigation system

The presentation layer contains a navigation system with transition animations, with automatic page registration great to the source generator.


### Greatings

Thanks to [Christophe Mommer](https://github.com/christophe-mommer), [Nick Chapsas](https://github.com/elfocrash) and [Aerafal](https://github.com/AerafalGit) for their knowledge.