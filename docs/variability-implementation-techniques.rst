.. _bdd-variability-implementation-techniques:

****************************************
Variability-awareness techniques for BDD
****************************************

In this section we discuss ways in which the components of BDD can be made
variability-aware.  There are a variety of ways to do it, with no silver bullet
that fits for all circumstances and contexts.  For example, while one approach
may be more sophisticated, it may simply have too much of a learning overhead
for a small project.  Hence we categorise and evaluate each approach against
the quality criteria to enable informed decisions to be made.  

With all approaches we make the assumption that we wish to avoid, as much as we
can, overloading existing Gherkin language constructs.  The existing keywords
and structures should keep the same function as they have for single-system
engineering, and we should add variability-awareness to Gherkin without
confusing what these single-system concepts mean.  The exception to this is the
tags concept -- which is a very open and general-purpose concept in Gherkin, so
nothing is lost or confused by using tags for variability purposes.

We refer back to the :ref:`quality criteria <variability-concepts-qualitycriteria>`
discussed earlier.

In the interests of the uniformity criteria, we take inspiration from the
various mechanisms defined for code implementation, and see how they may
apply to specs and to test artifacts.


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

A simple annotation-based approach is to tag each feature file or scenario
with the name of the customer(s) to which it applies.

.. code-block:: gherkin

    Feature: Add Todo

    @customer1 @customer2
    Scenario: User adds valid todo
        Given the user has input the label 'Take over the world'
        When the user submits the todo
        Then the todo should be added to the user's todolist

    @customer2
    Scenario: User adds a todo with a description
        Given the user has input the label 'Take over the world'
        And the user has input the description 'Same thing we do every night'
        When the user submits the todo
        Then the todo should be added to the user's todolist

    @customer1 @customer2
    Scenario: User adds invalid todo
        Given the user has left the label blank
        When the user submits the todo
        Then the user should prompted to add a label

This simplifies the running of the tests from the build scripts.
We only need to pass the product/customer name as a filter to the tests, and 
the test runner will run only the scenarios that apply to this product/customer.

With this approach, all variability is contained implicitly within the 
feature files.  There is no explicit representation of variability in a 
variability model.  Any configuration of the product line for a particular
customer means going through each feature file and tagging the features and
scenarios that apply for the new customer.

Note that as tagging an entire feature means that all scenarios are also
tagged with the same tag, we must only tag at the scenario level.

At the Gherkin-level, variability by control flow and variability by data can
only be achieved by duplicating scenarios.  At the step definition level,
step definitions are reusable between scenarios through parameterisation.

c.f. PLUC

Categorisation
--------------

* Annotation-based
* Language-based

Quality criteria
----------------

+-------------------------------------+--------+----------------------------------------------+
| Criteria                            | Rating | Notes                                        |
+=====================================+========+==============================================+
| *Preplanning effort*                | Good   | We don't need to think much about            |
|                                     |        | variability in advance. If a new feature     |
|                                     |        | comes along, we tag it with all the          |
|                                     |        | customers that it applies to.                |
+-------------------------------------+--------+----------------------------------------------+
| *Feature traceability*              | Poor   | If scenarios from multiple feature files are |
|                                     |        | related to one particular feature in the     |
|                                     |        | feature model, there is no simple way of     |
|                                     |        | determining that they all relate to one      |
|                                     |        | feature.                                     |
+-------------------------------------+--------+----------------------------------------------+
| *Separation of concerns*            | Poor   | Feature files contain all variants.          |
|                                     |        | Variability concerns are hardcoded into the  |
|                                     |        | feature files.                               |
+-------------------------------------+--------+----------------------------------------------+
| *Information hiding*                | ...    |                                              |
+-------------------------------------+--------+----------------------------------------------+
| *Granularity/variability-awareness* | Poor   | We can only select at the scenario- level.   |
|                                     |        | Only variability by function is possible     |
|                                     |        | without duplication.                         |
+-------------------------------------+--------+----------------------------------------------+
| *Uniformity*                        | Poor   | There is no effect on step definition code.  |
|                                     |        | It is all included, and selected for by the  |
|                                     |        | selection of scenarios at the Gherkin-level. |
+-------------------------------------+--------+----------------------------------------------+
| *Learning effort*                   | Good   | No changes to Gherkin.  Simply requires      |
|                                     |        | tagging scenarios with the customers to      |
|                                     |        | which they apply.                            |
+-------------------------------------+--------+----------------------------------------------+
| *Overhead*                          | Poor   | There is duplication of scenarios. When a    |
|                                     |        | new product/customer is added, we have to    |
|                                     |        | manually amend all the feature files to tag  |
|                                     |        | the scenarios we should be including in      |
|                                     |        | their requirements and their tests.          |
+-------------------------------------+--------+----------------------------------------------+




Annotation by feature
=====================

An alternative annotation-based approach is to tag features/scenarios
with the corresponding name of the feature from the variability model.

.. code-block:: gherkin

    @add_todo
    Feature: Add Todo

    Scenario: User adds valid todo
        Given the user has input the label 'Take over the world'
        When the user submits the todo
        Then the todo should be added to the user's todolist

    @todo_description
    Scenario: User adds a todo with a description
        Given the user has input the label 'Take over the world'
        And the user has input the description 'Same thing we do every night'
        When the user submits the todo
        Then the todo should be added to the user's todolist

    Scenario: User adds invalid todo
        Given the user has left the label blank
        When the user submits the todo
        Then the user should prompted to add a label

Variability itself has now been moved away from the feature files
themselves, and can be modelled and configured using a dedicated 
feature modelling tool.

In order to run the tests for a particular product configuration, we
filter the test runner by the names of the selected features from the
feature model.

Note that without introducing new constructs and corresponding tooling, the
tagging approach only affords us variability-awareness for variability by
function.  

.. todo:: Discuss Scenario Outlines with respect to variability by data

It would be possible to do so allow variability by control flow, or
variability by data with new tag constructs and amendments to Gherkin.  For
example:

.. code-block:: gherkin

    Scenario: User adds valid todo
        Given the user has input the label '<<<LABEL>>>'
        @todo_description 
        And the user has input the description '<<<DESCRIPTION>>>'
        When the user submits the todo
        Then the todo should be added to the user's todolist

But this would require introducing new ways in which to mark up Gherkin files
which is something we would like to avoid, where possible.

c.f. PLUSS [Eriksson2005]_


Quality criteria
----------------

+-------------------------------------+---------+----------------------------------------------+
| Criteria                            | Rating  | Notes                                        |
+=====================================+=========+==============================================+
| *Preplanning effort*                | Good    |                                              |
+-------------------------------------+---------+----------------------------------------------+
| *Feature traceability*              | Poor    |                                              |
+-------------------------------------+---------+----------------------------------------------+
| *Separation of concerns*            | Poor    | Feature files contain all variants.          |
|                                     |         | Variability concerns are hardcoded into the  |
|                                     |         | feature files.                               |
+-------------------------------------+---------+----------------------------------------------+
| *Information hiding*                | ...     |                                              |
+-------------------------------------+---------+----------------------------------------------+
| *Granularity/variability-awareness* | Poor    | We can only select at the scenario- level.   |
|                                     |         | Only variability by function is possible     |
|                                     |         | without duplication.                         |
+-------------------------------------+---------+----------------------------------------------+
| *Uniformity*                        | Poor    | There is no effect on step definition code.  |
|                                     |         | It is all included, and selected for by the  |
|                                     |         | selection of scenarios at the Gherkin-level. |
+-------------------------------------+---------+----------------------------------------------+
| *Learning effort*                   | Good    | No changes to Gherkin.  Simply requires      |
|                                     |         | tagging scenarios with the customers to      |
|                                     |         | which they apply.                            |
+-------------------------------------+---------+----------------------------------------------+
| *Overhead*                          | Neutral | There is duplication of scenarios.           |
+-------------------------------------+---------+----------------------------------------------+


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

.. code-block:: gherkin
    :caption: `AddTodo.feature` in AddTodo feature module

    Feature: Add Todo

    Scenario: User adds valid todo
        Given the user has input the label 'Take over the world'
        When the user submits the todo
        Then the todo should be added to the user's todolist

    Scenario: User adds invalid todo
        Given the user has left the label blank
        When the user submits the todo
        Then the user should prompted to add a label

.. code-block:: gherkin
    :caption: `AddTodo.feature` in TodoDescription feature module

    Feature: Add Todo

    Scenario: User adds a todo with a description
        Given the user has input the label 'Take over the world'
        And the user has input the description 'Same thing we do every night'
        When the user submits the todo
        Then the todo should be added to the user's todolist

.. todo:: Add diagrams of how the feature modules would look like

Thus, if a product configuration includes the `AddTodo` and `TodoDescription`
features, FeatureHouse will merge these two feature files into one that contains
the scenarios to be tested against that product configuration.

In terms of running the tests, the product-specific feature files are output 
into one directory for that specific product.  The test runner just needs to
be pointed at this directory to find the tests for the customer.  No tag filtering
is required.

As it stands, this only makes the feature files variability-aware in the sense
of variability by function.  Variability by control flow or variability by data
can be achieved by duplication of test artifacts.


Modeling scenario variability as crosscutting mechanisms
========================================================

c.f. MSVCM [Bonifacio2009]_.

The aspect-oriented approach provides a compositional approach with which to
make the feature files variability-aware in terms of variability by control
flow.

It enables adding arbitrary scenario steps before and after existing scenario
steps.

.. todo:: Describe differences between homogenous and heterogenous crosscutting concerns.


Aspectual feature modules
=========================

A combination of the feature module and aspect-oriented approaches.

The combination allows variability-awareness in terms of variability by function,
variability by control flow, and variability by data.


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

As far as ApleT goes, we would recommend starting out with
something that has a low preplanning effort, low overhead,
and low learning effort.  Then refactoring towards
more advanced techniques.  

We would recommend avoiding clone-and-own by version
control unless you are already doing it, or it
is desirable for some other reason (organisationl issues
say).  We'd recommend starting with annotation by feature,
although this does require somewhere recording feature
configurations for each customers (this doesn't necessarily
have to be through a feature modelling tool, however, it
could simply be manually maintained text files.)












.. rubric:: References

.. [Bonifacio2009] Bonifácio, R. and Borba, P. (2009). Modeling scenario variability as crosscutting mechanisms. In Proceedings of the 8th ACM international conference on Aspect-oriented software development (AOSD '09). ACM, New York, NY, USA, 125-136. DOI=http://dx.doi.org/10.1145/1509239.1509258
.. [Eriksson2005] Eriksson, M., Börstler, J, and Borg, K. (2005). The PLUSS approach: domain modeling with features, use cases and use case realizations. In Proceedings of the 9th international conference on Software Product Lines (SPLC'05), Henk Obbink and Klaus Pohl (Eds.). Springer-Verlag, Berlin, Heidelberg, 33-44. DOI=http://dx.doi.org/10.1007/11554844_5
