.. _bdd:

****************************
Behaviour-driven development
****************************

Behaviour-driven development (BDD) is an agile software development methodology
focused on specifying and testing software through business-focused examples.


.. _bdd-gherkin:

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



.. _bdd-step-definitions:

Step definition code
====================

Step definition code is a layer of code that is automatically executed when the specification
tests are run.

Each individual step maps to a method within the step definition code.  When a scenario within
a feature that contains the corresponding step for the step definition is run, this will execute
the method within the step definition code.

.. code-block:: csharp

        [Given("the ninja has a third level black-belt")]
        public void GivenTheNinjaHasAThirdLevelBlackBelt()
        {
                // ...
        }

        [When("attacked by a samurai")]
        public void WhenAttackedByASamuari()
        {
                // ...
        }

        [Then("the ninja should engage the opponent")]
        public void ThenNinjaShouldEngageOpponent()
        {
                // ...
        }


Progress reports
================

When specification tests are run, progress reports are produced.  These reports show
the status of the implementation of the features within the product.

.. todo:: image of progress report

.. todo:: pickles
