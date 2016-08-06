*********************************
Components of BDD and variability
*********************************

Gherkin
=======


As discussed in the section on :ref:`bdd-gherkin`, Gherkin
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

When introducing variability into Gherkin, we can make use of
some of the variability concepts described in :ref:`variability-concepts`.

* How do we :ref:`represent <variability-concepts-representation>` the variability within the Gherkin file?
* At what level of granularity do we allow for variability?
* Can we have abstract features with specification tests, on concrete features only?

Representation
--------------

An annotation-based approach involves marking up the Gherkin file in some way
with the feature the parts of the Gherkin file is associated with.  It also
requires a way of ensuring that the correct parts of the Gherkin specifications
are executed when the feature corresponding to a particular annotation are
selected in a product configuration.


Granularity
-----------

:ref:`Granularity <variability-concepts-granularity>` in the context of Gherkin refers to at what level elements of the
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


Step definition code
====================


Progress reports
================

Pickles
-------


