****************************************
Variability-awareness techniques for BDD
****************************************


Build system
============

Using the build system approach, each feature in the feature model can have one associated feature file.
When a product is configured to include that feature, then the specification tests for that feature
are included by the build system copying that file into the correct directory from which the feature files
are run.

Implementation
--------------

We need a way of linking the feature to the feature file.
And we need part of the build system to be able to copy the files to the correct
location based on this link.

The simplest link mechanism is having the name of the feature file match exactly the
name of the feature as gets included in the configuration file produced by the product
configurator.  Then the build script needs to just search for a file with that name and
output it to the correct directory.

.. todo:: show an example in FAKE

Considerations
--------------

The granularity of this approach is at the feature level.  

.. todo:: More considerations here
.. todo:: Does every feature have a feature file?  Only concrete features perhaps?

Annotation by product
=====================

c.f. PLUC

Annotation by feature
=====================

c.f. PLUSS [Eriksson2005]_

Feature module composition
==========================

`FeatureHouse <http://fosd.net/fh>`_ is a tool that can be used for the composition of various
types of software artifacts.  It allows for the artifacts to be structured in
feature modules as part of feature-oriented software development.

.. epigraph::
    "FeatureHouse is a general approach to the composition of software
    artifacts. FeatureHouse is language-independent in that software artifacts
    written in various languages can be composed, e.g., source code, test
    cases, models, documentation, and makefiles. Software artifacts are
    represented as feature structure trees (FSTs), which capture the essence of
    an artifact's modular structure in the form of a tree. As composition
    paradigm, FeatureHouse supports two approaches: superimposition and
    three-way merge. FeatureHouse consists of a tool for superimposition,
    called FSTComposer, a tool for three-way merge, called FSTMerge, and a
    plug-in and generation mechanism for integrating new languages
    automatically, called FSTGenerator." 
    
    -- http://fosd.net/fh

To enable Gherkin for usage within FeatureHouse we are implementing a 
*feature structure tree* grammar for Gherkin files.


Modeling scenario variability as crosscutting mechanisms
========================================================

`An aspect-oriented approach to variability in use case scenarios <http://dl.acm.org/citation.cfm?id=1509239.1509258>`_ [Bonifacio2009]_.


Aspectual feature modules
=========================

A combination of the feature module and aspect-oriented approaches.


Summary
=======

The table below summarises different approaches to implementing variability in Gherkin
based on various quality criteria.

+------------------+--------------+-------------------+--------------------------------------------------+
|                  | Build system | Gherkin tags      | FeatureHouse                                     |
+==================+==============+===================+==================================================+
| *Mechanism*      | Annotation   | Annotation        | Composition                                      |
+------------------+--------------+-------------------+--------------------------------------------------+
| *Granularity*    | Feature      | Feature, scenario | Feature, scenario, scenario step                 |
+------------------+--------------+-------------------+--------------------------------------------------+
| *Learning curve* | Simple       | Simple            | Understanding feature module packaging mechanism |
+------------------+--------------+-------------------+--------------------------------------------------+


.. rubric:: References

.. [Bonifacio2009] Bonifácio, R. and Borba, P. (2009). Modeling scenario variability as crosscutting mechanisms. In Proceedings of the 8th ACM international conference on Aspect-oriented software development (AOSD '09). ACM, New York, NY, USA, 125-136. DOI=http://dx.doi.org/10.1145/1509239.1509258
.. [Eriksson2005] Eriksson, M., Börstler, J, and Borg, K. (2005). The PLUSS approach: domain modeling with features, use cases and use case realizations. In Proceedings of the 9th international conference on Software Product Lines (SPLC'05), Henk Obbink and Klaus Pohl (Eds.). Springer-Verlag, Berlin, Heidelberg, 33-44. DOI=http://dx.doi.org/10.1007/11554844_5
