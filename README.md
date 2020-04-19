<p align="center">
  <img width="180" src="https://raw.githubusercontent.com/favoyang/unity-action-sender/master/Media~/icon-512.png" alt="logo">
</p>
<h1 align="center">Unity Action Sender</h1>

A type-safe replacement for SendMessage.

SendMessage is a known trap for hard to maintain. An alternative way is using `GetComponents<T>` with the `interface T`. This package consists of a group of extension API to simplify the approach.

## How to Use

Define an interface for your callbacks.

```
public interface IDamageable
{
    void Damage(float amount);
    bool IsAlive();
}
```

Implements the interface on your component.

```
public class Unit : MonoBehaviour, IDamageable
{
    public void Damage(float amount)
    {
      // take damage.
    }

    public bool IsAlive()
    {
      // return is alive?
    }
}
```

Replace SendMessage with:

```
using LittleBigFun.ActionSender;

gameObject.SendAction<IDamageable>(t => t.Damage(1.0f));
```

Replace BroadcastMessage with:

```
using LittleBigFun.ActionSender;

gameObject.BroadcastAction<IDamageable>(t => t.Damage(1.0f));
```

Replace SendMessageUpwards with:

```
using LittleBigFun.ActionSender;

gameObject.SendActionUpwards<IDamageable>(t => t.Damage(1.0f));
```

To get result value of actions:
```
using LittleBigFun.ActionSender;

var results = gameObject.SendAction<IDamageable, bool>(t => t.IsAlive());
var results = gameObject.BroadcastAction<IDamageable, bool>(t => t.IsAlive());
var results = gameObject.SendActionUpwards<IDamageable, bool>(t => t.IsAlive());
```

## Install Package

The package is available on the [openupm registry](https://openupm.com). It's recommended to install it via [openupm-cli](https://github.com/openupm/openupm-cli).

```
openupm add com.littlebigfun.action-sender
```

Or you can install via Git URL.

## Media

Icons made by [Freepik](https://www.flaticon.com/authors/freepik) from [flaticon.com](http://www.flaticon.com)
