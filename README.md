
# Magic Lambda Logging

[![Build status](https://travis-ci.org/polterguy/magic.lambda.logging.svg?master)](https://travis-ci.org/polterguy/magic.lambda.logging)

Audit logging wrapper slots for [Magic](https://github.com/polterguy/magic). More specifically, this project provides the following slots.

* __[log.info]__ - Information log entries, typically smaller pieces of information
* __[log.debug]__ - Debug log entries, typically additional debugging information not enabled in production
* __[log.error]__ - Error log entries, typically exceptions
* __[log.fatal]__ - Fatal log entries, from which the application cannot recover from

All of the above slots also have async implementation, starting out with `wait.`.

By default, this project will log into your `magic.log_entries` database/table, using either MySQL or
Microsoft SQL Server. This allows you to use SQL to generate statistics on top of your logs. An example of
logging an info piece of information can be found below.

```
log.info:Howdy world from magic.lambda.logging!
```

**Notice** - You can supply content to your log item two different ways. Either as a piece of string, or if you choose
to set its value to nothing, it will concatenate all children node's values, after having evaluated it as a lambda
collection. This allows you to create rich log entries, based upon evaluating the children of the log invocation.
This provides a convenient shortcut for you to create log entries that have as their content, strings concatenated
together, without having to manually concatenate them yourself.

An example of tha latter can be found below.

```
.a:foo bar
log.info
   .:'A value is '
   get-value:x:@.a
```

## License

Although most of Magic's source code is Open Source, you will need a license key to use it.
[You can obtain a license key here](https://servergardens.com/buy/).
Notice, 7 days after you put Magic into production, it will stop working, unless you have a valid
license for it.

* [Get licensed](https://servergardens.com/buy/)
