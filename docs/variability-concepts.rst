.. _variability-concepts:

***********************************************
Categorising ways to make BDD variability-aware
***********************************************

This section introduces some ideas and terminology related to variability
implementation mechanisms, with a focus on requirements artifacts and test
artifacts.  With these terms we can categorise and evaluate different
mechanisms.

----

The FOSD book describes three main dimensions of variability mechanisms:
binding time, representation, and technology, and quality criteria that
can be used to evaluate a variability mechanism.

Variability implementation dimensions
=====================================


.. _variability-concepts-representation:

Representation
--------------

There are different ways to represent variability within an artefact.
The two approaches used widely in practice are *annotation-based* and
*composition-based*.

Annotation-based approach
^^^^^^^^^^^^^^^^^^^^^^^^^

In the annotation-based approach, artefacts are marked up in some way
with annotations which determine what feature that part of the artefact
belongs to.

A very common example of this is code implementations is the use of 
preprocessor directives such as #ifdefs.

In the context of Gherkin, tags could potentially be used for annotation.

Composition-based approach
^^^^^^^^^^^^^^^^^^^^^^^^^^

In the composition-based approach, the parts of an artefact corresponding
to a particular feature are contained within a dedicated file, container or
module.

In code, there are various ways to achieve a composition-based approach, such
as design patterns, frameworks and plugins.


.. _variability-concepts-technology:

Technology
----------

The two main types of technologies available for variability implementations are
language-based versus tool-based.


.. _variability-concepts-binding:

Binding times
-------------

The binding time is at which point the mechanism for distinguishing between variants
of a feature come into play.  The binding time might be compile-time, load-time or
run-time.

An example of compile-time binding would be preprocessor directives, that conditionally
include or exclude code at the point of compiling the application.

An example of a load-time binding implementation mechanism would be conditional execution
of code via paramaterisation, where the selected value of the parameter is loading from
a configuration file.

Run-time binding can take into account real-time changes in the context of the application.





.. _variability-concepts-qualitycriteria:

Quality Criteria
================

Quality criteria give us a framework to discuss different ways
of making artifacts variability-aware.  There's no silver bullet
approach that fits all situations, so it's good to have a way to
talk about the different options.

The FOSD book [Apel2013]_ defines 6 quality criteria for evaluating
mechanisms for variability-awareness.

Preplanning effort
------------------

Preplanning effort is how much in advance you have to think about variability
concerns.  This is especially relevant in an agile context (:ref:`reactive
<sple-types-of-process>` in SPLE terms), where we don't want too much of a
big-design up front domain engineering phase.  For our first customer, we're
unlikely to want to put too much time into variability points for other
customers.  We'd like to be able to incorporate that variability
in, as and when it comes, relatively easily, without much reengineering.
In BDD terms, we would like to avoid having to do too much work with our 
first customer in order to add variability to the feature specs when it
arises.

Feature traceability
--------------------

Feature traceability describes how easily we can figure out what software
artifacts contribute towards a given feature.  If the code for a feature is
scattered across many files, it makes it harder to reason about what code is
implementing that feature.  Likewise for other artifacts.  In BDD terms, its
unlikely we would get too much scattering across feature specs for a feature on
the variability model.

Separation of concerns
----------------------

In the context of variability, separation of concerns refers to how cohesive
artifacts are in terms of which feature they relate to.  If say a code file
is full of references to lots of different features, it makes it more difficult
to reason about, and to safely make changes to that file just a given feature.
We can also say that the artifact is tangled.  In BDD, it is unlikely that
a feature spec will contain parts related to multiple features (although it
is possible with e.g. crosscutting concerns.)

.. todo:: Reference bonafacia here.

Information hiding
------------------

.. _variability-concepts-granularity:

Granularity
-----------

Granularity refers to the structural level at which the 
variability mechanism can efficiently reuse parts of an artifact.
For example, in code, maybe the mechanism can conditionally 
include/exclude/replace at the class-level, or at the method-level.
Or if the mechanism is very fine-grained it might be able to 
conditionally include/exclude/replace at the statement level.
In terms of BDD we can think of supporting include/exclude/replace
of a full feature spec file, or at the scenario level, or at the
scenario step level.

Another way of thinking about granularity is as to how well the
mechanism supports different types of variability: variability in function, variability
in control flow, and variability in data [Bachmann]_.  It's important
to note that we can always support variability through duplication and
amendment, but what we want to achieve is variability through efficient
reuse.

Uniformity
----------

Uniformity refers to how well the variability mechanism works
across all artifacts in the lifecycle.  If we use one mechanism
for requirements, another for code, another for tests, this is
going to be difficult to maintain.

As this relates to BDD, we investigate mechanisms that have
been defined for code implementation and see how they apply
to specs and tests.

----

The SPLE book [Pohl2005]_ provides some other quality criteria within
its section on product line testing strategies.

Learning effort
---------------

How easy is it to actually understand and use the mechanism?
For example, tool support helps here.

.. todo:: more on this

Overhead
--------

Are they any unnecessary overheads associated with the mechanism
that we might wish to avoid.

.. todo:: more on this

.. todo:: weighting of the importance of the criteria with
    regards to agile and BDD
