# Class InteractorHapticsConfigurator

Sets up the Interactor Haptics Prefab based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [CancelHapticProcessors]
  * [DefaultHapticProcessors]
  * [Facade]
  * [LeftControllerRule]
  * [Matcher]
  * [ProfileHapticProcessors]
  * [RightControllerRule]
* [Methods]
  * [BeginDefaultHapticsOnLeftController()]
  * [BeginDefaultHapticsOnRightController()]
  * [BeginProfileHapticsOnLeftController()]
  * [BeginProfileHapticsOnRightController()]
  * [CancelHapticsOnLeftController()]
  * [CancelHapticsOnRightController()]
  * [ConfigureControllerRules(InteractorFacade, ListContainsRule)]
  * [ConfigureLeftControllerRules()]
  * [ConfigureRightControllerRules()]
  * [OnEnable()]
  * [ProcessCancelHapticsOnMatch(GameObject)]
  * [ProcessDefaultHapticsOnMatch(GameObject)]
  * [ProcessProfileHapticsOnMatch(GameObject)]
  * [ResetIntensity(HapticProcess, Nullable<Single>)]
  * [UpdateIntensity(HapticProcess)]

## Details

##### Inheritance

* System.Object
* InteractorHapticsConfigurator

##### Namespace

* [Tilia.Output.InteractorHaptics]

##### Syntax

```
public class InteractorHapticsConfigurator : MonoBehaviour
```

### Properties

#### CancelHapticProcessors

The GameObject containing the logic for canceling existing haptic processes.

##### Declaration

```
public GameObject CancelHapticProcessors { get; protected set; }
```

#### DefaultHapticProcessors

The GameObject containing the default haptic processing logic.

##### Declaration

```
public GameObject DefaultHapticProcessors { get; protected set; }
```

#### Facade

The public interface facade.

##### Declaration

```
public InteractorHapticsFacade Facade { get; protected set; }
```

#### LeftControllerRule

The linked ListContainsRule for the left controller.

##### Declaration

```
public ListContainsRule LeftControllerRule { get; protected set; }
```

#### Matcher

The linked RulesMatcher.

##### Declaration

```
public RulesMatcher Matcher { get; protected set; }
```

#### ProfileHapticProcessors

The GameObject containing the profile haptic processing logic.

##### Declaration

```
public GameObject ProfileHapticProcessors { get; protected set; }
```

#### RightControllerRule

The linked ListContainsRule for the right controller.

##### Declaration

```
public ListContainsRule RightControllerRule { get; protected set; }
```

### Methods

#### BeginDefaultHapticsOnLeftController()

Begins processing the default haptics associated with the left controller.

##### Declaration

```
public virtual void BeginDefaultHapticsOnLeftController()
```

#### BeginDefaultHapticsOnRightController()

Begins processing the default haptics associated with the right controller.

##### Declaration

```
public virtual void BeginDefaultHapticsOnRightController()
```

#### BeginProfileHapticsOnLeftController()

Begins processing the set profile haptics associated with the left controller.

##### Declaration

```
public virtual void BeginProfileHapticsOnLeftController()
```

#### BeginProfileHapticsOnRightController()

Begins processing the set profile haptics associated with the right controller.

##### Declaration

```
public virtual void BeginProfileHapticsOnRightController()
```

#### CancelHapticsOnLeftController()

Cancels the haptics on the left controller.

##### Declaration

```
public virtual void CancelHapticsOnLeftController()
```

#### CancelHapticsOnRightController()

Cancels the haptics on the right controller.

##### Declaration

```
public virtual void CancelHapticsOnRightController()
```

#### ConfigureControllerRules(InteractorFacade, ListContainsRule)

Configures the rules for the controller.

##### Declaration

```
protected virtual void ConfigureControllerRules(InteractorFacade interactor, ListContainsRule ruleList)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractorFacade | interactor | The Interactor associated with the controller. |
| ListContainsRule | ruleList | The rule to manage. |

#### ConfigureLeftControllerRules()

Configures the rules for the left controller matching rule.

##### Declaration

```
public virtual void ConfigureLeftControllerRules()
```

#### ConfigureRightControllerRules()

Configures the rules for the right controller matching rule.

##### Declaration

```
public virtual void ConfigureRightControllerRules()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### ProcessCancelHapticsOnMatch(GameObject)

Cancels the haptic processes running on the given Interactor

##### Declaration

```
public virtual void ProcessCancelHapticsOnMatch(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The Interactor to cancel on. |

#### ProcessDefaultHapticsOnMatch(GameObject)

Processes the default haptics on the given Interactor.

##### Declaration

```
public virtual void ProcessDefaultHapticsOnMatch(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The Interactor to process. |

#### ProcessProfileHapticsOnMatch(GameObject)

Processes the haptics profile on the given Interactor.

##### Declaration

```
public virtual void ProcessProfileHapticsOnMatch(GameObject interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | interactor | The Interactor to process. |

#### ResetIntensity(HapticProcess, Nullable<Single>)

Resets the HapticPulser.Intensity to the given value.

##### Declaration

```
protected virtual void ResetIntensity(HapticProcess process, float? value)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| HapticProcess | process | The process to update. |
| System.Nullable<System.Single\> | value | The value to set the Intensity to. |

#### UpdateIntensity(HapticProcess)

Updates the HapticPulser.Intensity on the given HapticProcess.

##### Declaration

```
protected virtual float? UpdateIntensity(HapticProcess process)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| HapticProcess | process | The process to update |

##### Returns

| Type | Description |
| --- | --- |
| System.Nullable<System.Single\> | the original Intensity value to restore. |

[Tilia.Output.InteractorHaptics]: README.md
[InteractorHapticsFacade]: InteractorHapticsFacade.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[CancelHapticProcessors]: #CancelHapticProcessors
[DefaultHapticProcessors]: #DefaultHapticProcessors
[Facade]: #Facade
[LeftControllerRule]: #LeftControllerRule
[Matcher]: #Matcher
[ProfileHapticProcessors]: #ProfileHapticProcessors
[RightControllerRule]: #RightControllerRule
[Methods]: #Methods
[BeginDefaultHapticsOnLeftController()]: #BeginDefaultHapticsOnLeftController
[BeginDefaultHapticsOnRightController()]: #BeginDefaultHapticsOnRightController
[BeginProfileHapticsOnLeftController()]: #BeginProfileHapticsOnLeftController
[BeginProfileHapticsOnRightController()]: #BeginProfileHapticsOnRightController
[CancelHapticsOnLeftController()]: #CancelHapticsOnLeftController
[CancelHapticsOnRightController()]: #CancelHapticsOnRightController
[ConfigureControllerRules(InteractorFacade, ListContainsRule)]: #ConfigureControllerRulesInteractorFacade-ListContainsRule
[ConfigureLeftControllerRules()]: #ConfigureLeftControllerRules
[ConfigureRightControllerRules()]: #ConfigureRightControllerRules
[OnEnable()]: #OnEnable
[ProcessCancelHapticsOnMatch(GameObject)]: #ProcessCancelHapticsOnMatchGameObject
[ProcessDefaultHapticsOnMatch(GameObject)]: #ProcessDefaultHapticsOnMatchGameObject
[ProcessProfileHapticsOnMatch(GameObject)]: #ProcessProfileHapticsOnMatchGameObject
[ResetIntensity(HapticProcess, Nullable<Single>)]: #ResetIntensityHapticProcess-Nullable<Single>
[UpdateIntensity(HapticProcess)]: #UpdateIntensityHapticProcess
