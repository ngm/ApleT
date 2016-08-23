.. _dotnet-aplet:

**********************************
.NET web application product lines
**********************************

This page is currently a general dumping ground for various
ways of implementing variability/feature-oriented development
when it comes to .NET web applications.

* http://marisks.net/2016/02/16/feature-folders-vs-tech-folders/
* http://timgthomas.com/2013/10/feature-folders-in-asp-net-mvc/
* http://timgthomas.com/2013/10/feature-folders-and-javascript/
* http://maxtoroq.github.io/2013/02/aspnet-mvc-workflow-per-controller.html
* http://stackoverflow.com/a/1528571
* https://github.com/T4MVC/T4MVC/wiki/Documentation#251-alternative-feature-folder-project-structure
* http://www.chwe.at/2014/04/introducing-the-asp.net-mvc-feature-folders-project-structure/
* https://spin.atomicobject.com/2015/11/18/feature-oriented-c-sharp-structure/

* http://codeofrob.com/entries/multi-tenancy-in-asp.net-mvc---why-do-we-want-it.html
* http://codeofrob.com/entries/multi-tenancy-in-asp.net-mvc---breaking-it-down.html
* http://www.codeproject.com/Articles/842961/Introducing-Dynamic-Bundles-for-ASP-NET-MVC
* https://github.com/achingono/Enfold
* https://github.com/saaskit/saaskit
* https://github.com/joeaudette/cloudscribe
* http://www.aspnetboilerplate.com/Pages/Documents/Multi-Tenancy#multi-tenancy-in-aspnet-boilerplate
* https://github.com/aspnet/Home/issues/973


What needs composing in an ASP.NET MVC web application?
=======================================================

* Controllers
* Routing
* View Models
* View Templates
* JavaScript
* CSS
* Static files
* web.config

Controllers
-----------

Controllers are C# code so can make use of the standard mechanisms - 
#ifdefs, parameterisation, design patterns.  If we were to use feature-oriented
composition FeatureHouse C# composition could potentially be used.

Routing
-------

Action methods on controllers can be attributed with routes, and the routing engine
picks them up from there, so it could be that composing controllers takes care of
composing routing.

View Models
-----------

As for controllers.

View Templates
--------------

One simple approach is extended ViewEngine that allows for view overriding.  By
making use of partial views this allows overriding at quite a fine level of
granularity.

Note that the folder structure here has it broken down by customer/product.
For branding concerns, we have to really think of branding as a feature variant
that only applies to one customer.  So where the alternate views are for
branding concerns, it's OK to have them separated out essentially 'by product'.

In the case of views being required only for a particular functional feature,
we might have a single view engine that searches for views in feature modules, or
we could even experiment with a view engine being bundled with every feature and
added to the collection of ViewEngines at application startup, based on product
configuration.

* http://lonetechie.com/2012/09/25/multi-tenant-architecture-with-asp-net-mvc-4/
* http://codeofrob.com/entries/multi-tenancy-in-asp.net-mvc---views.html

JavaScript
----------

https://github.com/henzk/featuremonkey.js

CSS
---

CSS is composable by simple concatenation.

Static files
------------

...

web.config
----------

Web.config transforms in Visual Studio can deal with some composition of 
configuration options.  It's limited though in that you can only have
overriding configs per build configuration and per publish profile.  There's
no real way to separate this out by feature.

ASP.NET MVC Areas
=================

Areas provide a means for separating an application up into distinct areas.
It's intended more for large subsections of an application however, so not
at the fine-grained level of features.

ASP.NET MVC Portable Areas
==========================

https://lostechies.com/erichexter/2012/11/26/portable-areas-3-years-later/

FubuMVC bottles
===============

FubuMVC's bottles were a way to package up code, web endpoints and views in a
single place that could be reused in web applications.

I never worked with it, and I don't know how it went about composing different
artefacts (it seems to be runtime composition?), but it seems to have definite 
similarities with the idea of feature modules in FOSD.  

https://lostechies.com/josharnold/2011/09/05/modularity-via-bottles/

OrchardCMS
==========

Orchard builds on top of ASP.NET MVC and has the idea of extensibility via
modules built into it from the ground up.

Behind the scenes, Orchard modules are built on top of the ASP.NET MVC Areas
mechanism.

http://docs.orchardproject.net/en/latest/Documentation/How-Orchard-works/
