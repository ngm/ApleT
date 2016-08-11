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


.. _sple-process:
SPLE Process
============

SPLE is commonly split into *domain engineering* and *application engineering*.
A traditional process model for SPLE [Apel2013]_ breaks the work into a two
dimensional space, with problem space and solution space making up one axis,
and domain engineering and application engineering making up the other, and
with four main clusters of tasks in traditional SPLE are:

* Domain analysis - this is requirements engineering for an entire product
  line.  The results of domain analysis are often documented in a `feature
  model <feature-model>`.

* Requirements analysis - the needs of a specific customer as part of
  application engineering

* Domain implementation - developing reusable artifacts that correspond to the
  features identified in domain analysis

* Product derivation - the production step of application engineering, where
  reusable artifacts are combined according to the results of requiement


.. _sple-types-of-process:
Types of process
----------------

There are three broad ways in which an organisation can undertake product
line engineering: these are the *proactive*, *extractive*, and *reactive* approaches 
[Krueger2002a]_.

* Proactive: The proactive approach is the more traditional approach to SPLE,
  where complete domain analysis and variability management is performed in
  advance of any application engineering.  In many small- to medium-sized
  enterprises the large upfront costs of this approach mean it is not viable
  [Buhrdorf2004]_.

* Reactive: In contrast, the reactive approach involves creating and updating
  the product line as and when new members of the family appear.  Extensive
  domain analysis is avoided, and time can be saved.  

* Extractive: The extractive approach involves bootstrapping a product line by
  taking existing products as the base for the core assets.  
  
The extractive and reactive approaches can be used together.



.. todo:: types of process



.. rubric: References
