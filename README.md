# async-playground

##Description

This is a practical demonstration of common gotchas enconutered when implementing asynchronous code in .net using the Task-based Asynchronous Pattern (TAP), aka async/await. It demonstrates situations in which blocking async code will/will not lead to deadlocks

##Code

Built in C# on Visual Studio 2015. The solution consists of the following projects

####src\BinaryMash.Playground.Async.BusinessLogic

Contains a service which provides various synchronous and asynchronous configurations of a simple service. This is used in the host applications described below.

####src\BinaryMash.Playground.Async.AspNetHost

An ASP.NET MVC application. This demonstrates how deadlocks occur when blocking any asynchronous code.

####src\BinaryMash.Playground.Async.ConsoleHost

A console application. This demonstrates how deadlocks only occur in a console application if we explictly add our own synchronization context.

####src\BinaryMash.Playground.Async.BusinessLogic.Tests

A unit test assembly. This demonstrates how deadlocks only occur in tests if we explictly add our own synchronization context.

##Further Reading

- [Async Programming - Brownfield Async Development](https://msdn.microsoft.com/en-us/magazine/mt238404.aspx), Stephen Cleary, July 2015
