Scene/Entity/Component System
==========

Most of Nez revolves around an Entity-Component system (ECS). The Nez ECS is not unlike any other ECS you may have worked with so it should be instantly familiar.


## Scene
The root of the ECS. Scenes can be thought of as the different parts of your game such as the menu, levels, credits, etc. Scenes manage a list of Entities, Renderers and PostProcessors (via add/remove methods) and call their methods at the appropriate times. You can also use the Scene to locate Entities via the **findEntity** and **findEntitiesByTag** methods. Scenes are also created with a Camera that you can choose to use or not.

Scene's provide a NezContentManager (Scene.contentManager) that you can use to load up scene-specific content. When the scene is finished the content will be unloaded automatically for you. If you need to load global content (anything that would be used by several scenes) you can use the Core.contentManager which is not ever explicitly unloaded.

Nez provides several different ways to get your final scene rendered flexibly and efficiently. It uses a concept called `SceneResolutionPolicy` to manage how things are rendered. The `SceneResolutionPolicy` along with the design time width/height that you set decides what size the RenderTarget2D should be and how it changes when the window size changes. Several SceneResolutionPolicys also include pixel perfect variants for use with pixal art games. Pixel perfect variants may end up with letter/pillar boxing which you can control via the **Scene.letterboxColor**. You can set the default `SceneResolutionPolicy` used for all scenes by calling **Scene.setDefaultDesignResolution**. The included SceneResolutionPolicys are below:

- **None**: Default. RenderTarget2D matches the sceen size
- **ExactFit**: The entire application is visible in the specified area without trying to preserve the original aspect ratio. Distortion can occur, and the application may appear stretched or compressed.
- **NoBorder**: The entire application fills the specified area, without distortion but possibly with some cropping, while maintaining the original aspect ratio of the application.
- **NoBorderPixelPerfect**: Pixel perfect version of NoBorder. Scaling is limited to integer values.
- **ShowAll**: The entire application is visible in the specified area without distortion while maintaining the original aspect ratio of the application. Borders can appear on two sides of the application.
- **ShowAllPixelPerfect**: Pixel perfect version of ShowAll. Scaling is limited to integer values.
- **FixedHeight**: The application takes the height of the design resolution size and modifies the width of the internal canvas so that it fits the aspect ratio of the device. no distortion will occur however you must make sure your application works on different aspect ratios
- **FixedHeightPixelPerfect**: Pixel perfect version of FixedHeight. Scaling is limited to integer values.
- **FixedWidth**: The application takes the width of the design resolution size and modifies the height of the internal canvas so that it fits the aspect ratio of the device. no distortion will occur however you must make sure your application works on different aspect ratios
- **FixedWidthPixelPerfect**: Pixel perfect version of FixedWidth. Scaling is limited to integer values.


## Entity
Entities are added/removed to/from the Scene and managed by it. You can either subclass Entity or just create an Entity instance and add any required Components to it (via **addComponent** and later retrieved via **getComponent**). On their most basic level Entities can be thought of as a container for Components. Entities have a series of methods that are called by the Scene at various times throughout their lifetime.

Entity Lifecycle methods:

- **onAddedToScene**: Called when the entity is added to a scene after all pending entity changes are committed
- **onRemovedFromScene**: Called when the entity is removed from a scene
- **update**: called each frame as long as the Entity is enabled
- **debugRender**: called if Core.debugRenderEnabled is true by the default renderers. Custom renderers can choose to call it or not. The default implementation calls debugRender on all Components and the attached Colliders if there are any

Some of the key/important properties on an Entity are the following:

- **updateOrder**: controls the order of Entities. This affects the order in which update is called on each Entity as well as the order of the tag lists.
- **tag**: use this however you want to. It can later be used to query the scene for all Entities with a specific tag (**Scene.findEntitiesByTag**).
- **colliders**:  the Colliders managed by this Entity. Adding any Colliders automatically registers the Collider with the Physics system.
- **updateInterval**: specifies how often this Entities update method should be called. 1 means every frame, 2 is every other, etc


## Component
Components are added to and managed by an Entity. They make up the meat of your game and are basically reuseable chunks of code that decide how your Entities will behave. Several Component subclasses are included with Nez including text display, image display, animated sprites, Tiled maps and more.

Component Lifecycle methods:

- **onAddedToEntity**: Called when the Component is added to an entity after all pending component changes are committed
- **onRemovedFromEntity**:  Called when the component is removed from its entity. Do all cleanup here.
- **onEntityPositionChanged**: called when the entity's position changes. This allows components to be aware that they have moved due to the parent entity moving.
- **update**: called each frame as long as the Entity and Component are enabled and the Component implements IUpdatable
- **debugRender**: conditionally called. See Entity section for details.
- **onEnabled**: called when the parent Entity or the Component is enabled
- **onDisabled**: called when the parent Entity or the Component is disabled

It is worth mentioning the **RenderableComponent** abstract Component subclass here. RenderableComponent is a special kind of component that has a **render** method that is called by a Renderer. RenderableComponent handles a lot of dirtywork automatically (such as managing the bounds for culling) and includes a bunch of handy methods and properties pertaining to display. Have a look at the included RenderableComponent subclasses for examples of how they work.

