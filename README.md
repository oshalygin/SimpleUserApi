##Simple User Api
###Built using ASP.NET 4.5X, NUnit, MOQ

If you have any questions, feel free to drop me a line at oshalygin@gmail.com.

This is a sample application showing the basics behind a simple API that adds, updates and retrieves users.

####Common discussion points
* Extensive comments are usually a sign of poorly written code.  If there is something that is unclear it is likely because the developer is not clear with his intention(poor test coverage or specification) or the reader is inexperienced to modern development practice.
* The DataLayer(DAL) is a complex stub to minimize plumbing.
* There is no queue or retry mechanism built in, that would require another layer of either MSMQ or building out(not recommended especially for a simple project like this) a DB queue.  The DB queue would look something along the lines of a UserRequest and UserUpdate tables which would be processed on a timer(said timer would make a query against this table and look for a column 'Processed' which would be a DateTime).
* This whole project was time boxed to one hour, so please keep that in mind while reading the code.
