# MVC Architecture for Unity
This package provides a template from that you can build on you project using the MVC pattern.

You can simply download the single [package file](Architecture.unitypackage) and drop it into your project to import everything you need without cloning the whole repository. 

## The MVC Pattern
The MVC (Model-View-Controller) pattern is an important pattern in software development. It allows for clear structuring of the project and thereby supports the development process. It divides the project into model, view, and controller classes, which fulfill the following general functions:

- **Model**: Classes serve the purpose of maintaining data, both dynamiclly and statically.
- **View**: Classes determine the behavior and appearance of everything the user sees.
- **Controller**: Classes contain the game logic and are responsible for the communication.

There are several ways to implement the MVC pattern in Unity. In my opinion, the best way to take advantage of this pattern is to have both the organization of the code and the organization of a scene within the Unity Editor follow the MVC pattern. Furthermore, it is important that communication between two elements of the project can be ensured without much configuration effort within the Unity Editor/Inspector. Manually setting references in the Inspector is both time-consuming and prone to errors. Especially across scenes in the case of scene changes or additive scenes, this can quickly lead to confusing solutions. For this reason, I have implemented a version of the MVC pattern that requires minimal configuration effort to allow global access to all views, controllers, and models of the project, regardless of whether the element to be accessed is in the same scene or not. I have oriented myself to the approach of [Eduardo Dias da Costa](https://www.toptal.com/unity-unity3d/unity-with-mvc-how-to-level-up-your-game-development), which, however, relies on the manual setting of references in the Inspector, the disadvantages of which I just listed.

## How to Use This Architecture
Every project requires an "Application Scene", which is always active and loaded first. This scene is already provided in the Scenes folder of the package. All other scenes of the application can then be loaded additively. The "Application Scene" thus provides the global area, which is available at all times during runtime. In the figure below you can see that the components of the "Application Scene" form the first two layer of the MVC hierarchy. Every element of this hierarchy will later accessed like:

```C#
App.Model.AND_SO_ON
App.View.AND_SO_ON
App.Controller.AND_SO_ON
```

Additionally globally used elements, such as a camera in the view, or application settings in the model, can be integrated into this scene. Therefore, this scene already contains Game Objects for Model, View, and Controller, which contain the corresponding template classes. If you decide against adding certain functionalities to this scene, you can remove the three game objects. Within this scene, no further action is needed in the future, apart from the functionalities you added.

For each scene of the Application, which provides some form of content, you can duplicate the *SceneTemplate* scene and then rename it. This scene now contains the forementioned three Game Objects. The classes that have been added as components to the three Game Objects can also be duplicated and renamed. These three classes are hereinafter referred to as Scene-MVC classes and differ from the rest of the Model, View, and Controller classes (hereinafter referred to as MVC classes) in the way that Scene-MVC classes inherit from the generic class *SceneArchitectureLayer*. The inheritance ensures that when the scene is loaded, the instances of these classes are referenced in first layer of the MVC hierarchy. All that needs to be done is to create a property according to the added class either in *ApplicationModel, -Controller, or -View*. It should preferably be limited to one class per scene and per MVC field in order to keep the classes of the first MVC hierarchy layer as clean as possible. If you just need less then three Scene-MVC classes you can simply delete the not needed Game Objects within the scene. There is then also no need to maintain the not used Scene-MVC classes und therefore you can delete them if you already created them. Furthermore there is no need to provide properties in the first layer for these classes. At the end you get a hierarchy like the one showed in the figure below.

All instances of MVC classes only exist as long as the scene is active. If you have an instance that should exist over the runtime of several existing scenes, an additional scene should be created whose Scene-MVC classes hold a reference to this instance and remain active even when the hierarchically considered underlying scenes change. This hierarchical organization of the scenes ensures that there are no MVC class instances in a scene that are needed outside the lifetime of this scene.

MVC classes are manually referenced in the inspector of the Scene-MVC classes or nested MVC classes. Manual referencing in the inspector at this level poses no problems, as manual referencing is reduced to adding local elements to the MVC hierarchy and thus no dependencies on other Game Objects within, or even outside a scene need to be considered. Elements do not need to be manually referenced to each other in any case, and thus there is only one reference in the Inspector for each element, which needs to be adjusted manually in the event of refactoring. All other changes during the refactoring take place within the code and are automated when using a suitable IDE. To perform the referencing step and thus integrate an MVC class from the second layer or lower into the MVC hierarchy, a field just needs to be added to the class directly above in the hierarchy.

Every element, whether it is part of the MVC hierarchy or not, can access this hierarchy by inheriting from *GameElement*. This abstract class has a reference to the root of the hierarchy and thus every element of the hierarchy can be reached like for example:

```C#
App.Model.SceneModel.MyModel.GiveMeSomeData();
```

However, when using this architecture, it is important to carefully consider when certain elements are available. At critical points, a null check should therefore be performed. Furthermore, it is recommended to use events, for example when a scene has finished loading, to carry out initializations that require access to the elements of the loaded scene. If you work carefully here, this architecture offers a high degree of flexibility and structured global access.

Here you can see an overview over an example using the MVC architecture. Check out the notes in the figure that explain some possible constelations. Additionally have a look into the code, where you can find some usefull comments.

![Architecture](https://github.com/19Chris98H/MVC_Architecture/assets/63323099/8bde7ff1-c022-4cee-863c-0d1a2899884a)

## Contact
As a developer, you never stop learning, so I welcome constructive criticism and am always open to suggestions for improvement. Feel free to contact me via [LinkedIn](https://www.linkedin.com/in/christian-h%C3%B6rath-0ba068201/) or by [email](mailto:hoerath.christian@gmail.com).
