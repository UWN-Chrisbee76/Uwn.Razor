# Uwn.Razor

A Razor Class Library for re-usable components, and Bootstrap wrappers.

|Information|Value
|--|--
|**Project Type**|Razor Class Library
|**Framework**|.NET 9.0
|**Current Version**|9.1.0
|**Author**|Chris B.
|**Publisher**|UltimateWisdom.Net
|**License**|MIT License

Documentation and examples can be found at:  
https://razor-demo.ultimatewisdom.net/

## BREAKING CHANGES from v9.1.*

1. Property `Style` is now part of `Appearance`
1. Property `DropShadow` is now part of `Decorations`, which is part of `Appearance`
1. Properties `Delay` and `HasCloseButton` are now part of `DismissOptions`
1. Most `Content` / `Text` properties have been changed to the `Content` type, which includes an optional icon
1. Moved component `ExternalLink` from `Bootstrap` to `Common`

## New and Improved in v9.1.0

1. Added ViewModels for all components
1. Added Providers for (almost) all components - see below
1. The `FragmentProvider` class is now `public`, and provides methods for FontAwesome handling, and content formatting
1. The `rounded` Bootstrap CSS class is now available through the `Appearance.Decorations` property
1. Text and Time elements of the `WaitIndicator` now have an individual `id` each, derived from the `Id` of the `WaitIndicator`
1. Added static class `IconNames` for commonly used icon names
1. Added `OnDismissed` callback to `ModalDialog`
1. Added `Header` to `Alert`

### Component Providers

Component Providers have been added for almost all components (doing this for Tables and their sub-components make no sense).

Providers allow you to cascade components, and access their view models in your embedded components.

For example, in your `MainLayout.razor`, you could do this:
```
<WaitIndicatorProvider>
    <AlertProvider>
        <CardProvider>
            @Body
        </CardProvider>
    </AlertProvider>
</WaitIndicatorProvider>
```

And then do this in your own components:
```
<button type="button" @onclick="OnButtonClickAsync">Do something</button>

@code {
    [CascadingParameter] public WaitIndicatorViewModel WaitIndicator { get; set; } = default!;
    [CascadingParameter] public AlertViewModel Alert { get; set; } = default!;
    [CascadingParameter] public CardViewModel Card { get; set; } = default!;

    private async Task OnButtonClickAsync()
    {
        await WaitIndicator.ShowAsync();
        try
        {
            await SomeActionAsync();
            await Alert.ShowSuccessAsync("Success!");
        }
        catch (Exception ex)
        {
            await Card.ShowExceptionAsync(ex);
        }
        await WaitIndicator.HideAsync();
    }
}
```

_EOF_