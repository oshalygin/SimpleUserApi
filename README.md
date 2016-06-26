##Simple User Api
###Built using ASP.NET 4.5X, NUnit, MOQ

If you have any questions, feel free to drop me a line at oshalygin@gmail.com.

This is a sample application showing the basics behind a simple API that adds, updates and retrieves users.

####Common discussion points
* Extensive comments are usually a sign of poorly written code.  If there is something that is unclear it is likely because the developer is not clear with his intention(poor test coverage or specification) or the reader is inexperienced to modern development practice.
* The DataLayer(DAL) is a complex stub to minimize plumbing.
* There is no queue or retry mechanism built in, that would require another layer of either MSMQ or building out(not recommended especially for a simple project like this) a DB queue.  The DB queue would look something along the lines of a UserRequest and UserUpdate tables which would be processed on a timer(said timer would make a query against this table and look for a column 'Processed' which would be a DateTime).
* This whole project was time boxed to about one hour, so please keep that in mind while reading the code.
* No authentication mechanism is introduced.  This adds unnecessary complexity and plumbing, but anything along of Individual Accounts, OAuth, JSON Web Tokens, Owin, etc could be used.
* This API can be accessed with any browser or with tools such as PostMan/Fiddler.
* There is no user/web interface.
* The base api endpoint is http://localhost:9005/api/user
* Versioning is URL based.  This isn't ideal for all situations and there can be many ways to tackle versioning but it works wonderfully for an application of this size.  You're free to look into content and request headers as other alternatives.
* There would be a slight proliferation of types across various layers, but it was decided to use an entity type and a viewModel type.
* Deletion = There is a flag in the database titled 'IsDeleted'.  Nothing is permanently deleted.
* Updates = There is a persisted history in the DB which is managed by an 'IsActive' flag.  When an update occurs on a record, the old value is set to false(bit-0).
* Only unit tests and a few simple acceptance tests are written in this example.  The acceptance tests depend on the API being already deployed to an IIS server.