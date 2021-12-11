# ApiMultiTenant
This project is a study of Multi Tenant Architecture, where my idea is to automatically create the database after adding the new Tenant.

# The project
It is based on two API's

*Application* = It would be your application that can be scalable, which will receive the Tenant's request and will access the database that it has access to.

*Admin* = It would be your application for managing your tenants, which receives the request of a new tenant and already makes the creation of their database.

# Technologies
The idea was to use the EF Core 6.0 and the native migration management to create the new database.
