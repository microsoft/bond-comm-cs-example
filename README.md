# Bond Comm C# Example #

A simple example service, demonstrating the
[Communications framework](https://microsoft.github.io/bond/manual/bond_comm.html)
of [Bond](https://github.com/Microsoft/bond).

# Getting started #

You should be able to clone this repository, open the .sln in Visual Studio
2015, and build.

# The examples #

There are two examples in this repository, demonstrating the server- and
client-side of a simple calculator.

* [calculator-service](https://github.com/Microsoft/bond-comm-cs-example/tree/master/calculator-service)
* [calculator-client](https://github.com/Microsoft/bond-comm-cs-example/tree/master/calculator-client)

Be sure to look at the `.csproj` files as well as the `.cs` files, as Bond
Comm needs to be integrated into the build as well.

## Running the examples ##

The calculator-client expects that the service is already running and
listening on the expected port, so make sure to run calculator-service
first.

Both examples pause at the end of execution, waiting for you to press the
Enter key.

# Questions? #

For questions about these examples, feel free to open an issue here. For
questions about Bond or Bond Comm, please use the
[main Bond repository](https://github.com/Microsoft/bond).
