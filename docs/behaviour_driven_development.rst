.. _behaviour-driven-development:

****************************
Behaviour-driven development
****************************

Behaviour-driven development (BDD) is an agile software development methodology
focused on specifying and testing software through business-focused examples.


.. _gherkin:

Gherkin
=======

Gherkin is a business-readable DSL for specifying system behaviour.

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

Gherkin files describe a feature with a name and description.  These features
are broken down into scenarios, which are further broken down into
Given, When and Then steps.

There are many more components to a Gherkin feature file.  For more information
please see the `Gherkin reference <https://cucumber.io/docs/reference#gherkin>`_.
