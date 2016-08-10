*********************************
Software product line engineering
*********************************

Software product line engineering (SPLE) provides an efficient means to
produce software that is delivered to multiple customers, in bespoke form,
derived from a composable, reusable set of assets. Effective use of SPLE can
reduce defects, costs, and time to market by a factor of 10 or more. SPLE is
desirable in small- to medium-sized enterprises, where a common occurrence is
the introduction of a one-off product that proves to be popular, and over time
requires multiple customer-specific versions. However, in its more traditional
form (the proactive approach, with a focus on the long-term up-front domain
engineering phase), SPLE is not always viable for SMEs. Agile product line
engineering (APLE), the combination of SPLE and agile software development, is
a reactive approach to facilitating SPLE in SMEs that can cut down the
long-term investment of the domain engineering phase.

.. _variability-model:

Variability model
=================
.. todo:: variability model



.. _binding-times:

Binding times
=============

The binding time is at which point the mechanism for distinguishing between
variants of a feature come into play. The binding time might be compile-time,
load-time or run-time.

An example of compile-time binding would be preprocessor directives, that
conditionally include or exclude code at the point of compiling the
application.

An example of a load-time binding implementation mechanism would be conditional
execution of code via paramaterisation, where the selected value of the
parameter is loading from a configuration file.

Run-time binding can take into account real-time changes in the context of the
application.



.. _artifact-dependencies:

Artifact dependencies
=====================

[Pohl2005]_ (p.83) 

.. todo:: artifacts dependencies


.. _sple-types-of-process:

Types of process
================

* Proactive

* Reactive

* Extractive

.. todo:: types of process



.. rubric: References
