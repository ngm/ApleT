.. ApleT documentation master file, created by
   sphinx-quickstart on Thu Jun  2 13:05:25 2016.
   You can adapt this file completely to your liking, but it should at least
   contain the root `toctree` directive.

Welcome to ApleT's documentation!
=================================

ApleT is a framework for performing agile product line engineering, particularly with
.NET web applications and a behaviour-driven development approach in mind.
ApleT follows the *feature-oriented software development* (FOSD) methodology.

ApleT is currently in very early stages of development.  See 
`django-productline <https://django-productline.readthedocs.io/en/latest>`_
for a much more mature FOSD framework for Django and Python.

Motivations
===========

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

Behaviour-driven development (BDD) is an agile software development methodology
focused on specifying and testing software through business-focused examples.
Through incorporating the concept of variability management, a core tenet of
SPLE, into behaviour-driven development, ApleT provides an agile approach to
product lines that provides automated, specification-based regression testing
across the entire product line. This approach enables the safe evolution of
product lines both in terms of requirements and in terms of architecture that
avoids big design up front.

FOSD is a particular approach to SPLE that focuses strongly on the idea of features
and their representation througout the entire software lifecycle.


Background
==========

.. toctree::
   :maxdepth: 2

   software_product_line_engineering
   behaviour_driven_development
   feature_oriented_software_development

Using ApleT
===========

.. toctree::
   :maxdepth: 2

   process
   toolchain
   roles

Indices and tables
==================

* :ref:`genindex`
* :ref:`modindex`
* :ref:`search`

