![EOP](https://imgur.com/1e8rcGw.png)
# Easy Object Pool for Unity

Easy Object Pool (EOP) is a Unity package that simplifies the creation and management of object pools. With EOP, you can easily instantiate multiple objects of the same type and quickly retrieve them as needed.

## Installation

To use EOP in your Unity project, follow these steps:

1. Copy the HTTPS link of the repo `https://github.com/TheOrdinaryWitch/EasyObjectPool.git`.
2. Import the package into your Unity project by selecting Window -> Package Manager -> add package from giturl.
3. Download the sample of the package named "Easy Object Pool manager" on the same window.
## Usage

To create a new object pool using EOP, follow these steps:

1. Drag the `EasyObjectPoolManager` prefab from the `Samples/EasyObjectPool/1.0.0/EasyObjectPoolManager` folder into your Unity scene hierarchy.
2. Enter the desired values for the `ID`, `Name`, `Object Prefab`, and `Total Objects` properties in the `EasyObjectPool` component inspector.

   - `ID`: An integer value used to identify this object pool.
   - `Name`: A string value used to provide a human-readable name for this object pool.
   - `Object Prefab`: The prefab that will be instantiated to create objects in this pool.
   - `Total Objects`: The number of objects to create when the object pool is initialized.

3. To retrieve an object from the pool, call the `GetPooledObject` method on the `EasyObjectPool.SharedInstance` object, passing the `ID` of the desired pool as an argument:

   ```csharp
   GameObject obj = EasyObjectPool.SharedInstance.GetPooledObject(id);
   ```
4. When you're finished using an object, you can return it to the pool by deactivating it using the SetActive(false) method:

   ```csharp
   obj.SetActive(false);
   ```
5. You can also disable all objects in a pool using the 'disableObjects' method:
   ```csharp
   EasyObjectPool.SharedInstance.disableObjects(id);
   ```
   And you can disable all objects in all pools using the disableAllObjects method:
   ```csharp
   EasyObjectPool.SharedInstance.disableAllObjects();
   ```

## Examples

```csharp
// Get an object from the pool and activate it
GameObject obj = EasyObjectPool.SharedInstance.GetPooledObject(id);
obj.SetActive(true);

// Deactivate an object and return it to the pool
obj.SetActive(false);

// Deactivate all objects in a pool
EasyObjectPool.SharedInstance.disableObjects(id);

// Deactivate all objects in all pools
EasyObjectPool.SharedInstance.disableAllObjects();
```
## Support
If you encounter any bugs or issues with EOP, please open a new issue on the issue tracker or contact me to thewitch@witchdev.com
## Contributing

If you would like to contribute code to the project, please fork the repository and submit a pull request with your changes.

## License
EOP is licensed under the MIT license. See the LICENSE file for details.
