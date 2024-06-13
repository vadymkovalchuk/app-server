To run: dotnet run
app-server.http contains port to bind to.
Cors is set to alow all origins.

API is pretty straightforward, the class to pay attention to - TempDataStore - simulates database, hard-codes a few users and products, and allows to manage customers and orders. Does not do any validations / cares about race conditions etc
