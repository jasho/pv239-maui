---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
marp: true
---

<style>
    @import url('../styles/presentation-styles.css');

    .container {
        display: flex;
    }

    .col {
        flex: 1
    }

    img[alt~="center"] {
    display: block;
    margin: 0 auto;
    }

    section.demo h1 {
        text-align: center;
        margin: 180px;
        font-size: 80px;
        color: rgb(132, 168, 196)
}
</style>

# PV239 – 04 IOC

---

## Voting on bonus topics
- Closing - end of exercise **today**

---

## Project status

- Teams
- Topic submission
- Discord
- Consultations

---

## Exercise schedule
- Until 16. 3. - Submit questions for Microsoft
- 23\. 3. **break** (no exercise)
- 30\. 3. Last exercise + pub

---

## Goals
<!--
header: '**Dependency Injection** &nbsp;&nbsp; Inversion of Control &nbsp;&nbsp; Shell Arguments'
-->

- Get to know the principles of IoC/DI
- Passing arguments in Shell navigation

---

## Goals
- Get to know the MVVM design pattern
- Look at the concepts for Data Binding

---

## Dependency injection
- Filling dependencies “from the outside”
- Only declares what external dependencies it needs
- Dependencies are created outside of the class and have their own lifecycle
- Sample – class `IngredientListViewModel`
    - Needs to navigate to other pages – `IRoutingService`
    - Needs to load data - `IIngredientsClient`

---

## Dependency injection
<!-- _class: demo -->

# DEMO

---

## IoC/DI
<!--
header: 'Dependency Injection &nbsp;&nbsp; **Inversion of Control** &nbsp;&nbsp; Shell Arguments'
-->

- Inversion of Control
    - Classes don’t know about each other, communicate via interfaces
    - Classes don’t create dependencies themselves
- Why? Boxes with exactly specified responsibilities
- They only take care of their business
- Can be replaced anytime with a different implementation
    - Even on the level of application configuration

---

## IoC/DI in C#
- Class `ServiceCollection` + interface `IServiceCollection`
- Nuget package `Microsoft.Extensions.DependencyInjection`
- Container, where everything gets registered and from where it gets resolved

---

## Lifetime management
- Singleton
    - 1 instance for the whole program lifetime
- Transient
    - New instance every time
- Scoped
    - The same instance for all classes within 1 request
    - A new instance for another request

---

## Inversion of Control
<!-- _class: demo -->

# DEMO

---

## Shell – passing arguments
<!--
header: 'Dependency Injection &nbsp;&nbsp; Inversion of Control &nbsp;&nbsp; **Shell Arguments**'
-->

- Send parameters using the `Shell.Current.GoToAsync()` method
    - Can be part of Uri: `$"detail?id={id}"` - like HTTP request
    - Or passed as 2nd parameter: `new Dictionary<string, object> { ["id"] = id }`

- On the receiving end
    - Add property to ViewModel
        - `public Guid Id { get; set; }`
    - Add class attribute to ViewModel
        - `[QueryProperty(nameof(Id), nameof(Id))]`

---

## Shell – passing arguments
<!-- _class: demo -->

# DEMO

---

## Create a sample Ingredient edit page and add update functionality to IngredientsClient
<!-- _class: demo -->

# DEMO

---

## Goals
- Get to know the MVVM design pattern
- Look at the concepts for Data Binding

---

## Voting on bonus topics
- Closing - end of exercise **today**