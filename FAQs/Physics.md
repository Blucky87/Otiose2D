Physics/Collisions
==========

It serves to reiterate what has been stated before: Nez physics is *not* a realistic physics simulation. It provides what I call *game* physics. You can do things like linecasts to detect colliders, overlap checks, collision checks, sweep tests and more. What you don't get is a full rigid body simulation. *You* get to control your games feel from top to bottom.



## Colliders: The Root of the Physics System
Nothing happens in the physics system without Colliders. Colliders live on the Entity class and come in several varieties: BoxCollider, CircleCollider and PolygonCollider. You can add a Collider like so: `entity.colliders.add( new BoxCollider() )`. When you have debugRender enabled Colliders will be displayed with red lines (to enable debugRender either set `Core.debugRenderEnabled = true` or open the console and type "debug-render"). Colliders are automatically added to the SpatialHash when you add them to an Entity, which brings us to our next topic.



## The SpatialHash: You'll never touch it but it's still important
Under the covers lies the SpatialHash class which manages Colliders globally for your game. The static **Physics** class is the public wrapper for the SpatialHash. The SpatialHash has no set size limits and is used to make collision/linecast/overlap checks really fast. As an example, if you have a hero moving around the world instead of having to check every Collider (which could be hundreds) for a collision you can just ask the SpatialHash for all the Colliders near your hero. That narrows down your collision checks drastically.

There is one configurable aspect to the SpatialHash that can greatly affect how performant it is: the cell size. The SpatialHash splits up space into a grid and choosing a proper grid size can keep your possible collision queries to a minimum. By default the grid size is 100 pixels. You can change this by setting `Physics.spatialHashCellSize` *before* creating a Scene. Choosing a size that is slightly larger than your average player/enemy size usually works best.

One last thing about the SpatialHash: it includes a visual debugger. By pulling up the in-game console (press the tilde key) and running the command **physics** the SpatialHash grid and number of objects in each cell will be displayed. This is handy for helping to decide what your spatialHashCellSize should be.



## The Physics Class
The **Physics** class is your gateway to all things Physics. There are some properties you can set such as the aforementioned spatialHashCellSize, raycastsHitTriggers and raycastsStartInColliders. See the intellisense docs for an explanation of each. Some of the more useful and commonly used methods are:

- **linecast**: casts a line from start to end and returns the first hit of a collider that matches layerMask
- **overlapRectangle**: check if any collider falls within a rectangular area
- **overlapCircle**: check if aany collider falls within a circular area
- **boxcastBroadphase**: returns all colliders with bounds that are intersected by collider.bounds. Note that this is a broadphase check so it only checks bounds and does not do individual Collider-to-Collider checks!

Astute readers will have noticed the *layerMask* mentioned above. The layerMask lets you decide which colliders are collided with. Each Collider can have its `physicsLayer` set so that when you query the Physics system you can choose to get back only Colliders that match the passed in layerMask. All Physics methods accept a layerMask parameter that defaults to all layers. Use this wisely to filter your collision checks and keep things as performant as possible by not doing unnecessary collision checks.



## Putting the Physics System to Use
Linecasts are extremely useful for various things like checking line-of-sight for enemies, detecting the spatial surroundings of an Entity, fast-moving bullets, etc. Here is an example of casting a line from start to end that just logs the data if it hits something:

```cs
var hit = Physics.linecast( start, end );
if( hit.collider != null )
	Debug.log( "ray hit {0}, entity: {1}", hit, hit.collider.entity );
```

Nez has some more advanced collision/overlap checks using methods such as Minkowski Sums, Separating Axis Theorem and good old trigonometry. These are all wrapped up in simple to use methods on the Collider class for you. Lets take a look at some examples.

```cs
// CollisionResult will contain some really useful information such as the Collider that was hit, the normal of the surface it and the 
// minimum translation vector (MTV). The MTV can be used to move the colliding Entity directly adjacent to the hit Collider.
CollisionResult collisionResult;

// do a check to see if entity.collider collides with someOtherCollider 
if( entity.collider.collidesWith( someOtherCollider, deltaMovement, out collisionResult ) )
{
	// move entity to the position directly adjacent to the hit Collider then log the CollisionResult
	entity.transform.position += deltaMovement - collisionResult.minimumTranslationVector;
	Debug.log( "collision result: {0}", collisionResult );
}
```

We can take the above example a step further using the previously mentioned `Physics.boxcastBroadphase` method, or more specifically a version of it that excludes ourself from the query. That method will give us all the colliders in the Scene that are in our vicinity which we can then use to do our actual collision checks on.

```cs
// fetch anything that we might overlap with at our position excluding ourself. We don't care out ourself here obviously.
var neighborColliders = Physics.boxcastBroadphaseExcludingSelf( entity.collider.bounds );

// loop through and check each Collider for an overlap
foreach( var collider in neighborColliders )
{
	if( entity.collider.overlaps( collider )
		Debug.log( "We are overlapping a Collider: {0}", collider );
}
```

