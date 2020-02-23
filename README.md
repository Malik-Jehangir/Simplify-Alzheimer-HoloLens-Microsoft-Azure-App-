# Simplify - An Azure based Microsoft HoloLens Application for Alzheimer patients

It is a smart medical solution that helps with the diagnosis of the Alzheimer’s disease symptoms and
provide a better control over the progression of the disease. SIMPLIFY is unique since the use of modern
technology has made it possible to combine the previous approaches into one app. The solution can be
broken down into 3 parts.

1) The anti-saccade scene and head movement: It uses a HoloLens app containing a scene where user
is asked to look away. The number of time user makes a mistake by looking at the distracting objects,
the time consumed during this test and user information such as the age is saved.

2) SIMPLIFY. Machine Learning Webservice in Azure: The parameters from the HoloLens app is used to
generate the percentage risk of Alzheimer’s disease.

3) Power BI Report at doctor’s end: Finally, all above information including patient test parameters, the
Azure machine learning results are sent to Azure Table Storage and utilized by Power BI application
at the doctor’s end for data visualization in order to give the accurate consultancy to the patient if
needed.
