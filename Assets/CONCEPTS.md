# Concepts

## Factory, Helper, Provider, Service?

- A **FACTORY** is a creational abstraction that **produces instances** of other objects — possibly with configuration, caching, or other logic.
- A **HELPER** is a **static or simple utility class** that provides convenience methods — no DI, no state, no lifetime management.
- A **PROVIDER** is a component that **provides data, state, or context** to consumers — usually with an ongoing or shared relationship, not just object creation.
- A **SERVICE** is a long-lived, reusable, **dependency-injected** component that provides a specific functionality or domain logic to other parts of the application.

## Preferred Order of Directives

1. @page
1. @namespace
1. @using
1. @inherits
1. @inject
