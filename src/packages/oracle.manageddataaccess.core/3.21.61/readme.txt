Oracle.ManagedDataAccess.Core NuGet Package 3.21.61 README
==========================================================
Release Notes: Oracle Data Provider for .NET Core

April 2022

This provider supports .NET Core 3.1, .NET 5, and .NET 6.

This README supplements the main ODP.NET 21c documentation.
https://docs.oracle.com/en/database/oracle/oracle-database/21/odpnt/


New Features
====================================
- Oracle Identity and Access Management (IAM) - Database Alternative Password
ODP.NET Core and managed ODP.NET support alternate database password for Oracle IAM token authentication. 
This alternate password is different from the actual user's database password. It is used for database 
token authentication with shared Oracle Autonomous Database. This capability allows token-based 
authentication to be used with a password. 

- The Secure External Password Store (SEPS) Support
The Secure External Password Store (SEPS) is the usage of a client-side wallet
for securely storing the password credentials.  Oracle Data Provider for .NET 
Core can now be configured to use the external password store.
Please read the ODP.NET Developer's Guide on how to configure and utilize SEPS.
The provided instructions are the same for ODP.NET Unmanaged, Managed, and Core.


Bug Fixes since Oracle.ManagedDataAccess.Core NuGet Package 3.21.50
===================================================================
Bug 33681872 - UDT: LARGE UDT CAUSES ORA-06502 NUMERIC OR VALUE ERROR: RAW VARIABLE LENGTH TOO LONG
Bug 33293917 - UDT: NULLABLE DATETIME TYPES ARE NOT BEING STORED PROPERLY IN THE DATABASE
Bug 32843859 - ORA-01006: BIND VARIABLE DOES NOT EXIST ERROR OCCURS WHEN DERIVEPARAMETERS USED WITH DIFFERENT DB VERSIONS
Bug 32675064 - UDT: USING UDT SUBSTITUTION ACROSS SCHEMAS RETRIEVES UDT METADATA FOR EACH RETRIEVED INSTANCE INSTEAD OF CACHING
Bug 32634175 - UDT: ORA-01008 IS ENCOUNTERED WHEN A COLLECTION ELEMENT TYPE IS DEFINED IN ANOTHER SCHEMA 
Bug 31806772 - ORACLECOMMANDBUILDER WITH BINDBYNAME IN CONFIG CAUSES EXCEPTION
Bug 30702373 - ORA-12592: INVALID NS PACKET FORMAT : DUE TO LARGE ACCEPT DATA


Known Issues and Limitations
============================
1) BindToDirectory throws NullReferenceException on Linux when LdapConnection AuthType is Anonymous

https://github.com/dotnet/runtime/issues/61683

This issue is observed when using System.DirectoryServices.Protocols, version 6.0.0.
To workaround the issue, use System.DirectoryServices.Protocols, version 5.0.1.

 Copyright (c) 2021, 2022, Oracle and/or its affiliates. 
