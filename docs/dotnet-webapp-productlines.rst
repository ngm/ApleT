.. _dotnet-aplet:

**********************************
.NET web application product lines
**********************************

This page is currently a general dumping ground for various
ways of implementing variability/feature-oriented development
when it comes to .NET web applications.

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

An extended ViewEngine can be written that allows for view overriding.  By
making use of partial views this allows overriding at quite a fine level of
granularity.

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
