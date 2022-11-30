# MGS.RedDot
## Summary
- Red dot plugin for C# project.

## Environment
- Unity 5.0 or above.
- .Net Framework 3.5 or above.

## Platform
- Windows.

## Version

- 0.1.0

## Demand
- Mark a data struct is red(dirty) if self changed or children data struct changed.

## Design

- Base class to collect state changes.
- Base class to register and unregister children dots.

## Usage

- Inherited from Base class RedDot.

```C#
public class Leaf : RedDot
{
    public Color Color
    {
        set
        {
            //Check the value is changed?
            if (value != color)
            {
                color = value;
                
                //Set red state if value is changed.
                IsRed = true;
            }
        }
        get { return color; }
    }
    protected Color color;
}
```

## Source

https://github.com/mogoson/MGS.RedDot

------

Copyright © 2022 Mogoson.	mogoson@outlook.com
