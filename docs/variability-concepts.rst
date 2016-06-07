.. _variability-concepts:

********************
Variability concepts
********************

The FOSD book describes three main dimensions of variability mechanisms:
binding time, representation, and technology, and quality criteria that
can be used to evaluation a variability mechanism.

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


.. _variability-concepts-granularity:

Granularity
-----------
