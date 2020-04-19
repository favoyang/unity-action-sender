<p align="center">
  <img width="180" src="https://raw.githubusercontent.com/favoyang/unity-action-sender/master/Media~/icon-512.png" alt="logo">
</p>
<h1 align="center">Unity Action Sender</h1>

[![openupm](https://img.shields.io/npm/v/com.littlebigfun.action-sender?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.littlebigfun.action-sender/)

A type-safe replacement to SendMessage.

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

Import the namespace to send actions.

```
using LittleBigFun.ActionSender;
```

Replace SendMessage with:

```
gameObject.SendAction<IDamageable>(t => t.Damage(1.0f));
```

Replace BroadcastMessage with:

```
gameObject.BroadcastAction<IDamageable>(t => t.Damage(1.0f));
```

Replace SendMessageUpwards with:

```
gameObject.SendActionUpwards<IDamageable>(t => t.Damage(1.0f));
```

To get result value of actions:
```
var results = gameObject.SendAction<IDamageable, bool>(t => t.IsAlive());
var results = gameObject.BroadcastAction<IDamageable, bool>(t => t.IsAlive());
var results = gameObject.SendActionUpwards<IDamageable, bool>(t => t.IsAlive());
```

## Install Package

The package is available on the [openupm registry](https://openupm.com). It's recommended to install it via [openupm-cli](https://github.com/openupm/openupm-cli).

```
openupm add com.littlebigfun.action-sender
```

Or you can install via [Git URL](https://docs.unity3d.com/Manual/upm-ui-giturl.html).

## Media

Icons made by [Freepik](https://www.flaticon.com/authors/freepik) from [flaticon.com](http://www.flaticon.com)
