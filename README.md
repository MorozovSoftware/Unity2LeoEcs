# Unity2LeoEcs
 Интеграция игровых объектов Unity в сущности LeoECS
## Установка
- [Установка Zenject](https://github.com/modesttree/Zenject#installation-);
- [Установка LeoECS](https://github.com/Leopotam/ecs#%D0%A3%D1%81%D1%82%D0%B0%D0%BD%D0%BE%D0%B2%D0%BA%D0%B0);
- [Установка LeoECS Unity integration](https://github.com/Leopotam/ecs-unityintegration#%D1%83%D1%81%D1%82%D0%B0%D0%BD%D0%BE%D0%B2%D0%BA%D0%B0);
- Unity2LeoEcs устанавливается через Package Manager по ссылке на данный репозиторий:
```
https://github.com/MorozovSoftware/Unity2LeoEcs.git
```
## Создание EcsWorld
Компонент **EcsWorldInstaller** отвечает за создание и регистрацию в контексте сцены экземпляра **EcsWorld**.
1. Создание **Project Context**:
    ```
    Edit -> Zenject -> Create Project Context
    ```
2. Создание **Scene Context**:
    ```
    GameObject -> Zenject -> Scene Context
    ```
3. Добавление компонента **EcsWorldInstaller**:
    ```
    Component -> Add -> EcsWorldInstaller
    ```
3. Добавление созданного **EcsWorldInstaller** в список *MonoInstallers* на **SceneContext**.

## Подготовка EcsStartup
**EcsStartup** должен получать экземпляр **EcsWorld** через внедрение зависимостей 
1. Создание **EcsStartup** через шаблон
    ```
    Assets -> Create -> LeoECS -> Create Startup Template
    ```    
2. Удаление строк:
    ```C#
    _world = new EcsWorld ();
    ```    
    ```C#
    Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
    ```
3. Добавление строк:
    ```C#
    [Inject]
    public void Construct(EcsWorld world)
    {
        _world = world;
    }
    ```

## Unity Objects
Объекты Unity (Transform, Camera...) добавляются к ECS сущности как ECS компонент **UnityObject\<T>**, где **T** - класс объекта Unity, а поле **Value** содержит ссылку на сам объект.

## Struct For Leo Ecs
**StructForLeoEcs\<T>** позволяет добавлять и настраивать ECS компоненты в инспекторе
1. Добавление атрибута **[System.Serializable]** структуре, для изменения ее полей через инспектор.
    ```C#
    using System;
    [Serializable]
    public struct ProfileComponent 
    {
        public int Id;
        public string Name;
    }
    ```

2. Создание класса, унаследованного от **StructForLeoEcs\<T>**, где **T** - название структуры.
    ```C#
    public class ProfileComponentHolder : StructForLeoEcs<ProfileComponent> {}
    ```
## Интеграция игрового объекта Unity в сущность LeoECS
1. Интеграция осуществляется через контекстное меню GameObject (правая клавиша на игровом объекте):
    ```
    ПКМ -> Unity 2 LeoECS -> SetupGameObject
    ```
+ Если не существует добавится **GameObjectContext**;
+ Если не существует добавится **EcsEntityInstaller**;
+ Если не существует добавится **ComponentsInstaller**;
+ **EcsEntityInstaller** и **ComponentsInstaller** добавятся в список *MonoInstallers* **GameObjectContext**.

2. Затем через контестное меню GameObject необходимо выбрать один из пунктов:
+ **Active To Entity** - компоненты будут добавляться в OnEnable() и удаляться в OnDisable():
    ```
    ПКМ -> Unity 2 LeoECS -> Select Active To Entity
    ```
+ **Alive To Entity**  - компоненты будут добавляться в Start() и удаляться в OnDestroy():
    ```
    ПКМ -> Unity 2 LeoECS -> Select Alive To Entity
    ```
+ **Started To Entity** - компоненты будут добавляться в Start():
    ```
    ПКМ -> Unity 2 LeoECS -> Select Started To Entity
    ```
3. В компоненте **ComponentsInstaller** требуется выбрать компоненты, которые будут переноситься на ECS сущность;

4. Если объект изначально не присутствует на сцене и планируется создавать его экземпляры через Instantiate следует добавить компонент **ZenAutoInjecter**. 







