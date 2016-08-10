.. _variability-linking-features-to-bdd:

**********************************************
Linking feature model features to BDD features
**********************************************

We need to discuss the different ways in which we might map between features on
a :ref:`variability model <variability-model>`, and features as we have them in BDD.

First of all, we need to define what we mean by both.

The word feature is a nebulous term that has been given many definitions. Here
we use the definition from [Apel2013]_: *a feature is a characteristic or
end-user-visible behavior of a software system*. This definition fits well with
the notion of behaviour-driven development. However, we must define a key
distinction between the features of a variability model (we'll call these VM features)
and the features within BDD (BDD features). 

In ApleT, BDD features are :ref:`artifact dependencies <artifact-dependencies>` 
of VM features. The role of the variability model is to define variability, and the
role of the BDD features is to define expected behaviour. As we would not
expect the VM to contain features for every code artifact (e.g. classes and
methods), we should not expect the VM to contain a feature for every possible
test artifact. That is to say, each VM feature can map to one or more BDD
artifacts. We must define at what granularity this mapping occurs. Intuitively,
based on nomenclature alone, we may feel that there is a one-to-one mapping
between VM and BDD features. However, we do not wish to have a full BDD feature
file for each VM feature. In the simplest case we could do this if required -
but this may mean duplication of BDD test artifacts. (For example, for two
variants of control flow, we would need a complete BDD feature file.) The less
variability-awareness we have in our test artifacts, the higher the level of
granularity we must fix our artifact dependencies.

There could, for example, be a 1-to-1 correspondence between a FM feature and a
BDD feature. This, however, would lose the fidelity of variability within a BDD
feature. Selecting variants of FM features would select different BDD features.
Our test artifacts would not be variability-aware by control flow or by data.
To vary these aspects, we would need to clone-and-own scenarios and steps. To
enable variability by control flow without test artifact duplication, we must
have VM features map to scenario steps selections. To enable variability by
data without test artifact duplication, we must have variants map to BDD data
selections - if it is discrete paramerisation then through alternative
features, it parameterisation of continuous values then through some other
mechanism such as feature attributes. 

“We accomplish this by relating use cases, use case scenarios and use case
scenario steps to features of appropriate types in a feature model”
[Eriksson2006]_

The PLUSS approach provides advice on mapping use cases to features
[Eriksson2005]_. One or more use cases can map to a feature. One or more
scenarios can map to a feature. One or more can relate to any
feature on the feature model. Cross-cutting aspects are modeled as use case
parameters, which are mapping to alternatives? For BDD, these corresponds to a
VM feature having one or more BDD features linked to it, or a
feature having one or more scenarios linked to it, or a feature having one or
more steps linked to it. 

[Ghanam]_ recommends that only leaf nodes are linked to EATs. A leaf node can
have multiple EAT nodes. Each EAT node links to one test artifact. Ghanam
recommends the test artifact of choice to be the test page (similar to the
Feature level of BDD.) So we're basically saying that a feature can have
multiple test artifacts linked to it. Ghanam doesn't really say how to actually
make the test artifacts variability aware.

.. todo:: Diagrams of how they map

