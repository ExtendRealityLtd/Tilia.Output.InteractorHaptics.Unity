# Class InteractorHapticsFacade

The public interface into the Interactor Haptics Prefab.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [Configuration]
  * [Intensity]
  * [LeftInteractor]
  * [Profile]
  * [RightInteractor]
  * [TrackedAlias]
* [Methods]
  * [CancelAllHaptics()]
  * [CancelHaptics(GameObject)]
  * [CancelHaptics(InteractorFacade)]
  * [CancelHaptics(XRNode)]
  * [ClearLeftInteractor()]
  * [ClearRightInteractor()]
  * [ClearTrackedAlias()]
  * [OnAfterLeftInteractorChange()]
  * [OnAfterRightInteractorChange()]
  * [PerformDefaultHaptics(GameObject)]
  * [PerformDefaultHaptics(InteractorFacade)]
  * [PerformDefaultHaptics(XRNode)]
  * [PerformProfileHaptics(GameObject)]
  * [PerformProfileHaptics(InteractorFacade)]
  * [PerformProfileHaptics(XRNode)]

## Details

##### Inheritance

* System.Object
* InteractorHapticsFacade

##### Namespace

* [Tilia.Output.InteractorHaptics]

##### Syntax

```
public class InteractorHapticsFacade : MonoBehaviour
```

### Properties

#### Configuration

The linked [InteractorHapticsConfigurator].

##### Declaration

```
public InteractorHapticsConfigurator Configuration { get; protected set; }
```

#### Intensity

The intensity to produce the haptic output at for the current process.

##### Declaration

```
public float Intensity { get; set; }
```

#### LeftInteractor

The linked InteractorFacade to relate to the left controller.

##### Declaration

```
public InteractorFacade LeftInteractor { get; set; }
```

#### Profile

The haptic profile to process.

##### Declaration

```
public int Profile { get; set; }
```

#### RightInteractor

The linked InteractorFacade to relate to the right controller.

##### Declaration

```
public InteractorFacade RightInteractor { get; set; }
```

#### TrackedAlias

The linked TrackedAliasFacade.

##### Declaration

```
public TrackedAliasFacade TrackedAlias { get; set; }
```

### Methods

#### CancelAllHaptics()

Cancels all haptic processes for both controllers.

##### Declaration

```
public virtual void CancelAllHaptics()
```

#### CancelHaptics(GameObject)

Cancels all haptic processes associated with the given Interactor GameObject.

##### Declaration

```
public virtual void CancelHaptics(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The Interactor to cancel the haptics on. |

#### CancelHaptics(InteractorFacade)

Cancels all haptic processes associated with the given Interactor.

##### Declaration

```
public virtual void CancelHaptics(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractorFacade | interactor | The Interactor to cancel the haptics on. |

#### CancelHaptics(XRNode)

Cancels all haptic processes associated with the Interactor associated with the specified XRNode.

##### Declaration

```
public virtual void CancelHaptics(XRNode node)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| XRNode | node | The node associated with the Interactor to cancel the haptics on. |

#### ClearLeftInteractor()

Clears [LeftInteractor].

##### Declaration

```
public virtual void ClearLeftInteractor()
```

#### ClearRightInteractor()

Clears [RightInteractor].

##### Declaration

```
public virtual void ClearRightInteractor()
```

#### ClearTrackedAlias()

Clears [TrackedAlias].

##### Declaration

```
public virtual void ClearTrackedAlias()
```

#### OnAfterLeftInteractorChange()

Called after [LeftInteractor] has been changed.

##### Declaration

```
protected virtual void OnAfterLeftInteractorChange()
```

#### OnAfterRightInteractorChange()

Called after [RightInteractor] has been changed.

##### Declaration

```
protected virtual void OnAfterRightInteractorChange()
```

#### PerformDefaultHaptics(GameObject)

Performs the haptics process on the default haptic process associated with the given Interactor GameObject.

##### Declaration

```
public virtual void PerformDefaultHaptics(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The Interactor to process the haptics for. |

#### PerformDefaultHaptics(InteractorFacade)

Performs the haptics process on the default haptic process associated with the given Interactor.

##### Declaration

```
public virtual void PerformDefaultHaptics(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractorFacade | interactor | The Interactor to process the haptics for. |

#### PerformDefaultHaptics(XRNode)

Performs the haptics process on the default haptic process associated with the Interactor associated with the specified XRNode.

##### Declaration

```
public virtual void PerformDefaultHaptics(XRNode node)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| XRNode | node | The node associated with the Interactor to process the haptics for. |

#### PerformProfileHaptics(GameObject)

Performs the haptics process on the specified haptic profile associated with the given Interactor GameObject.

##### Declaration

```
public virtual void PerformProfileHaptics(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The Interactor to process the haptics for. |

#### PerformProfileHaptics(InteractorFacade)

Performs the haptics process on the specified haptic profile associated with the given Interactor.

##### Declaration

```
public virtual void PerformProfileHaptics(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractorFacade | interactor | The Interactor to process the haptics for. |

#### PerformProfileHaptics(XRNode)

Performs the haptics process on the specified haptic profile associated with the Interactor associated with the specified XRNode.

##### Declaration

```
public virtual void PerformProfileHaptics(XRNode node)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| XRNode | node | The node associated with the Interactor to process the haptics for. |

[Tilia.Output.InteractorHaptics]: README.md
[InteractorHapticsConfigurator]: InteractorHapticsConfigurator.md
[LeftInteractor]: InteractorHapticsFacade.md#LeftInteractor
[RightInteractor]: InteractorHapticsFacade.md#RightInteractor
[TrackedAlias]: InteractorHapticsFacade.md#TrackedAlias
[LeftInteractor]: InteractorHapticsFacade.md#LeftInteractor
[RightInteractor]: InteractorHapticsFacade.md#RightInteractor
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[Configuration]: #Configuration
[Intensity]: #Intensity
[LeftInteractor]: #LeftInteractor
[Profile]: #Profile
[RightInteractor]: #RightInteractor
[TrackedAlias]: #TrackedAlias
[Methods]: #Methods
[CancelAllHaptics()]: #CancelAllHaptics
[CancelHaptics(GameObject)]: #CancelHapticsGameObject
[CancelHaptics(InteractorFacade)]: #CancelHapticsInteractorFacade
[CancelHaptics(XRNode)]: #CancelHapticsXRNode
[ClearLeftInteractor()]: #ClearLeftInteractor
[ClearRightInteractor()]: #ClearRightInteractor
[ClearTrackedAlias()]: #ClearTrackedAlias
[OnAfterLeftInteractorChange()]: #OnAfterLeftInteractorChange
[OnAfterRightInteractorChange()]: #OnAfterRightInteractorChange
[PerformDefaultHaptics(GameObject)]: #PerformDefaultHapticsGameObject
[PerformDefaultHaptics(InteractorFacade)]: #PerformDefaultHapticsInteractorFacade
[PerformDefaultHaptics(XRNode)]: #PerformDefaultHapticsXRNode
[PerformProfileHaptics(GameObject)]: #PerformProfileHapticsGameObject
[PerformProfileHaptics(InteractorFacade)]: #PerformProfileHapticsInteractorFacade
[PerformProfileHaptics(XRNode)]: #PerformProfileHapticsXRNode
