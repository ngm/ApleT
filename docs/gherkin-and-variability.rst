**********************
Variability in Gherkin
**********************

As discussed in the section on :ref:`gherkin`, Gherkin
is a business-readable DSL for specifying system behaviour.

An example of feature specifications in a Gherkin feature file looks as 
follows (excellent ninja example from http://pythonhosted.org/behave/tutorial.html#feature-files):

.. code-block:: gherkin

    Feature: Fight or flight

    In order to increase the ninja survival rate,
    As a ninja commander
    I want my ninjas to decide whether to take on an opponent based on their skill levels

    Scenario: Weaker opponent
        Given the ninja has a third level black-belt
        When attacked by a samurai
        Then the ninja should engage the opponent

    Scenario: Stronger opponent
        Given the ninja has a third level black-belt
        When attacked by Chuck Norris
        Then the ninja should run for his life

When introducing variability into Gherkin, some questions that arise are:

* How do we represent the variability within the Gherkin file?
* At what level of granularity do we allow for variability?
* Can we have abstract features with specification tests, on concrete features only?

Representation
==============

There are different ways to represent variability within an artefact.
The two approaches used widely in practice are *annotation-based* and
*composition-based*.

Annotation-based approach
-------------------------

In the annotation-based approach, artefacts are marked up in some way
with annotations which determine what feature that part of the artefact
belongs to.

A very common example of this is code implementations is the use of 
preprocessor directives such as #ifdefs.

In the context of Gherkin, tags could potentially be used for annotation.

.. todo:: describe how annotation of Gherkin files would work.

Composition-based approach
--------------------------

In the composition-based approach, the parts of an artefact corresponding
to a particular feature are contained within a dedicated file, container or
module.

In code, there are various ways to achieve a composition-based approach, such
as design patterns, frameworks and plugins.

In the context of Gherkin, feature files could be composed by combining scenarios
and scenario steps.

.. todo:: more detail on composition-based approach for Gherkin.  

Granularity
===========

.. todo:: give generalised description of granularity.

Granularity in the context of Gherkin refers to at what level elements of the
Gherkin file we might wish to override or combine based on feature selections.

A course-grained granularity would mean we simply combine together full feature
files based on which features have been selected.

A finer-grained granularity would allow for the combination of variant scenarios
within an individual feature file.

An even finer-grain would allow the composition of individual scenario steps.

The most fine-grained level would be the arbitrary composition of any piece of
a feature file, including parts of the individual scenario step descriptions.
In practice this would be difficult.

.. todo:: give use cases/advice for when different levels of granularity might be required.


Implementing variability in Gherkin
===================================

Build system
------------

Using the build system approach, each feature in the feature model can have one associated feature file.
When a product is configured to include that feature, then the specification tests for that feature
are included by the build system copying that file into the correct directory from which the feature files
are run.

Implementation
^^^^^^^^^^^^^^

We need a way of linking the feature to the feature file.
And we need part of the build system to be able to copy the files to the correct
location based on this link.

The simplest link mechanism is having the name of the feature file match exactly the
name of the feature as gets included in the configuration file produced by the product
configurator.  Then the build script needs to just search for a file with that name and
output it to the correct directory.

.. todo:: show an example in FAKE

Considerations
^^^^^^^^^^^^^^

The granularity of this approach is at the feature level.  

.. todo:: More considerations here
.. todo:: Does every feature have a feature file?  Only concrete features perhaps?


Gherkin tags
------------


FeatureHouse
------------

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


Summary
-------

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
