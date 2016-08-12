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
form (the `proactive <sple-types-of-approach>` approach, with a focus on the long-term up-front domain
engineering phase), SPLE is not always viable for SMEs. Agile product line
engineering (APLE), the combination of SPLE and agile software development, is
a reactive approach to facilitating SPLE in SMEs that can cut down the
long-term investment of the domain engineering phase.

----

Overview
========

Software product line engineering (SPLE) is a systematic approach to achieving
software reuse. The main goal of SPLE is to enable software vendors to
efficiently tailor software products to the requirements of individual
customers[Apel2013]. It aims to minimise the overheads incurred when building a
family of software products that have significant shared features, yet various
differences. SPLE and its reuse-oriented methodology has many advantages, both
financial and technical, and a number of industrial case studies document the
successes it can bring [Linden2007]_ [SoftwareEngineeringInstitute]_. 

Hand-crafting vs mass customization
-----------------------------------

The analogy from which SPLE takes its name is that of product lines in
manufacturing, such as those found in the automobile industry. Before the
advent of mass production in traditional manufacturing, goods were hand-crafted
-- each item was produced individually, in a time-consuming and labour
intensive manner, but nonetheless one that allowed for individual tailoring.
The onset of industrialisation brought with it mass production -- whereby,
through standardization of parts and processes, the time-to-market of an
individual product was greatly reduced. This came with a loss of customisation,
however. To overcome this, the idea of mass customization was introduced.
Through the intelligent use of reusable core components and points where
variations can be introduced, a wider portfolio of products can be produced
while still reaping the benefits of mass production. In this context, a product
line is a family of related products that can be built from reusable parts, and
which have many commonalities with some variabilities between them.

A similar history of early hand-crafting, followed by a move to mass
production, followed by the need for mass customization, can be seen in
software development. Software was originally hand-crafted to companies and to
hardware. As the demand for computers grew, standard software was produced that
could run on multiple architectures, which as with manufactoring reduced the
temporal and financial overheads of bespoke tailoring. The parallel of the need
for mass customization arises, however, with customers either unable or
undesiring to run exactly the same software. Efficiently produced, but
individually customised, software was required. SPLE is the field of research
and practice that has grown to meet that requirement.

SPLE history
------------

The idea of software product families was first documented by Parnas
[Parnas1976]_. SPLE has been researched in increasing depth over the past two
decades. Its use in industry has also increased, beginning with larger
businesses such as Boeing, Hewlett-Packard, and LG, and latterly making inroads
into smaller enterprises [Pohl2005]_. It is by no means only for commercial usage --
the open-source Linux kernel, for example, which must run on a vast array of
hardwares and architectures, is one of the largest software product lines in
existence. 

Benefits
--------

The key benefits of SPLE are the reduced cost of new products, the reduced time
to market of new products, the improved quality of products, and the
facilitation of bespoke software. There are overheads associated with SPLE,
however, which include the cost of the initial planning of the product line,
and the extra complexity required in managing variability. These overheads, in
combination with its relative newness, mean SPLE is not yet in widespread use
in small- to medium-sized enterprises (SMEs) [Laguna2009]_. Efforts
exist to bring the benefits of SPLE to companies less able to accomodate its
large up-front analysis times [Krueger2002a]_ [Ghanam2009]_ [McGregor2008]_.


Variability management
======================

.. _variability-model:

Variability model
-----------------
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
